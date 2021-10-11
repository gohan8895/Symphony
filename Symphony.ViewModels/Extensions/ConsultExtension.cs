using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class ConsultExtension
    {
        public static ConsultVM AsConsultVM(this ConsultRegistration registration)
        {
            return new ConsultVM
            {
                Id = registration.Id,
                FullName = registration.FullName,
                Phone = registration.Phone,
                Email = registration.Email,
                CreatedAt = registration.CreatedAt,
                Message = registration.Message,
                IsContacted = registration.IsContacted ? "Yes" : "No"
            };
        }
    }
}