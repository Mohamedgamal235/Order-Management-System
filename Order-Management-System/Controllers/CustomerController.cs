using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customers = await _customerService.GetCustomerByIdAsync(id);
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer
            {
                CustmerId = Guid.NewGuid(),
                Name = createCustomerDto.Name,
                Email = createCustomerDto.Email,
            };

            await _customerService.AddCustomerAsync(customer);
            await _customerService.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustmerId }, customer);
        }
    }
}
