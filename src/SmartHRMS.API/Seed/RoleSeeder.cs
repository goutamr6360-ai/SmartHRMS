using Microsoft.AspNetCore.Identity;
using SmartHRMS.Shared.Constants;

namespace SmartHRMS.API.Seed
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            string[] roles =
            {
                Roles.SuperAdmin,
                Roles.CompanyAdmin,
                Roles.HR,
                Roles.Manager,
                Roles.Employee
            };

            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }
    }
}
