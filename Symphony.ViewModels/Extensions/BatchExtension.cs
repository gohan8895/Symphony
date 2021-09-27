using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class BatchExtension
    {
        public static BatchVM AsVM(this Batch batch) => new BatchVM
        {
            Id = batch.Id,
            Description = batch.Description,
            StartDate = batch.StartDate,
            EndDate = batch.EndDate
        };
    }
}