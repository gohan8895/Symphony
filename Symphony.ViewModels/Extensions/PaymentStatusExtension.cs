using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

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
            CreatedAt = paymentStatus.CreatedAt,
            UpdatedAt = paymentStatus.UpdatedAt
        }; 
    }
}
