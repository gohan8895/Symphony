using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.PaymentStatusServices
{
    public interface IPaymentStatusService
    {
        Task<IEnumerable<PaymentStatusVM>> GetAllPaymentStatusAsync();

        Task<PaymentStatusWithData> GetPaymentStatusAsync(int courseRegistrationId);

        Task<PaymentStatusVM> CreatePaymentStatusAsync(int courseRegistrationId, double amount);

        Task<PaymentStatusVM> UpdatePaymentStatusAsync(int courseRegistrationId, bool courseRegisIsApproved);

        Task<PaymentStatusVM> DeletePaymentStatusAsync(int id);
    }
}