namespace Order_Management_System.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalAmount { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
