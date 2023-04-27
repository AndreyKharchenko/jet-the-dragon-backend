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
    public class SupplierOrdersActiveController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public SupplierOrdersActiveController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierOrderActiveQuery query)
        {
            var result = await _dispatcher.DispatchAsync<SupplierOrderActiveQuery, IEnumerable<OrderConfirmPayDto>>(query);
            return Json(result);
        }
    }
}
