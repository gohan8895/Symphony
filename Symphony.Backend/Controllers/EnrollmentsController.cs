using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.EnrollmentServices;
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

        // GET api/<EnrollmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentVM>> Get(int id)
        {
            var enrollment = await enrollmentService.GetEnrollmentVMAsync(id);
            if(enrollment is null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<ActionResult<EnrollmentVM>> Post([FromBody] CreateEnrollmentVM createEnrollmentVM)
        {
            if(createEnrollmentVM is null)
            {
                return BadRequest();
            }
            var enrollmentVM = new EnrollmentVM();
            if(ModelState.IsValid)
            {
                enrollmentVM = await enrollmentService.CreateEnrollment(createEnrollmentVM);
            }

            return CreatedAtAction(nameof(Get), new { id = enrollmentVM.Id }, enrollmentVM);
        }

        // PUT api/<EnrollmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EnrollmentVM>> Put([FromBody] UpdateEnrollmentVM updateEnrollmentVM)
        {
            if(updateEnrollmentVM is null)
            {
                return BadRequest();
            }
            var enrollmentVM = new EnrollmentVM();
            if(ModelState.IsValid)
            {
                enrollmentVM = await enrollmentService.UpdateEnrollment(updateEnrollmentVM);
            }
                
            if(enrollmentVM is null) 
            { 
                return NotFound(); 
            }
            return NoContent();
        }

        // UPDATE Enrollemnt Status
        [HttpPut("update-enrollment-state/{id}")]
        public async Task<ActionResult> ChangeStatus(int id)
        {
            var enrollment = await enrollmentService.GetEnrollmentVMAsync(id);
            if(enrollment is null)
            {
                return NotFound();
            }
            await enrollmentService.ChangeEnrollmentStatus(id);
            return NoContent();
        }

        [HttpGet("enrollment/get-enrollment-with-data")]
        public async Task<ActionResult<EnrollmentWithData>> GetEnrollmentWithData()
        {
            return Ok(await enrollmentService.GetEnrollmentWithDataVM());
        }
    }
}
