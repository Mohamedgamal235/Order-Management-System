namespace Order_Management_System.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
