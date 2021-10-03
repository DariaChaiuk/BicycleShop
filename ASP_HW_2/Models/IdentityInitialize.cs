using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public static class IdentityInitialize
    {
        async public static Task Init(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (!userManager.Users.Any())
            {
                List<IdentityRole> identityRoles = new List<IdentityRole>();
                identityRoles.Add(new IdentityRole() { Name = "Admin" });
                identityRoles.Add(new IdentityRole() { Name = "User" });
                identityRoles.Add(new IdentityRole() { Name = "SuperAdmin" });


                foreach (IdentityRole role in identityRoles)
                {
                    await roleManager.CreateAsync(role);
                }

                var superAdmin = new User
                {
                    UserName = "superAdmin@gmail.com",
                    Email = "superAdmin@gmail.com"
                };

                var admin = new User
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };

                var user = new User
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };

                var result =  await userManager.CreateAsync(superAdmin, "SAdmin1#");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(await userManager.FindByEmailAsync("superAdmin@gmail.com"), "SuperAdmin");
                }

                result = await userManager.CreateAsync(admin, "Admin2#");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(await userManager.FindByEmailAsync("admin@gmail.com"), "Admin");
                }

                result = await userManager.CreateAsync(user, "User3#");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(await userManager.FindByEmailAsync("user@gmail.com"), "User");
                }
            }

        }


    }
}
