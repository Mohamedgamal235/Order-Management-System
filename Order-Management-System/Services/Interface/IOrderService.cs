namespace Order_Management_System.Services.Interface
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(CreateOrderDto dto);
        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
        Task<OrderResponseDto?> GetOrderByIdAsync(Guid id);
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
    }
}
