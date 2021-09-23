using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.AboutServices
{
    public interface IAboutService
    {
        Task<AboutVM> GetAboutVMAsync(int id);
        Task<IEnumerable<AboutVM>> GetAboutVMsAsync();
        Task<AboutVM> CreateAboutAsync(CreateAboutVM aboutVM);
        Task<AboutVM> UpdateAboutAsync(UpdateAboutVM aboutVM);
        Task DeleteAboutAsync(int id);
    }
}
