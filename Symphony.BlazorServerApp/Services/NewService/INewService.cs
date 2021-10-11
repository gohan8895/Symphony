using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.NewService
{
    public interface INewService
    {
        Task<IEnumerable<NewsVM>> GetNewsAsync();
        Task<NewsVM> GetNewAsync(int id);
        Task CreateAsync(CreateNewsVM news);
        Task UpdateAsync(UpdateNewsVM news);
        Task DeleteAsync(int id);
    }
}
