using Microsoft.AspNetCore.Mvc;
using Symphony.Services.BackendServices.PaymentStatusServices;
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
    public class PaymentStatussController : ControllerBase
    {
        private readonly IPaymentStatusService paymentStatusService;

        public PaymentStatussController(IPaymentStatusService paymentStatusService)
        {
            this.paymentStatusService = paymentStatusService;
        }

        //AboutsController
        // GET: api/<PaymentStatussController>

        [HttpGet("get-all-paymentstatus")]
        public async Task<ActionResult<IEnumerable<PaymentStatusVM>>> GetAllPaymentStatus()
        {
            var result = await paymentStatusService.GetAllPaymentStatusAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PaymentStatusVM>> GetPaymentStatus(int id)
        {
            var result = await paymentStatusService.GetPaymentStatusAsync(id);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<ActionResult<PaymentStatusVM>> CreatePaymentStatus([FromBody] CreatePaymentStatusVM createPaymentStatusVM)
        //{
        //    if(createPaymentStatusVM is null)
        //    {
        //        return BadRequest();
        //    }
        //    var paymentStatusVM = new PaymentStatusVM();
        //    if (ModelState.IsValid)
        //    {
        //        paymentStatusVM = await paymentStatusService.CreatePaymentStatusAsync(createPaymentStatusVM);
        //    }

        //    return CreatedAtAction(nameof(GetPaymentStatus), new { id = paymentStatusVM.Id }, paymentStatusVM);
        //}

        [HttpPut]
        public async Task<ActionResult<PaymentStatusVM>> UpdatePaymentStatus([FromBody] int courseRegistrationId, bool courseRegisIsApproved)
        {
            var PaymentStatusVM = new PaymentStatusVM();
            if (ModelState.IsValid)
            {
                PaymentStatusVM = await paymentStatusService.UpdatePaymentStatusAsync(courseRegistrationId, courseRegisIsApproved);
            }
            if (PaymentStatusVM is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaymentStatus(int id)
        {
            var result = await paymentStatusService.GetPaymentStatusAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            await paymentStatusService.DeletePaymentStatusAsync(id);
            return NoContent();
        }
    }
}