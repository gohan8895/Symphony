using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.Exam_ResultServices;
using Symphony.ViewModels.Exam_ResultViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Exam_ResultsController : ControllerBase
    {
        private readonly IExam_ResultService _service;

        public Exam_ResultsController(IExam_ResultService service)
        {
            _service = service;
        }

        // GET: api/<Exam_ResultsController>
        [HttpGet("get-all-exam-results")]
        public async Task<ActionResult<IEnumerable<Exam_ResultVM>>> GetAll()
        {
            return Ok(await _service.GetAllExamResultAsync());
        }

        //GET api/<Exam_ResultsController>/5
        [HttpGet("get-all-exam-results-by-exam-id/{id}")]
        public async Task<ActionResult<IEnumerable<Exam_ResultVM>>> GetAllByExamId(int id)
        {
            return Ok(await _service.GetExamResultByExamIdAsync(id));
        }

        [HttpGet("get-all-exam-results-by-student-id/{id}")]
        public async Task<ActionResult<IEnumerable<Exam_ResultVM>>> GetAllByStudentId(Guid id)
        {
            return Ok(await _service.GetExamResultByStudentIdAsync(id));
        }

        // POST api/<Exam_ResultsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<Exam_ResultsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Exam_ResultsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}