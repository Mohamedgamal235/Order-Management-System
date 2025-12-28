using Microsoft.AspNetCore.Identity;
using Order_Management_System.Constants;

namespace Order_Management_System.Seed
{
    public class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Role.Admin))
                await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Admin));

            if (!await roleManager.RoleExistsAsync(Role.Customer))
                await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Customer));
        }
    }
}
