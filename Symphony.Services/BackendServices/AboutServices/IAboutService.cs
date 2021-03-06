using System.Collections.Generic;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.AboutServices
{
    public interface IAboutService
    {
        Task<AboutVM> GetAboutVMAsync(int id);
        Task<IEnumerable<AboutVM>> GetAboutVMsAsync();
        Task<AboutVM> CreateAboutAsync(CreateAboutVM aboutVM);
        Task<AboutVM> UpdateAboutAsync(UpdateAboutVM aboutVM);
        Task<AboutVM> DeleteAboutAsync(int id);
    }
}
