namespace Order_Management_System.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(Guid id);
        Task<Guid> CreateOrderAsync(CreateOrderDto dto);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task<Order?> UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
        Task SaveChangesAsync();
    }
}
