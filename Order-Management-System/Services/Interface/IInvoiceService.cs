namespace Order_Management_System.Services.Interface
{
    public interface IInvoiceService
    {
        Task<InvoiceResponseDto?> GetInvoiceByIdAsync(Guid id);
        Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync();
    }
}
