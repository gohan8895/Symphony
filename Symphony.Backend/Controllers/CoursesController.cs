using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.CourseServices;
using Symphony.Services.BackendServices.SubjectServices;
using Symphony.ViewModels.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;

        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        // GET: api/<CoursesController>
        [HttpGet("get-all-courses-with-subjects")]
        public async Task<ActionResult<IEnumerable<CourseWithSubjects>>> Get()
        {
            return Ok(await _service.GetCoursesWithSubjectsAsync());
        }

        // GET api/<CoursesController>/5
        [HttpGet("get-course-by-id/{id}")]
        public async Task<ActionResult<CourseWithSubjects>> Get(int id)
        {
            var _course = await _service.GetCourseWithSubjectsAsync(id);
            if (_course is null) return NotFound();
            return Ok(_course);
        }

        // Get api/<CoursesController>/update-course-status/5
        [HttpGet("update-course-status/{id}")]
        public async Task<ActionResult> UpdateCourseState(int id)
        {
            var result = await _service.UpdateCourseStatus(id);

            if (result == 0) return NotFound();

            return NoContent();
        }

        // POST api/<CoursesController>
        [HttpPost("create-course-with-subjects")]
        public async Task<ActionResult<CourseWithSubjects>> Post([FromForm]CourseCreateRequest request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            var _course = new CourseWithSubjects();
            if (ModelState.IsValid)
            {
                _course = await _service.CreateCourseAsync(request);
            }

            return CreatedAtAction(nameof(Get), new { id = _course.Id }, _course);
        }

        // PUT api/<CoursesController>/update-course-details/5
        [HttpPut("update-course-details")]
        public async Task<ActionResult> Put([FromForm]CourseUpdateRequest request)
        {
            if (request is null) return BadRequest();

            int result = await _service.UpdateCourseDetails(request);

            if (result == 0) return NotFound();

            return NoContent();
        }

        // PUT api/<CoursesController>/update-course-image/5
        [HttpPut("update-course-image/{id}")]
        public async Task<ActionResult> Put(int id, IFormFile image)
        {
            if (id == 0 || image is null) return BadRequest();

            var result = await _service.UpdateCourseImageAsync(id, image);

            if (result == 0) return NotFound();

            return NoContent();
        }

        // PUT api/<CoursesController>/update-subjects-in-course/5
        [HttpPut("update-subjects-in-course/{id}")]
        public async Task<ActionResult> UpdateSubjectInCourse(int id, List<int> subjectIds)
        {
            var result = await _service.UpdateSubjectInCourse(id, subjectIds);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}