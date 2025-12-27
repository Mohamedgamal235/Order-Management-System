namespace Order_Management_System.Models
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
