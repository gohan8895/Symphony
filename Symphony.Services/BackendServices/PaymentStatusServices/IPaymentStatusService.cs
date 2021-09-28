using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.PaymentStatusServices
{

    interface IPaymentStatusService
    {
         Task<IEnumerable<PaymentStatusVM>> GetAllPaymentStatusAsync();
        Task<PaymentStatusVM> GetPaymentStatusAsync(int paymentStatusId);
        Task<PaymentStatusVM> CreatePaymentStatusAsync(CreatePaymentStatusVM createPaymentStatusVM);
        Task<PaymentStatusVM> UpdatePaymentStatusAsync(UpdatePaymentStatusVM updatePaymentStatusVM);
        Task<PaymentStatusVM> DeletePaymentStatusAsync(int id);
    }
}
