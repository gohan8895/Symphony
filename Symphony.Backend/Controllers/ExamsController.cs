using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.ExamServices;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        // GET: api/<ExamsController>
        private readonly IExamService _service;

        public ExamsController(IExamService service)
        {
            _service = service;
        }

        [HttpGet("get-all-exams-with-questions")]
        public async Task<ActionResult<IEnumerable<CourseWithSubjects>>> Get()
        {
            return Ok(await _service.GetExamsAsync());
        }

        // GET api/<ExamsController>/5
        [HttpGet("get-exam-by-id/{id}")]
        public async Task<ActionResult<CourseWithSubjects>> Get(int id)
        {
            var _exam = await _service.GetExamAsync(id);
            if (_exam is null) return NotFound();
            return Ok(_exam);
        }

        // POST api/<ExamsController>

        [HttpPost("create-exam-with-questions")]
        public async Task<ActionResult<ExamVM>> Post([FromForm] ExamCreateRequest request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            var _exam = new ExamVM();
            if (ModelState.IsValid)
            {
                _exam = await _service.CreateExamAsync(request);
            }

            return CreatedAtAction(nameof(Get), new { id = _exam.Id }, _exam);
        }

        // PUT api/<ExamsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}