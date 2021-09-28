using Microsoft.AspNetCore.Mvc;
using Symphony.Data.Entities;
using Symphony.Services.BackendServices.CourseRegistrationServices;
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
    public class CourseRegistrationsController : ControllerBase
    {
        //  AboutsController
        // GET: api/<CourseRegistrationsController>

        private readonly ICourseRegistrationService courseRegistrationService;

        public CourseRegistrationsController(ICourseRegistrationService courseRegistrationService)
        {
            this.courseRegistrationService = courseRegistrationService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseRegistrationVM>>> GetAllCourseRegistration()
        {
            var result = await courseRegistrationService.GetAllCourseRegistrationsAsync();
            return Ok(result);
        }

        [HttpGet("courseregistrations/get-course-registration-with-data")]
        public async Task<ActionResult<IEnumerable<CourseRegistrationWithData>>> GetAllCourseRegistrationWithDatas()
        {
            var result = await courseRegistrationService.GetCourseRegistrationWithDatasVMAsync();
            return Ok(result);
        }


        // GET api/<CourseRegistrationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseRegistrationVM>> GetCourseRegistration(int id)
        {

            var result = await courseRegistrationService.GetCourseRegistrationVMAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<CourseRegistrationsController>
        [HttpPost]
        public async Task<ActionResult<CourseRegistrationVM>> CreateCourseRegistration([FromBody] CreateCourseRegistrationVM createCourseRegistrationVM)
        {
            if (createCourseRegistrationVM is null)
            {
                return BadRequest();
            }
            var courseRegisVM = new CourseRegistrationVM();
            if (ModelState.IsValid)
            {
                courseRegisVM = await courseRegistrationService.CreateCourseRegistrationAsync(createCourseRegistrationVM);
            }


            return CreatedAtAction(nameof(GetCourseRegistration), new { Id = courseRegisVM.Id }, courseRegisVM);

        }

        // PUT api/<CourseRegistrationsController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateCourseRegistration([FromBody] UpdateCourseRegistrationVM courseRegistrationVM)
        {
            var result = await courseRegistrationService.UpdateCourseRegistrationAsync(courseRegistrationVM);
            if (result is null )
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CourseRegistrationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseRegistration(int id)
        {
            var result = await courseRegistrationService.DeleteCourseRegistrationAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
