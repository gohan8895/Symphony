using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.EventServices
{
    public interface IEventService
    {
        Task<EventVM> GetEventVMAsync(int id);
        Task<IEnumerable<EventVM>> GetEventVMsAsync();
        Task<EventVM> CreateEventAsync(CreateEventVM eventVM);
        Task<EventVM> UpdateEventAsync(UpdateEventVM eventVM);
        Task DeleteEventAsync(int id);
    }
}
