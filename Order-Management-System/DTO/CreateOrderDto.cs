namespace Order_Management_System.DTO
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } = new();
    }
}
