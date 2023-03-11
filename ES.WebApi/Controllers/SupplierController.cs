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
    public class SupplierController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public SupplierController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SupplierQuery query)
        {
            var result = await _dispatcher.DispatchAsync<SupplierQuery, SupplierDto>(query);
            if (result is null)
            {
                return NotFound();
            }
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSupplierCommand command)
        {
            var supplierId = await _dispatcher.DispatchAsync<CreateSupplierCommand, Guid>(command);
            return Json(new { SupplierId = supplierId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateSupplierCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
