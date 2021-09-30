using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.AboutServices;
using Symphony.Services.BackendServices.ExamRegistrationServices;
using Symphony.Services.BackendServices.ExamServices;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.ExamRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamRegistrationsController : ControllerBase
    {
        private readonly IExamRegistrationService _service;

        public ExamRegistrationsController(IExamRegistrationService service)
        {
            _service = service;
        }

        // GET: api/<ExamRegistrationsController>
        [HttpGet("get-all-exam-registrations")]
        public async Task<ActionResult<IEnumerable<ExamRegistrationVM>>> Get()
        {
            return Ok(await _service.GetExamRegistrationsAsync());
        }

        // GET api/<ExamRegistrationsController>/5
        [HttpGet("get-exam-registration-by-examid/{examId}")]
        public async Task<ActionResult<IEnumerable<ExamRegistrationVM>>> Get(int examId)
        {
            return Ok(await _service.GetExamRegistrationbyExamIdAsync(examId));
        }

        // POST api/<ExamRegistrationsController>
        [HttpPost("create-exam-registration")]
        public async Task<ActionResult<IEnumerable<ExamRegistrationVM>>> Post([FromForm] ExamRegistrationCreateRequest request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var _regis = await _service.CreateExamRegistrationAsync(request);
                if (_regis is null) return BadRequest("Excel is valid or Exam Id already exists");
                return CreatedAtAction(nameof(Get), new { examId = request.ExamId }, _regis);
            }
            return BadRequest();
        }

        // PUT api/<ExamRegistrationsController>/5
        // PUT api/<ExamsController>/5
        [HttpPut("update-exam-registration-list")]
        public async Task<ActionResult> Put([FromForm] ExamRegistrationUpdateRequest request)
        {
            if (request is null) return BadRequest();
            int result = await _service.UpdateExamRegistraion(request);
            return NoContent();
        }

        // DELETE api/<ExamRegistrationsController>/5
        [HttpDelete("{examId}")]
        public async Task<ActionResult> DeleteAsync(int examId)
        {
            var _regis = await _service.GetExamRegistrationbyExamIdAsync(examId);
            if (_regis is null) return NotFound();

            await _service.DeleteExamRegistraionAsync(examId);

            return NoContent();
        }
    }
}