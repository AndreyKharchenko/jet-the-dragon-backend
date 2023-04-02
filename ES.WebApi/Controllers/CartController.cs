using ES.Application.Commands.CartCommands;
using ES.Application.Commands.CustomerCommands;
using ES.Application.Commands.SupplierCommands;
using ES.Application.Dtos;
using ES.Application.Queries;
using ES.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ES.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public CartController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CartQuery query)
        {
            var result = await _dispatcher.DispatchAsync<CartQuery, CartDto>(query);
            if (result is null)
            {
                return NotFound();
            }
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCartCommand command)
        {
            var cartId = await _dispatcher.DispatchAsync<CreateCartCommand, Guid>(command);
            return Json(new { CartId = cartId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCartCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
