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

namespace Symphony.Services.BackendServices.EventServices
{
    public class EventService : IEventService
    {
        private readonly SymphonyDBContext symphonyDBContext;

        public EventService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }

        public async Task<EventVM> GetEventVMAsync(int id)
        {
            var ev = await symphonyDBContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (ev is null) return null;
            return ev.EvsVM();
        }

        public async Task<IEnumerable<EventVM>> GetEventVMsAsync()
        {
            var evs = await symphonyDBContext.Events.Select(e => e.EvsVM()).ToListAsync();
            return evs;
        }
        public async Task<EventVM> CreateEventAsync(CreateEventVM eventVM)
        {
            var ev = new Event
            {
                Title = eventVM.Title,
                Description = eventVM.Description,
                IsShown = eventVM.IsShown,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await symphonyDBContext.Events.AddAsync(ev);
            await symphonyDBContext.SaveChangesAsync();

            return ev.EvsVM();
        }
        public async Task<EventVM> UpdateEventAsync(UpdateEventVM eventVM)
        {
            var ev = await symphonyDBContext.Events.FirstOrDefaultAsync(e => e.Id == eventVM.Id);
            if (ev is null) return null;

            ev.Title = eventVM.Title;
            ev.Description = eventVM.Description;
            ev.IsShown = eventVM.IsShown;
            ev.UpdatedAt = DateTime.Now;

            await symphonyDBContext.SaveChangesAsync();
            return ev.EvsVM();
        }

        public async Task DeleteEventAsync(int id)
        {
            var ev = await symphonyDBContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            symphonyDBContext.Events.Remove(ev);
            await symphonyDBContext.SaveChangesAsync();
        }
    }
}
