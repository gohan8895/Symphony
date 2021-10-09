using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.AboutServices;
using Symphony.Services.BackendServices.SubjectServices;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [HttpGet("get-all-subjects")]
        public async Task<ActionResult<IEnumerable<SubjectVM>>> Get()
        {
            return Ok(await _service.GetSubjectVMsAsync());
        }

        // GET api/<SubjectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectVM>> Get(int id)
        {
            var _subject = await _service.GetSubjectVMAsync(id);

            if (_subject is null) return NotFound();

            return Ok(_subject);
        }

        // POST api/<SubjectsController>
        [HttpPost]
        public async Task<ActionResult<SimpleSubjectVM>> Post(SubjectCreateRequest createRequest)
        {
            if (createRequest is null)
            {
                return BadRequest();
            }

            var _subject = new SimpleSubjectVM();

            if (ModelState.IsValid)
            {
                _subject = await _service.CreateSubjectVMAsync(createRequest);
            }

            return CreatedAtAction(nameof(Get), new { id = _subject.Id }, _subject);
        }

        // PUT api/<SubjectsController>/5
        [HttpPut("update-subject-details")]
        public async Task<ActionResult> Put(SubjectUpdateRequest updateRequest)
        {
            if (updateRequest is null) return BadRequest();

            var _subjectVM = new SimpleSubjectVM();

            if (ModelState.IsValid)
            {
                _subjectVM = await _service.UpdateSubjectVMAsync(updateRequest);
            }

            if (_subjectVM is null) return NotFound();

            return NoContent();
        }

        [HttpPut("update-subject-images/{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] List<IFormFile> images)
        {
            if (images is null) return BadRequest();

            var subjectVM = new SimpleSubjectVM();

            if (ModelState.IsValid) subjectVM = await _service.UpdateSubjectImageVMAsync(id, images);

            if (subjectVM is null) return NotFound();

            return NoContent();
        }
        
        [HttpPut("update-subject-files/{id}")]
        public async Task<ActionResult> PutFiles(int id, [FromForm] List<IFormFile> files)
        {
            if (files is null) return BadRequest();

            var subjectVM = new SimpleSubjectVM();

            if (ModelState.IsValid) subjectVM = await _service.UpdateSubjectFileVMAsync(id, files);

            if (subjectVM is null) return NotFound();

            return NoContent();
        }

        // DELETE api/<SubjectsController>/5
        [HttpPut("update-subject-state/{id}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var _subject = await _service.GetSubjectVMAsync(id);
            if (_subject is null) return NotFound();
            await _service.ChangeSubjectState(id);
            return NoContent();
        }
    }
}