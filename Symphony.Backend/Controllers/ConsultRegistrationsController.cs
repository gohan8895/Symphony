using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices;
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
    public class ConsultRegistrationsController : ControllerBase
    {
        // GET: api/<ConsultRegistrationsController>
        private readonly IConsultService _services;

        public ConsultRegistrationsController(IConsultService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultVM>>> GetConsultRegistrations()
        {
            var _regs = await _services.GetConsultRegistrations();
            return Ok(_regs);
        }

        // GET api/<ConsultRegistrationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultVM>> GetConsultRegistration(int id)
        {
            var _reg = await _services.GetConsultRegistration(id);
            return Ok(_reg);
        }

        // POST api/<ConsultRegistrationsController>
        [HttpPost]
        public async Task<ActionResult<ConsultVM>> PostAuthor(ConsultCreateRequest request)
        {
            var _id = await _services.PostConsultRegistration(request);

            return CreatedAtAction(nameof(GetConsultRegistration), new { id = _id }, request);
        }

        // PUT api/<ConsultRegistrationsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsult(int id, ConsultUpdateRequest request)
        {
            await _services.PutConsultRegistration(request, id);
            return NoContent();
        }

        // DELETE api/<ConsultRegistrationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _services.DeleteConsultRegistration(id);
            return NoContent();
        }
    }
}