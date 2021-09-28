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
        public IActionResult GetAllCourseRegistration()
        {
            var result = courseRegistrationService.GetAllCourseRegistrations();
            return Ok(result);
        }

        [HttpGet("courseregistrations/get-course-registration-with-data")]
        public IActionResult GetAllCourseRegistrationWithDatas()
        {
            return Ok(courseRegistrationService.GetCourseRegistrationWithDatasVM());
        }


        // GET api/<CourseRegistrationsController>/5
        [HttpGet("{courseRegisId}")]
        public ActionResult<CourseRegistrationVM> GetCourseRegistration(int courseRegisId)
        {

            var result = courseRegistrationService.GetCourseRegistrationVM(courseRegisId);
            if (result == null)
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
                courseRegisVM = await courseRegistrationService.CreateCourseRegistration(createCourseRegistrationVM);
            }


            return CreatedAtAction(nameof(GetCourseRegistration), new { Id = courseRegisVM.Id }, courseRegisVM);

        }

        // PUT api/<CourseRegistrationsController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateCourseRegistration([FromBody] UpdateCourseRegistrationVM courseRegistrationVM)
        {
            var result = await courseRegistrationService.UpdateCourseRegistration(courseRegistrationVM);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CourseRegistrationsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourseRegistration(int id)
        {
            var result = courseRegistrationService.DeleteCourseRegistration(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
