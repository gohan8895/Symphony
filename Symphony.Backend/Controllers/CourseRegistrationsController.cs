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

        public CourseRegistrationsController(ICourseRegistrationService courseRegistrationService) => this.courseRegistrationService = courseRegistrationService;

        [HttpGet("get-all-course-registration")]
        public async Task<ActionResult<CourseRegistrationVM>> GetAllCourseRegistration()
        {
            var result = await courseRegistrationService.GetAllCourseRegistrationVMsAsync();
            return Ok(result);
        }
        [HttpGet("get-all-course-registrations-with-data")]
        public async Task<ActionResult<CourseRegistrationWithDataVM>> GetAllCourseRegistrationWithDatas()
        {
            return Ok(await courseRegistrationService.GetCourseRegistrationWithDataVMsAsync());
        }

        // GET api/<CourseRegistrationsController>/5
        [HttpGet("get-course-registration-by-id/{id}")]
        public async Task<ActionResult<CourseRegistrationVM>> GetCourseRegistration(int id)
        {
            var result = await courseRegistrationService.GetCourseRegistrationVMAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<CourseRegistrationsController>
        [HttpPost("create-course-registration")]
        public async Task<ActionResult<CourseRegistrationWithDataVM>> CreateCourseRegistration([FromBody] CreateCourseRegistrationVM createCourseRegistrationVM)
        {
            if (createCourseRegistrationVM is null)
            {
                return BadRequest();
            }
            var courseRegisVM = new CourseRegistrationWithDataVM();
            if (ModelState.IsValid)
            {
                courseRegisVM = await courseRegistrationService.CreateCourseRegistrationAsync(createCourseRegistrationVM);
            }

            return CreatedAtAction(nameof(GetCourseRegistration), new { id = courseRegisVM.Id }, courseRegisVM);
        }


        // PUT api/<CourseRegistrationsController>/5
        [HttpPut("approve-course-registration/{courseRegistrationId}")]
        public async Task<ActionResult> UpdateCourseRegistration(int courseRegistrationId)

        {
            var result = await courseRegistrationService.UpdateCourseRegistrationAsync(courseRegistrationId);
            if (result is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CourseRegistrationsController>/5
        [HttpDelete("delete-course-registration/{id}")]
        public async Task<ActionResult> DeleteCourseRegistrationAsync(int id)
        {
            var result = await courseRegistrationService.DeleteCourseRegistrationAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}