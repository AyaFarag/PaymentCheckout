using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO.StripeDTO;
using Shop.Application.Service.Payment.StripeService;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeService stripeService;
        public StripeController(IStripeService _stripeService)
        {
           stripeService = _stripeService;     
        }

        [HttpPost("pay")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentStripeDTO request)
        {
            var clientSecret = await stripeService.Pay(request);
            return Ok(new { clientSecret });
        }

        [HttpPost("success")]
        public async Task<IActionResult> success()
        {
            return Ok(await stripeService.success());
        }
    }
}
