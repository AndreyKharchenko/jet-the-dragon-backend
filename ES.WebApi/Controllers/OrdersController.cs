using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.ImageCommands;
using ES.Application.Commands.OrderCommands;
using ES.Application.Commands.ProductCommands;
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
    public class OrdersController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public OrdersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderQuery query)
        {
            var result = await _dispatcher.DispatchAsync<OrderQuery, IEnumerable<OrderDto>>(query);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            var orderId = await _dispatcher.DispatchAsync<CreateOrderCommand, Guid>(command);
            return Json(new { OrderId = orderId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateOrderCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteOrderCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
