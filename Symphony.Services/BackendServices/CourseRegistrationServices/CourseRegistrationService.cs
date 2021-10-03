using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.Services.BackendServices.EnrollmentServices;
using Symphony.Services.BackendServices.PaymentStatusServices;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.CourseViewModel;
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
        private readonly IPaymentStatusService _paymnetService;
        private readonly IEnrollmentService _enrollmentService;

        public CourseRegistrationService(SymphonyDBContext symphonyDBContext, IPaymentStatusService service, IEnrollmentService enrollmentService)
        {
            this.symphonyDBContext = symphonyDBContext;
            _paymnetService = service;
            _enrollmentService = enrollmentService;
        }

        public async Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationVMsAsync()
        {
            var results = await symphonyDBContext.CourseRegistrations.Select(a => a.AsVM()).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<CourseRegistrationWithDataVM>> GetCourseRegistrationWithDataVMsAsync()
        {
            var courseRegistrationWithDataVM = await symphonyDBContext.CourseRegistrations
                .Include(x => x.Course)
                .Include(x => x.AppUser)
                .Select(a => a.AsVMWithData()).ToListAsync();

            return courseRegistrationWithDataVM;
        }

        public async Task<CourseRegistrationVM> GetCourseRegistrationVMAsync(int courseRegisId)
        {
            var result = await symphonyDBContext.CourseRegistrations.FirstOrDefaultAsync(a => a.Id == courseRegisId);

            if (result is null) return null;

            return result.AsVM();
        }

        public async Task<CourseRegistrationWithDataVM> CreateCourseRegistrationAsync(CreateCourseRegistrationVM courseRegistration)
        {
            var courseRegis = new CourseRegistration()
            {
                UserId = courseRegistration.UserId,
                CourseId = courseRegistration.CourseId,
                IsApproved = false,
                CreatedAt = DateTime.Now
            };

            var _course = await symphonyDBContext.Courses.SingleOrDefaultAsync(x => x.Id == courseRegistration.CourseId);
            if ((_course.IsBasic is not true)) courseRegis.ExamRequired = true;
            else courseRegis.ExamRequired = false;

            await symphonyDBContext.CourseRegistrations.AddAsync(courseRegis);
            await symphonyDBContext.SaveChangesAsync();

            //Insert data into payment
            double finalPrice = _course.Price;
            double priceEntranceExam = 50;
            if (courseRegis.ExamRequired) finalPrice += priceEntranceExam;
            var _paymentStatus = await _paymnetService.CreatePaymentStatusAsync(courseRegis.Id, finalPrice);

            //If
            var _createdCourseRegis = await symphonyDBContext.CourseRegistrations
                                        .Include(x => x.AppUser)
                                        .Include(x => x.Course)
                                        .SingleOrDefaultAsync(x => x.Id == courseRegis.Id);
            return _createdCourseRegis.AsVMWithData();
        }

        public async Task<CourseRegistrationVM> UpdateCourseRegistrationAsync(int courseRegistrationId)
        {
            var _courseResig = await symphonyDBContext.CourseRegistrations
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(a => a.Id == courseRegistrationId);

            if (_courseResig == null)
            {
                return null;
            }

            if (_courseResig.IsApproved is true) _courseResig.IsApproved = false;
            else _courseResig.IsApproved = true;

            //If the course registration is approved/not approved, it means student has paid the tuition fee
            //So we need to update the payment status as paid/unpaid
            var _paymentSttUpdateResult = await _paymnetService.UpdatePaymentStatusAsync(courseRegistrationId, _courseResig.IsApproved);

            var _studentEnrollment = await _enrollmentService.GetEnrollmentVMAsync(_courseResig.AppUser.Id, _courseResig.CourseId);
            if (_courseResig.IsApproved is true)
            {
                //check if the student has enroll in a course, if not, we insert an enrollment record to database
                if (_studentEnrollment is null)
                {
                    await _enrollmentService.CreateEnrollment(new CreateEnrollmentVM { UserId = _courseResig.AppUser.Id, CourseId = _courseResig.CourseId });
                    //update Batch information to User
                    var _batch = await symphonyDBContext.Batches.FirstOrDefaultAsync(x => x.EndDate < DateTime.Now);
                    //var _student = await symphonyDBContext.
                }
            }
            else _studentEnrollment.IsDelete = true;

            await symphonyDBContext.SaveChangesAsync();

            return _courseResig.AsVM();
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
    }
}