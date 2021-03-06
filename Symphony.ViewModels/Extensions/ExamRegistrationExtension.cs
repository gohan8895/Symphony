using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class ExamRegistrationExtension
    {
        public static ExamRegistrationVM AsVM(this ExamRegistration regis)
        {
            return new ExamRegistrationVM
            {
                Id = regis.Id,
                ExamId = regis.ExamId,
                CreateAt = regis.CreateAt,
                UserId = regis.UserId,
                StudentFullName = regis.AppUser.FirstName + " " + regis.AppUser.LastName
            };
        }
    }
}