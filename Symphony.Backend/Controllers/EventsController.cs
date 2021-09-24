using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.EventServices;
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
    public class EventsController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventVM>>> GetAsync()
        {
            return Ok( await eventService.GetEventVMsAsync()) ;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventVM>> Get(int id)
        {
            var ev = await eventService.GetEventVMAsync(id);

            if (ev is null) return NotFound();

            return Ok(ev);
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<ActionResult<EventVM>> Post([FromBody] CreateEventVM createEventVM)
        {
            if (createEventVM is null) return BadRequest();

            var eventVM = new EventVM();

            if(ModelState.IsValid)
            {
                eventVM = await eventService.CreateEventAsync(createEventVM);
            }

            return CreatedAtAction(nameof(Get), new { id = eventVM.Id }, eventVM);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EventVM>> Put( [FromBody] UpdateEventVM updateEventVM)
        {
            if (updateEventVM is null) return BadRequest();

            var eventVM = new EventVM();

            if(ModelState.IsValid)
            {
                eventVM = await eventService.UpdateEventAsync(updateEventVM);
            }

            if (eventVM is null) return NotFound();

            return NoContent();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var ev = await eventService.GetEventVMAsync(id);

            if (ev is null) return NotFound();

            await eventService.DeleteEventAsync(id);

            return NoContent();
        }
    }
}
