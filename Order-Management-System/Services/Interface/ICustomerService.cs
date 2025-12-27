namespace Order_Management_System.Services.Interface
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetOrdersForCustomerAsync(Guid customerId);
        Task SaveChangesAsync();
    }
}
