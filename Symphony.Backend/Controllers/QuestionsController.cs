using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.QuestionServices;
using Symphony.Services.BackendServices.SubjectServices;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        // GET: api/<QuestionsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestionsController>
        [HttpPost("create-quesstion")]
        public async Task<ActionResult<QuestionVM>> Post(QuestionCreateRequest request)
        {
            if (request is null) return BadRequest();
            var _question = new QuestionVM();
            if (ModelState.IsValid)
            {
                _question = await _service.CreateQuestionAsync(request);
            }
            return CreatedAtAction(nameof(Get), new { id = _question.Id }, _question);
        }

        // PUT api/<QuestionsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<QuestionsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}