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

namespace Symphony.Services.BackendServices.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public NewsService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }


        public async Task<NewsVM> GetNewsVMAsync(int id)
        {
            var news = await symphonyDBContext.News.FirstOrDefaultAsync(a => a.Id == id);

            if (news is null) return null;

            return news.AsVM();
        }


        public async Task<IEnumerable<NewsVM>> GetNewsVMsAsync() => await symphonyDBContext.News.Select(a => a.AsVM()).ToListAsync();


        public async Task<NewsVM> CreateNewsAsync(CreateNewsVM NewsVM)
        {
            var news = new News { Title = NewsVM.Title, Description = NewsVM.Description, IsShown = NewsVM.IsShown };

            await symphonyDBContext.News.AddAsync(news);
            await symphonyDBContext.SaveChangesAsync();

            return news.AsVM();
        }

        public async Task<NewsVM> UpdateNewsAsync(UpdateNewsVM NewsVM)
        {
            var news = await symphonyDBContext.News.FirstOrDefaultAsync(a => a.Id == NewsVM.Id);

            if (news is null) return null;

            news.Title = NewsVM.Title;
            news.Description = NewsVM.Description;
            news.IsShown = NewsVM.IsShown;

            await symphonyDBContext.SaveChangesAsync();

            return news.AsVM();
        }


        // AboutServices.AboutService
        public async Task DeleteNewsAsync(int id)
        {

            var news = await symphonyDBContext.News.FirstOrDefaultAsync(a => a.Id == id);

            symphonyDBContext.News.Remove(news);
            await symphonyDBContext.SaveChangesAsync();
        }
    }
}
