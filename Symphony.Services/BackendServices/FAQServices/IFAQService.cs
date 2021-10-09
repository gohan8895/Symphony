
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.FAQServices
{
    public interface IFAQService
    {
        Task<FAQVM> GetFAQVMAsync(int id);
        Task<IEnumerable<FAQVM>> GetFAQVMsAsync();
        Task<FAQVM> CreateFAQAsync(CreateFAQVM faqVM);
        Task<FAQVM> UpdateFAQAsync(UpdateFAQVM faqVM);
        Task DeleteFAQAsync(int id);
    }
}
