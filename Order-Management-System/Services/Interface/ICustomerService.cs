namespace Order_Management_System.Services.Interface
{
    public interface ICustomerService
    {
        Task<Guid> CreateCustomerAsync(CreateCustomerDto dto);
        Task<CustomerResponseDto?> GetCustomerByIdAsync(Guid id);
        Task<IEnumerable<OrderResponseDto>> GetOrdersForCustomerAsync(Guid customerId);
    }
}
