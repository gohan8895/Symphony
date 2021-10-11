using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.EnrollmentServices;
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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        // GET: api/<EnrollmentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentVM>>> Get()
        {
            return Ok(await enrollmentService.GetEnrollmentVMsAsync());
        }

        // GET api/<EnrollmentsController>/student/5/course/10
        [HttpGet("student/{studentID}/course/{courseId}")]
        public async Task<ActionResult<EnrollmentVM>> Get(Guid studentID, int courseId)
        {
            var enrollment = await enrollmentService.GetEnrollmentVMAsync(studentID, courseId);
            if (enrollment is null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        // UPDATE Enrollemnt Status
        // update-enrollment-state/student/5/course/5
        [HttpGet("update-enrollment-state/student/{studentId}/course/{courseId}")]
        public async Task<ActionResult> ChangeStatus(Guid studentId, int courseId)
        {
            if (studentId == Guid.Empty || courseId == 0) return BadRequest();

            var enrollment = await enrollmentService.GetEnrollmentVMAsync(studentId, courseId);

            if (enrollment is null)
            {
                return NotFound();
            }

            var result = await enrollmentService.ChangeEnrollmentStatus(studentId, courseId);

            return result == 1 ? NoContent() : BadRequest();
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult<EnrollmentVM>> Post([FromBody] CreateEnrollmentVM createEnrollmentVM)
        {
            if (createEnrollmentVM is null)
            {
                return BadRequest();
            }
            var enrollmentVM = new EnrollmentVM();
            if (ModelState.IsValid)
            {
                enrollmentVM = await enrollmentService.CreateEnrollment(createEnrollmentVM);
            }

            return CreatedAtAction(nameof(Get), new { id = enrollmentVM.Id }, enrollmentVM);
        }

        // PUT api/<EnrollmentsController>/
        [HttpPut]
        public async Task<ActionResult<EnrollmentVM>> Put([FromBody] UpdateEnrollmentVM updateEnrollmentVM)
        {
            if (updateEnrollmentVM is null)
            {
                return BadRequest();
            }
            var enrollmentVM = new EnrollmentVM();
            if (ModelState.IsValid)
            {
                enrollmentVM = await enrollmentService.UpdateEnrollment(updateEnrollmentVM);
            }

            if (enrollmentVM is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("get-enrollments-with-user-and-course")]
        public async Task<ActionResult<EnrollmentWithData>> GetEnrollmentWithData()
        {
            return Ok(await enrollmentService.GetEnrollmentWithDataVM());
        }
    }
}