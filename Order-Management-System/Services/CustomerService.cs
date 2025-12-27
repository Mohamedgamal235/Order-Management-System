
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

        public async Task AddCustomerAsync(Customer customer)
            => await unitOfWork.Customers.AddAsync(customer);

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
            =>  await unitOfWork.Customers.GetByIdAsync(id);

        public async Task SaveChangesAsync()
            => await unitOfWork.SaveChangesAsync();

    }
}
