using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.NewsServices
{
    
  public  interface INewsService
    {
        Task<NewsVM> GetNewsVMAsync(int id);
        Task<IEnumerable<NewsVM>> GetNewssVMsAsync();
        Task<NewsVM> CreateNewsAsync(CreateNewsVM NewsVM);
        Task<NewsVM> UpdateNewsAsync(UpdateNewsVM NewsVM);
        Task DeleteNewsAsync(int id);
    }
}
