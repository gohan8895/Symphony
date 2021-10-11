using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.EventServices
{
   public interface IEventService
    {
        Task<IEnumerable<EventVM>> GetEventsAsync();
        Task<EventVM> GetEventAsync(int id);
        Task CreateEventAsync(CreateEventVM item);
        Task UpdateEventAsync(UpdateEventVM item);
        Task DeleteEventAsync(int id);
    }
}
