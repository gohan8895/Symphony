using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.BatchServices
{
    public interface IBatchService
    {
        Task<BatchVM> GetBatchVMAsync(int id);

        Task<IEnumerable<BatchVM>> GetBatchesVMsAsync();

        Task<BatchVM> CreateBatchAsync(BatchCreateRequest request);

        Task<int> UpdateBatchAsync(BatchUpdateRequest request);
    }
}