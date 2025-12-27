using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            var id = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetOrderById), new { id }, null);
        }

        [HttpGet]
        // admin
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
        public async Task<IActionResult> UpdateOrderStatus(Guid id, UpdateOrderStatusDto dto)
        {
            await _orderService.UpdateOrderStatusAsync(id, dto.Status);
            return NoContent();
        }

    }
}
