using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Order_Management_System.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Order_Management_System.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user , dto.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            await _userManager.AddToRoleAsync(user, Role.Customer);
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("Invalid email or password");

            var validPass = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!validPass)
                throw new Exception("Invalid email or password");

            var token = GenerateToken(user);
            return token;
        }

        private AuthResponseDto GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var userRoles = _userManager.GetRolesAsync(user).Result;
            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: cred
            );

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = token.ValidTo
            };
        }
    }
}
