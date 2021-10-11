using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class FAQExtension
    {
        public static FAQVM AsVM(this FAQ faq) => new FAQVM
        {
            Id = faq.Id,
            Question = faq.Question,
            Answer = faq.Answer,
            IsShown = faq.IsShown,
            CreatedAt = faq.CreatedAt,
            UpdatedAt=faq.UpdatedAt
        };
    }
}
