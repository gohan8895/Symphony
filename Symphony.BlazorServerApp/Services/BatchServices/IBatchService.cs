using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.BatchServices
{
    public interface IBatchService
    {
        Task<BatchVM> GetBatchVMAsync(int id);

        Task<IEnumerable<BatchVM>> GetBatchesVMsAsync();

        Task<int> CreateAsync(BatchCreateRequest request);

        Task<int> UpdateAsync(BatchUpdateRequest request);
    }
}
