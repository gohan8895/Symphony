using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class AboutExtension
    {
        public static AboutVM AsVM(this About about) => new AboutVM
        {
            Id = about.Id,
            Title = about.Title,
            Content = about.Content,
            IsShown = about.IsShown
        };
    }
}
