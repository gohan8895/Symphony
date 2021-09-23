using Microsoft.AspNetCore.Mvc;
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

namespace Symphony.Services.BackendServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public AboutService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<AboutVM> GetAboutVMAsync(int id)
        {
            var about = await symphonyDBContext.Abouts.FirstOrDefaultAsync(a => a.Id == id);

            if (about is null) return null;

            return about.AsVM();
        }

        public async Task<IEnumerable<AboutVM>> GetAboutVMsAsync()
        {
            var abouts = await symphonyDBContext.Abouts.Select(a => a.AsVM()).ToListAsync();

            return abouts;
        }

        public async Task<AboutVM> CreateAboutAsync(CreateAboutVM aboutVM)
        {
            var about = new About { Content = aboutVM.Content, IsShown = aboutVM.IsShown };

            await symphonyDBContext.Abouts.AddAsync(about);
            await symphonyDBContext.SaveChangesAsync();

            return about.AsVM();
        }

        public async Task<AboutVM> UpdateAboutAsync(UpdateAboutVM aboutVM)
        {
            var about = await symphonyDBContext.Abouts.FirstOrDefaultAsync(a => a.Id == aboutVM.Id);

            if (about is null) return null;

            about.Content = aboutVM.Content;
            about.IsShown = aboutVM.IsShown;

            await symphonyDBContext.SaveChangesAsync();

            return about.AsVM();
        }

        public async Task DeleteAboutAsync(int id)
        {
            var about = await symphonyDBContext.Abouts.FirstOrDefaultAsync(a => a.Id == id);

            symphonyDBContext.Abouts.Remove(about);
            await symphonyDBContext.SaveChangesAsync();
        }
    }
}
