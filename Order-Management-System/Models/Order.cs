using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Management_System.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        CashOnDelivery
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Returned
    }
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
