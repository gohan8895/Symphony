using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class CourseRegistrationExtension
    {
        public static CourseRegistrationVM AsVM(this CourseRegistration courseRegistration) => new()
        {
            Id = courseRegistration.Id,
            UserId = courseRegistration.UserId,
            CourseId = courseRegistration.CourseId,
            IsApproved = courseRegistration.IsApproved,
            CreatedAt = DateTime.Now,
            IsDelete = courseRegistration.IsDelete,
            ExamRequired = courseRegistration.ExamRequired
        };

        public static CourseRegistrationWithDataVM AsVMWithData(this CourseRegistration courseRegistration) => new()
        {
            Id = courseRegistration.Id,
            UserId = courseRegistration.UserId,
            CourseId = courseRegistration.CourseId,
            IsApproved = courseRegistration.IsApproved,
            CreatedAt = courseRegistration.CreatedAt,
            ExamRequired = courseRegistration.ExamRequired,
            IsDelete = courseRegistration.IsDelete,
            AppUserVM = courseRegistration.AppUser.AsVM(),
            CourseVM = courseRegistration.Course.AsVM(),
            EntranceExamFee = courseRegistration.ExamRequired ? 50 : 0,
            FinalPrice = courseRegistration.ExamRequired ? courseRegistration.Course.Price + 50 : courseRegistration.Course.Price
        };
    }
}