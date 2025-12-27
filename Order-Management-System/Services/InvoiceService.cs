
namespace Order_Management_System.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync()
        {
            var invoices = await _unitOfWork.Invoices.GetAllAsync();
            return invoices.Select(i => new InvoiceResponseDto
            {
                InvoiceId = i.InvoiceId,
                InvoiceDate = i.InvoiceDate,
                TotalAmount = i.TotalAmount,
                OrderId = i.OrderId
            });
        }

        public async Task<InvoiceResponseDto?> GetInvoiceByIdAsync(Guid id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null)
                return null;

            return new InvoiceResponseDto
            {
                InvoiceId = invoice.InvoiceId,
                InvoiceDate = invoice.InvoiceDate,
                TotalAmount = invoice.TotalAmount,
                OrderId = invoice.OrderId
            };
        }
    }
}
