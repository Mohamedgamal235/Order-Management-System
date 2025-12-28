using Microsoft.AspNetCore.Mvc;
using Order_Management_System.Constants;

namespace Order_Management_System.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    [Authorize(Roles =Role.Admin)]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInvoiceById(Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
                return NotFound();
            return Ok(invoice);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }
    }
}
