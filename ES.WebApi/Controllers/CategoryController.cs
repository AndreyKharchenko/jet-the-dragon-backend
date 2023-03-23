using ES.Application.Commands.CategoryCommands;
using ES.Application.Dtos;
using ES.Application.Queries;
using ES.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ES.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]


    public class CategoryController: Controller
    {
        private readonly IDispatcher _dispatcher;

        public CategoryController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CategoryQuery query)
        {
            var result = await _dispatcher.DispatchAsync<CategoryQuery, IEnumerable<CategoryDto>>(query);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post( [FromForm] CreateCategoryCommand command)
        {
            var categoryId = await _dispatcher.DispatchAsync<CreateCategoryCommand, Guid>(command);
            return Json(new { CategoryId = categoryId });
        }

        [HttpPut]
        public async Task<IActionResult> Put( [FromForm] UpdateCategoryCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
