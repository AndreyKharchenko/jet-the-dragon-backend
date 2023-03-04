using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.CustomerCommands;
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
    public class CustomerController : Controller
    {
        private readonly IDispatcher _dispatcher;


        public CustomerController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerQuery query)
        {
            var result = await _dispatcher.DispatchAsync<CustomerQuery, CustomerDto>(query);
            if(result is null)
            {
                return NotFound();
            }
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            var customerId = await _dispatcher.DispatchAsync<CreateCustomerCommand, Guid>(command);
            return Json(new { CustomerId = customerId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCommand command)
        {
            await _dispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
