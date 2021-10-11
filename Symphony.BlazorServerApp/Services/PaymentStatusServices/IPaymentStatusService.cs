using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.PaymentStatusServices
{
    public interface IPaymentStatusService
    {
        Task<IEnumerable<PaymentStatusVM>> GetAllPaymentStatusAsync();

        Task<PaymentStatusWithData> GetPaymentStatusAsync(int courseRegistrationId);

        Task<int> DeletePaymentStatusAsync(int id);
    }
}