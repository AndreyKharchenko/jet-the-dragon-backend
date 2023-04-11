using ES.Application.Commands.FavouriteCommands;
using ES.Application.Commands.FavouritiesCommands;
using ES.Application.Commands.OrderCommands;
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
    public class FavouritiesController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public FavouritiesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FavouritiesQuery query)
        {
            var result = await _dispatcher.DispatchAsync<FavouritiesQuery, IEnumerable<FavouritiesDto>>(query);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFavouriteCommand command)
        {
            var favouriteId = await _dispatcher.DispatchAsync<CreateFavouriteCommand, Guid>(command);
            return Json(new { FavouriteId = favouriteId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateFavouriteCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteFavouriteCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
