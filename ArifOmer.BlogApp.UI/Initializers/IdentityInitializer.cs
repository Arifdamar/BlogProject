﻿using ArifOmer.BlogApp.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace ArifOmer.BlogApp.UI.Initializers
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");

            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("Arif");

            if (adminUser == null)
            {
                AppUser user = new AppUser()
                {
                    Name = "Arif",
                    SurName = "Damar",
                    UserName = "G171210009@sakarya.edu.tr",
                    Email = "G171210009@sakarya.edu.tr"
                };

                await userManager.CreateAsync(user, "123");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
