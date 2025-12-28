namespace Order_Management_System.DTO
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
