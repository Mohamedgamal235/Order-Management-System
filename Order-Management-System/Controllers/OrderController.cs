using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.Constants;

namespace Order_Management_System.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var id = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetOrderById), new { id }, null);
        }

        [HttpGet]
        // admin
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrdersAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut("{id:guid}/status")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] UpdateOrderStatusDto dto)
        {
            await _orderService.UpdateOrderStatusAsync(id, dto.Status);
            return NoContent();
        }

    }
}
