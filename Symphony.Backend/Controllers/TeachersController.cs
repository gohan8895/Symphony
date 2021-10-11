using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.TeacherServices;
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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

       // AboutsController
        // GET: api/<TeachersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherVM>>> Get()
        {
            return Ok(await teacherService.GetTeacherVmsAsync());
        }
       
         // GET api/<TeachersController>/5
         [HttpGet("{id}")]
        public async Task<ActionResult<TeacherVM>> Get(int id)
        {
            var teacher = await teacherService.GetTeacherVMAsync(id);
            if (teacher is null) return NotFound();
            return Ok(teacher);
        }

       // POST api/<TeachersController>
       [HttpPost]
        public async Task<ActionResult<TeacherVM>> Post([FromBody] CreateTeacherVM createTeacherVM)
        {
            if (createTeacherVM is null) return BadRequest();

            var teacherVM = new TeacherVM();
            if (ModelState.IsValid)
            {
                 teacherVM = await teacherService.CreateTeacherAsync(createTeacherVM);
            }
            return CreatedAtAction(nameof(Get), new { id = teacherVM.Id }, teacherVM);
        }

        // PUT api/<TeachersController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateTeacherVM updateTeacherVM)
        {
            if (updateTeacherVM is null) return BadRequest();
            var teacherVM = new TeacherVM();

            if (ModelState.IsValid)
            {
                teacherVM = await teacherService.UpdateTeacherAsync(updateTeacherVM);
            }
            if (teacherVM is null) return NotFound();
            return NoContent();
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var teacher = await teacherService.GetTeacherVMAsync(id);
            if (teacher is null) return NotFound();
            await teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }
    }
}
