using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.SubjectServices;
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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectsController(ISubjectService service)
        {
            _service = service;
        }

        // GET: api/<SubjectsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SubjectsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubjectsController>
        [HttpPost]
        public async Task<ActionResult<SubjectVM>> Post([FromForm] SubjectCreateRequest createRequest)
        {
            if (createRequest is null)
            {
                return BadRequest();
            }

            var subjectVM = new SubjectVM();
            if (ModelState.IsValid)
            {
                var _subjectVM = await _service.CreateSubjectVMAsync(createRequest);
            }

            return Ok(subjectVM);
        }

        // PUT api/<SubjectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}