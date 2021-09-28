using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.AboutServices;
using Symphony.ViewModels.AboutViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Symphony.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService aboutService;

        public AboutsController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        // GET: api/<AboutsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutVM>>> Get()
        {
            return Ok(await aboutService.GetAboutVMsAsync());
        }

        // GET api/<AboutsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutVM>> Get(int id)
        {
            var about = await aboutService.GetAboutVMAsync(id);

            if (about is null) return NotFound();

            return Ok(about);
        }

        // POST api/<AboutsController>
        [HttpPost]
        public async Task<ActionResult<AboutVM>> Post([FromBody] CreateAboutVM createAboutVM)
        {
            if (createAboutVM is null)
            {
                return BadRequest();
            }

            var aboutVM = new AboutVM();

            if (ModelState.IsValid)
            {
                aboutVM = await aboutService.CreateAboutAsync(createAboutVM);
            }

            return CreatedAtAction(nameof(Get), new { id = aboutVM.Id }, aboutVM);
        }

        // PUT api/<AboutsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateAboutVM updateAboutVM)
        {
            if (updateAboutVM is null) return BadRequest();

            var aboutVM = new AboutVM();

            if (ModelState.IsValid)
            {
                aboutVM = await aboutService.UpdateAboutAsync(updateAboutVM);
            }

            // Return null if cannot find the about (entity) with the id in updateAboutVM in param)
            // Trả về null nếu ko tìm đc class about with id trong updateAboutVM trong tham số đầu vào.
            if (aboutVM is null) return NotFound();

            // success, return nocontent.
            // thành công trả về nocontent.
            return NoContent();
        }

        // DELETE api/<AboutsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var about = await aboutService.DeleteAboutAsync(id);
            if (about is null) return NotFound();

            return NoContent();
        }
    }
}
