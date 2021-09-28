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
        public static CourseRegistrationVM AsVM(this CourseRegistration courseRegistration) => new CourseRegistrationVM
        {
            Id = courseRegistration.Id ,
            UserId = courseRegistration.UserId ,
            CourseId = courseRegistration.CourseId ,
            IsApproved = courseRegistration.IsApproved,
            CreatedAt = DateTime.Now ,
            ExamRequired = courseRegistration.ExamRequired 
        };
    }





}

