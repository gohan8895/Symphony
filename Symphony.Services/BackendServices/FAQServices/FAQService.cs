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

namespace Symphony.Services.BackendServices.FAQServices
{
    public class FAQService : IFAQService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public FAQService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<FAQVM> GetFAQVMAsync(int id)
        {
            var faq = await symphonyDBContext.FAQs.FirstOrDefaultAsync(f => f.Id == id);
            
            if (faq is null) return null;

            return faq.AsVM();
        }
        public async Task<IEnumerable<FAQVM>> GetFAQVMsAsync()
        {
            var faqs = await symphonyDBContext.FAQs.Select(f=>f.AsVM()).ToListAsync();
            return faqs;
        }
        public async Task<FAQVM> CreateFAQAsync(CreateFAQVM faqVM)
        {
            var faq = new FAQ {
                Question = faqVM.Question,
                Answer = faqVM.Answer,
                IsShown = faqVM.IsShown,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await symphonyDBContext.FAQs.AddAsync(faq);
            await symphonyDBContext.SaveChangesAsync();

            return faq.AsVM();
        }
        public async Task<FAQVM> UpdateFAQAsync(UpdateFAQVM faqVM)
        {
            var faq = await symphonyDBContext.FAQs.FirstOrDefaultAsync(f => f.Id == faqVM.Id);

            if (faq is null) return null;

            faq.Question = faqVM.Question;
            faq.Answer = faqVM.Answer;
            faq.IsShown = faqVM.IsShown;
            faq.UpdatedAt = DateTime.Now;

            await symphonyDBContext.SaveChangesAsync();
            return faq.AsVM();
        }

        public async Task DeleteFAQAsync(int id)
        {
            var faq = await symphonyDBContext.FAQs.FirstOrDefaultAsync(f => f.Id == id);

            symphonyDBContext.FAQs.Remove(faq);

            await symphonyDBContext.SaveChangesAsync();
        }
    }
}
