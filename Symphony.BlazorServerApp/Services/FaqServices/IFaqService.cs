using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.FaqServices
{
    public interface IFaqService
    {
        Task<IEnumerable<FAQVM>> GetFaqsAsync();
        Task<FAQVM> GetFaqAsync(int id);
        Task CreateFaqAsync(CreateFAQVM faq);
        Task UpdateFaqAsync(UpdateFAQVM faq);
        Task DeleteFaqAsync(int id);
    }
}
