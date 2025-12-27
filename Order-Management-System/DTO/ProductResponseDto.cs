namespace Order_Management_System.DTO
{
    public class ProductResponseDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
