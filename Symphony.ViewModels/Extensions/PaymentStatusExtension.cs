using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
     
   public static class PaymentStatusExtension
    {
        public static PaymentStatusVM AsVM(this PaymentStatus paymentStatus) => new PaymentStatusVM
        {
            Id = paymentStatus.Id,
            CourseRegistrationId = paymentStatus.CourseRegistrationId,
            Amount = paymentStatus.Amount,
            HasPaid = paymentStatus.HasPaid,
            CreatedAt = DateTime.Now,
            UpdatedAt = paymentStatus.UpdatedAt

        }; 
    }
}
