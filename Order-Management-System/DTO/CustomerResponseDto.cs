namespace Order_Management_System.DTO
{
    public class CustomerResponseDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

}
