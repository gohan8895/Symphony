using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
   public static class NewsExtension
    {
        public static NewsVM AsVM(this News news) => new NewsVM
        {
            Id = news.Id,
            Title = news.Title,
            Description = news.Description,
            IsShown = news.IsShown,
            CreatedAt = news.CreatedAt,
            UpdatedAt = news.UpdatedAt
        };
    }
}
           
            
