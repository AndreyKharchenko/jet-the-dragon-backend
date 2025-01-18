using ES.Application.Commands.ProductCommands;
using ES.Application.Commands.TechMapCommands;
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
    public class TechMapController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public TechMapController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TechMapQuery query)
        {
            var result = await _dispatcher.DispatchAsync<TechMapQuery, IEnumerable<TechMapDto>>(query);
            return Json(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateTechMapCommand command)
        {
            var techMapId = await _dispatcher.DispatchAsync<CreateTechMapCommand, Guid>(command);
            return Json(new { TechMapId = techMapId });
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(UpdateTechMapCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] DeleteTechMapCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
