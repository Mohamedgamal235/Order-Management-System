namespace Order_Management_System.Models
{
    public class Customer
    {
        public Guid CustmerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
