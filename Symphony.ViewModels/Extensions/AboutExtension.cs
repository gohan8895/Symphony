using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class AboutExtension
    {
        public static AboutVM AsVM(this About about) => new AboutVM
        {
            Id = about.Id,
            Content = about.Content,
            IsShown = about.IsShown
        };
    }
}
