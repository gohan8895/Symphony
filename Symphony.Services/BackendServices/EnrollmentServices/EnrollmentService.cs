using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.EnrollmentServices
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public EnrollmentService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<EnrollmentVM> GetEnrollmentVMAsync(Guid studentId, int courseId)
        {
            var enrollment = await symphonyDBContext.Enrollments.FirstOrDefaultAsync(e
                => e.UserId == studentId
                && e.CourseId == courseId);
            if (enrollment is null)
            {
                return null;
            }
            return enrollment.EnsVM();
        }

        public async Task<IEnumerable<EnrollmentVM>> GetEnrollmentVMsAsync()
        {
            var enrollments = await symphonyDBContext.Enrollments.Select(e => e.EnsVM()).ToListAsync();
            return enrollments;
        }

        public async Task<EnrollmentVM> CreateEnrollment(CreateEnrollmentVM enrollmentVM)
        {
            var timeNow = DateTime.Now;
            var enrollment = new Enrollment()
            {
                UserId = enrollmentVM.UserId,
                CourseId = enrollmentVM.CourseId,
                IsDelete = false,
                CreatedAt = timeNow,
                UpdatedAt = timeNow
            };

            await symphonyDBContext.Enrollments.AddAsync(enrollment);
            await symphonyDBContext.SaveChangesAsync();

            return enrollment.EnsVM();
        }

        public async Task<EnrollmentVM> UpdateEnrollment(UpdateEnrollmentVM enrollmentVM)
        {
            var enrollment = await symphonyDBContext.Enrollments.FirstOrDefaultAsync(e => e.Id == enrollmentVM.Id);
            if (enrollment is null)
            {
                return null;
            }
            var timeNow = DateTime.Now;
            enrollment.UserId = enrollmentVM.UserId;
            enrollment.CourseId = enrollmentVM.CourseId;
            enrollment.IsDelete = enrollmentVM.IsDelete;
            enrollment.UpdatedAt = timeNow;

            await symphonyDBContext.SaveChangesAsync();
            return enrollment.EnsVM();
        }

        public async Task<int> ChangeEnrollmentStatus(Guid studentId, int courseId)
        {
            var timeNow = DateTime.Now;
            var enrollment = await symphonyDBContext.Enrollments.FirstOrDefaultAsync(e => e.UserId == studentId
                && e.CourseId == courseId
            );

            if (enrollment is null) return 0;

            var status = enrollment.IsDelete;
            enrollment.UpdatedAt = timeNow;

            if (enrollment.IsDelete == false)
            {
                enrollment.IsDelete = true;
            }
            else enrollment.IsDelete = false;

            var result = await symphonyDBContext.SaveChangesAsync();

            return result == 0 ? 0 : 1;
        }

        public async Task<IEnumerable<EnrollmentWithData>> GetEnrollmentWithDataVM()
        {
            var enrollments = await symphonyDBContext.Enrollments.Select(e => new EnrollmentWithData()
            {
                Id = e.Id,
                UserId = e.UserId,
                CourseId = e.CourseId,
                IsDelete = e.IsDelete,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
                AppUserVM = e.AppUser.AsVM(),
                CourseVM = e.Course.AsVM()
            }).ToListAsync();

            return enrollments;
        }
    }
}