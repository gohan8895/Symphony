using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class EventExtension
    {
        public static EventVM EvsVM(this Event ev) => new EventVM
        {
            Id = ev.Id,
            Title = ev.Title,
            Description = ev.Description,
            CreatedAt = ev.CreatedAt,
            UpdatedAt = ev.UpdatedAt,
            IsShown = ev.IsShown,
        };
    }
}
