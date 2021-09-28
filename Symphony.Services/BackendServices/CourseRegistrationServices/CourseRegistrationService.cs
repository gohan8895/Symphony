using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.CourseRegistrationServices
{
   public class CourseRegistrationService : ICourseRegistrationService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public CourseRegistrationService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<CourseRegistrationVM> CreateCourseRegistrationAsync(CreateCourseRegistrationVM courseRegistration)
        {
            var courseRegis = new CourseRegistration()
            {
                UserId = courseRegistration.UserId,
                CourseId = courseRegistration.CourseId,
                IsApproved = courseRegistration.IsApproved,
                CreatedAt = DateTime.Now,
                ExamRequired = courseRegistration.ExamRequired,

            };
            await symphonyDBContext.CourseRegistrations.AddAsync(courseRegis);
            await symphonyDBContext.SaveChangesAsync();
            return courseRegis.AsVM();
        }

        public async Task<CourseRegistrationVM> DeleteCourseRegistrationAsync(int courseRegistrationId)
        {
            var courseRegis = await symphonyDBContext.CourseRegistrations.FirstOrDefaultAsync(a => a.Id == courseRegistrationId);
            if (courseRegis == null)
            {
                return null;
            }
            symphonyDBContext.Remove(courseRegis);
            await symphonyDBContext.SaveChangesAsync();
            return courseRegis.AsVM();
        }
        
        public async Task<CourseRegistrationVM> GetCourseRegistrationVMAsync(int courseRegisId)
        {
            var result = await symphonyDBContext.CourseRegistrations.FirstOrDefaultAsync(a => a.Id == courseRegisId);
            if (result == null)
            {
                return null;
            }
            return result.AsVM();
        }

        public async Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationsAsync()
        {
            var results = await symphonyDBContext.CourseRegistrations.Select(a => a.AsVM()).ToListAsync();
            return results;
        }


        public async Task<CourseRegistrationVM> UpdateCourseRegistrationAsync(UpdateCourseRegistrationVM courseRegistration)
        {
            var _courseResig = await symphonyDBContext.CourseRegistrations.FirstOrDefaultAsync(a => a.Id == courseRegistration.Id);
            if (_courseResig == null)
            {
                return null;
            }


            _courseResig.UserId = courseRegistration.UserId;
            _courseResig.CourseId = courseRegistration.CourseId;
            _courseResig.IsApproved = courseRegistration.IsApproved;
            _courseResig.ExamRequired = courseRegistration.ExamRequired;

            await symphonyDBContext.SaveChangesAsync();

            return _courseResig.AsVM();
        }

        public async Task<IEnumerable<CourseRegistrationWithData>> GetCourseRegistrationWithDatasVMAsync()
        {

            var results = await symphonyDBContext.CourseRegistrations.Select(a => new CourseRegistrationWithData()
            {
                Id = a.Id,
                UserId = a.UserId,
                CourseId = a.CourseId,
                IsApproved = a.IsApproved,
                CreatedAt = a.CreatedAt,
                ExamRequired = a.ExamRequired,
                AppUserVM = a.AppUser.AsVM(),
                CourseVM = a.Course.AsVM()
            }).ToListAsync();
            return results;
        }

  
    }
}














