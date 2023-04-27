using ES.Application.Commands.CartCommands;
using ES.Application.Commands.DeliveredCommands;
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
    public class DeliveredController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public DeliveredController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDeliveredCommand command)
        {
            await _dispatcher.DispatchAsync<CreateDeliveredCommand>(command);
            return NoContent();
        }
    }
}
