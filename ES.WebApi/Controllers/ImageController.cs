using ES.Application.Commands.CustomerCommands;
using ES.Application.Commands.ImageCommands;
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
    public class ImageController : Controller
    {
        private readonly IDispatcher _dispatcher;


        public ImageController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateImagesCommand command)
        {
            await _dispatcher.DispatchAsync<CreateImagesCommand>(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteImageCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
