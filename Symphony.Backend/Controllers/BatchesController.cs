using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.BatchServices;
using Symphony.Services.BackendServices.CourseServices;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly IBatchService _service;

        public BatchesController(IBatchService service)
        {
            _service = service;
        }

        // GET: api/<BatchesController>
        [HttpGet("get-all-batches")]
        public async Task<ActionResult<IEnumerable<BatchVM>>> Get()
        {
            return Ok(await _service.GetBatchesVMsAsync());
        }

        // GET api/<BatchesController>/5
        [HttpGet("get-batch-by-id/{id}")]
        public async Task<ActionResult<BatchVM>> Get(int id)
        {
            var _batcch = await _service.GetBatchVMAsync(id);
            if (_batcch is null) return NotFound();
            return Ok(_batcch);
        }

        // POST api/<BatchesController>
        [HttpPost("create-batch")]
        public async Task<ActionResult<BatchVM>> Post(BatchCreateRequest request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            var _batch = new BatchVM();
            if (ModelState.IsValid)
            {
                _batch = await _service.CreateBatchAsync(request);
            }

            return CreatedAtAction(nameof(Get), new { id = _batch.Id }, _batch);
        }

        // PUT api/<BatchesController>/5
        [HttpPut("update-batch-details")]
        public async Task<ActionResult> Put(BatchUpdateRequest request)
        {
            if (request is null) return BadRequest();
            int result = await _service.UpdateBatchAsync(request);
            return NoContent();
        }

        // DELETE api/<BatchesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}