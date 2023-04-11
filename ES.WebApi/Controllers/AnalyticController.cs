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
    public class AnalyticController : Controller
    {
        private readonly IDispatcher _dispatcher;
        public AnalyticController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AnalyticQuery query)
        {
            var result = await _dispatcher.DispatchAsync<AnalyticQuery, AnalyticDto>(query);
            if (result is null)
            {
                return NotFound();
            }
            return Json(result);
        }
    }
}
