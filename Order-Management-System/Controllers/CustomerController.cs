using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            var id = await _customerService.CreateCustomerAsync(dto);
            return CreatedAtAction(nameof(GetCustomerById), new { id }, null);
        }

        [HttpGet("{id:guid}/orders")]
        public async Task<IActionResult> GetCustomerOrders(Guid id)
        {
            var orders = await _customerService.GetOrdersForCustomerAsync(id);
            return Ok(orders);
        }
    }
}
