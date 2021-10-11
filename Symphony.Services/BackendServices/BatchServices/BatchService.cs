using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.BatchServices
{
    public class BatchService : IBatchService
    {
        private readonly SymphonyDBContext _context;

        public BatchService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatchVM>> GetBatchesVMsAsync()
        {
            var _batches = await _context.Batches
                            .Select(x => x.AsVM())
                            .ToListAsync();
            return _batches;
        }

        public async Task<BatchVM> GetBatchVMAsync(int id)
        {
            var _batch = await _context.Batches
                            .FirstOrDefaultAsync(x => x.Id == id);

            if (_batch is null)
            {
                throw new Exception(@"Batch id: {id} is not found");
            }
            return _batch.AsVM();
        }

        public async Task<BatchVM> CreateBatchAsync(BatchCreateRequest request)
        {
            var _batch = new Batch()
            {
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CreatedAt = DateTime.Now
            };

            await _context.Batches.AddAsync(_batch);
            await _context.SaveChangesAsync();

            return _batch.AsVM();
        }

        public async Task<int> UpdateBatchAsync(BatchUpdateRequest request)
        {
            var _batch = await _context.Batches.FirstOrDefaultAsync(x => x.Id == request.Id);
            _batch.Description = request.Description;
            _batch.StartDate = request.StartDate;
            _batch.EndDate = request.EndDate;

            return await _context.SaveChangesAsync();
        }
    }
}