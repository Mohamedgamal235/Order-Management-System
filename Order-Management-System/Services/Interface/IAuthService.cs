namespace Order_Management_System.Services.Interface
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
