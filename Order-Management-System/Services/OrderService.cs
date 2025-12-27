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

        public async Task<Guid> CreateOrderAsync(CreateOrderDto dto)
        {
            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow,
                PaymentMethod = dto.PaymentMethod,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>()
            };

            double total = 0;

            foreach (var item in dto.OrderItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception("Product not found");

                if (product.StockQuantity < item.Quantity)
                    throw new Exception("Insufficient stock");

                var orderItem = new OrderItem
                {
                    OrderItemId = Guid.NewGuid(),
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    UnitPrice = product.Price,
                    Quantity = item.Quantity,
                    Discount = 0,
                };

                product.StockQuantity -= item.Quantity;
                total += (orderItem.UnitPrice * orderItem.Quantity);
                order.OrderItems.Add(orderItem);
            }

            if (total > 200)
                total *= 0.90;
            else if (total > 100)
                total *= 0.95;

            order.TotalAmount = total;

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return order.OrderId;

        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();

            return orders.Select(o => new OrderResponseDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status
            });
        }

        public async Task<OrderResponseDto?> GetOrderByIdAsync(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null) return null;

            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }

        public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId)
                        ?? throw new Exception("Order not found");

            order.Status = status;

            if (status == OrderStatus.Delivered)
            {
                var invoice = new Invoice
                {
                    InvoiceId = Guid.NewGuid(),
                    OrderId = order.OrderId,
                    InvoiceDate = DateTime.UtcNow,
                    TotalAmount = order.TotalAmount
                };

                await _unitOfWork.Invoices.AddAsync(invoice);
            }

            await _unitOfWork.SaveChangesAsync();
        }

    }
}
