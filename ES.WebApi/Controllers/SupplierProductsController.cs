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
    public class SupplierProductsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public SupplierProductsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierProductsQuery query)
        {
            var result = await _dispatcher.DispatchAsync<SupplierProductsQuery, IEnumerable<ProductDto>>(query);
            return Json(result);
        }
    }
}
