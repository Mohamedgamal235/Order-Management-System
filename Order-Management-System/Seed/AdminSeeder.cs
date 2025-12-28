using Microsoft.AspNetCore.Identity;
using Order_Management_System.Constants;

namespace Order_Management_System.Seed
{
    public class AdminSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var adminEmail = "admin@system.com";
            var adminPassword = "Admin@123";

            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin != null) return;

            admin = new User
            {
                Id = Guid.NewGuid(),
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, adminPassword);
            if (!result.Succeeded)
                throw new Exception("Admin creation failed");

            await userManager.AddToRoleAsync(admin, Role.Admin);
        }
    }
}
