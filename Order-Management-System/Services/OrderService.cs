using Order_Management_System.Services.Interface;

namespace Order_Management_System.Services
{
    public class OrderService : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrderAsync(Order order)
            => _unitOfWork.Orders.AddAsync(order);

        public Task DeleteOrderAsync(Order order)
            => _unitOfWork.Orders.DeleteAsync(order);

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
            => _unitOfWork.Orders.GetAllAsync();

        public Task<Order?> GetOrderByIdAsync(Guid id)
            => _unitOfWork.Orders.GetByIdAsync(id);

        public Task UpdateOrderAsync(Order order)
            => _unitOfWork.Orders.UpdateAsync(order);
    }
}
