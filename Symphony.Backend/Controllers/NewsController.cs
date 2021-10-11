using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.NewsServices;
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
    public class NewsController : ControllerBase
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        // GET: api/<NewssController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsVM>>> Get() => Ok(await newsService.GetNewsVMsAsync());
        
        // GET api/<NewssController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsVM>> Get(int id)
        {
            var news = await newsService.GetNewsVMAsync(id);

            if (news is null) return NotFound();

            return Ok(news);
        }



        // POST api/<NewssController>
        [HttpPost]
        public async Task<ActionResult<NewsVM>> Post([FromBody] CreateNewsVM createNewsVM)
        {
            if (createNewsVM is null)
            {
                return BadRequest();
            }

            var newsVM = new NewsVM();

            if (ModelState.IsValid)
            {
                newsVM = await newsService.CreateNewsAsync(createNewsVM);
            }

            return CreatedAtAction(nameof(Get), new { id = newsVM.Id }, newsVM);
        }


        // PUT api/<NewssController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateNewsVM updateNewsVM)
        {
            if (updateNewsVM is null) return BadRequest();

            var newsVM = new NewsVM();

            if (ModelState.IsValid)
            {
                newsVM = await newsService.UpdateNewsAsync(updateNewsVM);
            }

            // Return null if cannot find the about (entity) with the id in updateAboutVM in param)
            // Trả về null nếu ko tìm đc class about with id trong updateAboutVM trong tham số đầu vào.
            if (newsVM is null) return NotFound();

            // success, return nocontent.
            // thành công trả về nocontent.
            return NoContent();
        }



        // DELETE api/<NewssController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var news = await newsService.GetNewsVMAsync(id);

            if (news is null) return NotFound();

            await newsService.DeleteNewsAsync(id);

            return NoContent();
        }
    }
}
