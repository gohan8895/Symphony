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

namespace Symphony.Services.BackendServices.PaymentStatusServices
{
    public class PaymentStatusService : IPaymentStatusService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public PaymentStatusService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<IEnumerable<PaymentStatusVM>> GetAllPaymentStatusAsync()
        {
            var result = await symphonyDBContext.PaymentStatuses.Select(a => a.AsVM()).ToListAsync();
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<PaymentStatusWithData> GetPaymentStatusAsync(int courseID)
        {
            var result = await symphonyDBContext
                .PaymentStatuses
                .Include(p => p.CourseRegistration)
                .Select(p => new PaymentStatusWithData { 
                    Id = p.Id,
                    CourseRegistrationId = p.CourseRegistrationId,
                    Amount = p.Amount,
                    HasPaid = p.HasPaid,
                    CreatedAt=  p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    CourseRegistrationVM = p.CourseRegistration.AsVM()
                })
                .FirstOrDefaultAsync(a => a.CourseRegistrationId == courseID);

            if (result is null)
            {
                return null;
            }

            return result;
        }


        public async Task<PaymentStatusVM> CreatePaymentStatusAsync(int courseRegistrationId, double amount)
        {
            var paymentStatus = new PaymentStatus()
            {
                CourseRegistrationId = courseRegistrationId,
                Amount = amount,
                HasPaid = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await symphonyDBContext.PaymentStatuses.AddAsync(paymentStatus);
            await symphonyDBContext.SaveChangesAsync();
            return paymentStatus.AsVM();
        }

        public async Task<PaymentStatusVM> UpdatePaymentStatusAsync(int courseRegistrationId, bool courseRegisIsApproved)
        {
            var paymentStatus = await symphonyDBContext.PaymentStatuses.FirstOrDefaultAsync(a => a.CourseRegistrationId == courseRegistrationId);
            if (paymentStatus is null)
            {
                return null;
            }

            if (courseRegisIsApproved is true) paymentStatus.HasPaid = true;
            else paymentStatus.HasPaid = false;

            paymentStatus.UpdatedAt = DateTime.Now;
            await symphonyDBContext.SaveChangesAsync();
            return paymentStatus.AsVM();
        }

        public async Task<PaymentStatusVM> DeletePaymentStatusAsync(int id)
        {
            var result = await symphonyDBContext.PaymentStatuses.FirstOrDefaultAsync(a => a.Id == id);
            if (result is null)
            {
                return null;
            }
            symphonyDBContext.PaymentStatuses.Remove(result);
            await symphonyDBContext.SaveChangesAsync();
            return result.AsVM();
        }
    }
}