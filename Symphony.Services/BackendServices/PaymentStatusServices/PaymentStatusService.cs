using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.PaymentStatusServices
{
    class PaymentStatusService : IPaymentStatusService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public PaymentStatusService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<PaymentStatusVM> CreatePaymentStatusAsync(CreatePaymentStatusVM createPaymentStatusVM)
        {
            var paymentStatus = new PaymentStatus()
            {
                CourseRegistrationId = createPaymentStatusVM.CourseRegistrationId,
                Amount = createPaymentStatusVM.Amount,
                HasPaid = createPaymentStatusVM.HasPaid,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await symphonyDBContext.PaymentStatuses.AddAsync(paymentStatus);
            await symphonyDBContext.SaveChangesAsync();
            return paymentStatus.AsVM();
        }


        public async Task<PaymentStatusVM> DeletePaymentStatusAsync(int id)
        {
            var result = await symphonyDBContext.PaymentStatuses.FirstOrDefaultAsync(a => a.Id == id);
            if(result is null)
            {
                return null;
            }
             symphonyDBContext.PaymentStatuses.Remove(result);
            await symphonyDBContext.SaveChangesAsync();
            return result.AsVM();
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

        public async Task<PaymentStatusVM> GetPaymentStatusAsync(int paymentStatusId)
        {
            var result = await symphonyDBContext.PaymentStatuses.FirstOrDefaultAsync(a => a.Id == paymentStatusId);
            if(result is null)
            {
                return null;
            }
            return result.AsVM();
        }

        public async Task<PaymentStatusVM> UpdatePaymentStatusAsync(UpdatePaymentStatusVM updatePaymentStatusVM)
        {
            var paymentStatus = await symphonyDBContext.PaymentStatuses.FirstOrDefaultAsync(a => a.Id == updatePaymentStatusVM.Id);
            if (paymentStatus is null)
            {
                return null;
            }
            paymentStatus.CourseRegistrationId = updatePaymentStatusVM.CourseRegistrationId;
            paymentStatus.Amount = updatePaymentStatusVM.Amount;
            paymentStatus.HasPaid = updatePaymentStatusVM.HasPaid;
            paymentStatus.UpdatedAt = DateTime.Now;
            await symphonyDBContext.SaveChangesAsync();
            return paymentStatus.AsVM();

        }

    }
}
