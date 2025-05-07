using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EstateEase.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Ensure the database is created
                context.Database.Migrate();

                // Check if the Agent role exists
                if (!await roleManager.RoleExistsAsync("Agent"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Agent"));
                }

                // Check if the default agent exists
                if (await userManager.FindByEmailAsync("agent@estateease.com") == null)
                {
                    var defaultAgent = new IdentityUser
                    {
                        UserName = "agent@estateease.com",
                        Email = "agent@estateease.com",
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(defaultAgent, "Agent123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(defaultAgent, "Agent");
                    }
                }
            }
        }
    }
}