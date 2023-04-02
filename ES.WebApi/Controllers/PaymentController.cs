using ES.Application.Commands.CartCommands;
using ES.Application.Commands.PaymentCommands;
using ES.Domain;
using ES.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ES.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public PaymentController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePaymentCommand command)
        {
            await _dispatcher.DispatchAsync<CreatePaymentCommand>(command);
            return NoContent();
        }
    }
}
