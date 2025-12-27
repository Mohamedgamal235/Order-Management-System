
using Microsoft.AspNetCore.Http.HttpResults;

namespace Order_Management_System.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                CustmerId = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email
            };

            await unitOfWork.Customers.AddAsync(customer);
            await unitOfWork.SaveChangesAsync();

            return customer.CustmerId;
        }

        public async Task<CustomerResponseDto?> GetCustomerByIdAsync(Guid id)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null) return null;

            return new CustomerResponseDto
            {
                CustomerId = customer.CustmerId,
                Name = customer.Name,
                Email = customer.Email
            };
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersForCustomerAsync(Guid customerId)
        {
            var orders = await unitOfWork.Orders.GetAllAsync();

            return orders
                .Where(o => o.CustomerId == customerId)
                .Select(o => new OrderResponseDto
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status
                });
        }
    }
}
