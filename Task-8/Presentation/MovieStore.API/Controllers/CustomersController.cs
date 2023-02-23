using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Application.Services;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            await _service.CreateCustomerAsync(createCustomerDto);
            return Ok();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            await _service.RemoveAsync(customerId);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginCustomer([FromBody] LoginCustomerDto loginCustomerDto)
        {

            return Ok(await _service.LoginCustomerAsync(loginCustomerDto));
        }


    }
}
