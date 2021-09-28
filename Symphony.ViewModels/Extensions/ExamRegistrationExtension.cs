using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.ExamRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class ExamRegistrationExtension
    {
        public static ExamRegistrationVM AsConsultVM(this ExamRegistration regis)
        {
            return new ExamRegistrationVM
            {
                Id = regis.Id,
                ExamId = regis.ExamId,
                CreateAt = regis.CreateAt,
                UserId = regis.UserId
            };
        }
    }
}