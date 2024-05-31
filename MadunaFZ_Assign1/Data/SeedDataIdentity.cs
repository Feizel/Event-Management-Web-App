using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MadunaFZ_Assign1.Data
{
    public static class SeedDataIdentity
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Event123$";
        private const string adminEmail = "admin@ufs.ac.za";
        private const string adminRole = "Admin";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            IdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<IdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (await userManager.FindByNameAsync(adminUser) == null)
            {
                if (await roleManager.FindByNameAsync(adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }

                if (await roleManager.FindByNameAsync("Attendee") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Attendee"));
                }

                IdentityUser user = new IdentityUser
                {
                    UserName = adminUser,
                    Email = adminEmail
                };

                IdentityResult result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRole);
                }

            }
        }
    }

}
