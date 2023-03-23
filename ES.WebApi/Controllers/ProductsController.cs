using ES.Application.Commands.CategoryCommands;
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
    public class ProductsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public ProductsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductsQuery query)
        {
            var result = await _dispatcher.DispatchAsync<ProductsQuery, IEnumerable<ProductDto>>(query);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            var productId = await _dispatcher.DispatchAsync<CreateProductCommand, Guid>(command);
            return Json(new { ProductId = productId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
