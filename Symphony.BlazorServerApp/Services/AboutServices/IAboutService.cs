using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.AboutServices
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutVM>> GetAboutsAsync();
        Task<AboutVM> GetAboutAsync(int id);
        Task CreateAsync(CreateAboutVM about);
        Task UpdateAsync(UpdateAboutVM about);
        Task DeleteAsync(int id);
    }
}
