using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class EnrollmentExtension
    {
        public static EnrollmentVM EnsVM(this Enrollment enrollment) => new EnrollmentVM
        {
            Id = enrollment.Id,
            UserId = enrollment.UserId,
            CourseId = enrollment.CourseId,
            IsDelete = enrollment.IsDelete
        };
    }
}
