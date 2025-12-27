namespace Order_Management_System.DTO
{
    public class InvoiceResponseDto
    {
        public Guid InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalAmount { get; set; }
        public Guid OrderId { get; set; }
    }
}
