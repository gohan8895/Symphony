using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.FAQServices;
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
    public class FAQsController : ControllerBase
    {
        private readonly IFAQService faqService;

        public FAQsController(IFAQService faqService)
        {
            this.faqService = faqService;
        }

        // GET: api/<FAQsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQVM>>> GetAsync()
        {
            return Ok(await faqService.GetFAQVMsAsync());
        }

        // GET api/<FAQsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FAQVM>> Get(int id)
        {
            var faq = await faqService.GetFAQVMAsync(id);

            if (faq is null) return NotFound();

            return Ok(faq);
            
        }

        // POST api/<FAQsController>
        [HttpPost]
        public async Task<ActionResult<FAQVM>> Post([FromBody] CreateFAQVM createFAQVM)
        {
            if (createFAQVM is null)
            {
                return BadRequest();
            }
            var faqVM = new FAQVM();

            if(ModelState.IsValid)
            {
                faqVM = await faqService.CreateFAQAsync(createFAQVM);
            }

            return CreatedAtAction(nameof(Get), new { id = faqVM.Id }, faqVM);
        }

        // PUT api/<FAQsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateFAQVM updateFAQVM)
        {
            if (updateFAQVM is null) return BadRequest();

            var faqVM = new FAQVM();

            if(ModelState.IsValid)
            {
                faqVM = await faqService.UpdateFAQAsync(updateFAQVM);
            }

            if (faqVM is null) return NotFound();

            return NoContent();
        }

        // DELETE api/<FAQsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var faq = await faqService.GetFAQVMAsync(id);

            if (faq is null) return NotFound();

            await faqService.DeleteFAQAsync(id);

            return NoContent();
        }
    }
}
