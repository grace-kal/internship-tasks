using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SoftwareCompanyTicketSystem.Data;
using SoftwareCompanyTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCompanyTicketSystem.App.Seeder
{
    public class RoleSeeder : IRoleSeeder
    {
        public async Task SeedAsync(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            //creating roles
            await SeedRolesAsync(roleManager, "Admin");
            await SeedRolesAsync(roleManager, "Maintenance");
            await SeedRolesAsync(roleManager, "Programmer");

            //seeding these roles with people
            //only admin will be seeded initialy
            await SeedUserWithRoleAdminAsync(userManager);

        }
        //methods
        //seed user in role
        private async Task SeedUserWithRoleAdminAsync(UserManager<User> userManager)
        {
            var user = await userManager.FindByNameAsync("Admin");
            if (user == null)
            {
                var result = await userManager.CreateAsync(new User
                {
                    UserName = "Admin",
                    Email = "sctsAdmin@gmail.com",
                    JoinedOn = DateTime.Now,
                    IsApprovedByAdmin=true
                }, "Admin_12345");
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.Select(e => e.Description).ToString());
                }
                else
                {
                    user = await userManager.FindByNameAsync("Admin");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
        //seed role
        private async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager, string v)
        {
            var role = await roleManager.FindByNameAsync(v);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(v));
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.Select(e => e.Description).ToString());
                }
            }
        }
    }
}
