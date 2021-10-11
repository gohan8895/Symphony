using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.Student_AnswerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student_AnswersCOntroller : ControllerBase
    {
        private readonly IStudent_AnswerService _service;

        public Student_AnswersCOntroller(IStudent_AnswerService service)
        {
            _service = service;
        }

        // GET: api/<Student_AnswersCOntroller>
        [HttpGet("get-student_answer-per_exam")]
        public async Task<ActionResult<IEnumerable<Student_AnswerVM>>> Get(Guid studentId, int examId)
        {
            return Ok(await _service.GetStudent_AnswerVMAsync(studentId, examId));
        }

        // GET api/<Student_AnswersCOntroller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Student_AnswersCOntroller>
        [HttpPost("submit-exam_results")]
        public async Task<ActionResult<IEnumerable<Student_AnswerVM>>> Post(Student_AnswerCreateRequest request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            //var _studentAnswers = new List<Student_AnswerVM>();
            if (ModelState.IsValid)
            {
                var _studentAnswers = await _service.CreateStudent_AnswerVMAsync(request);
                return CreatedAtAction(nameof(Get), new { studentId = request.UserId, examId = request.ExamId }, _studentAnswers);
            }
            else return BadRequest();
        }

        // PUT api/<Student_AnswersCOntroller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Student_AnswersCOntroller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}