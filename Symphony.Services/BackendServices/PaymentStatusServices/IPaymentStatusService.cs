using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.PaymentStatusServices
{
    public interface IPaymentStatusService
    {
        Task<IEnumerable<PaymentStatusVM>> GetAllPaymentStatusAsync();

        Task<PaymentStatusVM> GetPaymentStatusAsync(int courseRegistrationId);

        Task<PaymentStatusVM> CreatePaymentStatusAsync(int courseRegistrationId, double amount);

        Task<PaymentStatusVM> UpdatePaymentStatusAsync(int courseRegistrationId, bool courseRegisIsApproved);

        Task<PaymentStatusVM> DeletePaymentStatusAsync(int id);
    }
}