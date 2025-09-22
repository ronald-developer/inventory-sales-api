using InventorySales.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace InventorySales.Api.Seeders
{
    public static class IdentitySeeder
    {
        public static async Task SeedDefaultAdminAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            const string userName = "admin";
            const string email = "ronald.b.jose.developer@gmail.com";
            const string adminPassword = "Admin@123";
            const string roleName = "Administrator";
            const string roleDescription = "Super user";

            // Ensure role exists
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName, Description = roleDescription, IsActive = true });
            }

            // Check if user exists
            var adminUser = await userManager.FindByNameAsync(userName);
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = userName,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = "System",
                    LastName = "Admin"
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create default admin: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            // Ensure user is in role
            if (!await userManager.IsInRoleAsync(adminUser, roleName))
            {
                await userManager.AddToRoleAsync(adminUser, roleName);
            }
        }
    }

}
