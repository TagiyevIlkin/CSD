using CSD.Entities.Shared;
using CSD.Repositories.Interfaces;
using CSD.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSD.ORM
{
    public class DbInitializer
    {

        private readonly IUnitOfWork _unitOfWork;

        public DbInitializer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public static async Task Seed(IServiceProvider serviceProvider, IConfiguration configuration)
        {

            //Adding custom Roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<UserApp>>();

            string[] roleNames = { StaticRoles.AdminRole,
                                   StaticRoles.MemberRole,
                                   StaticRoles.ModeratorRole
                                  
            };

            // creating the roles and seeding them to the database
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new ApplicationRole(roleName));
                }
            }


            //creating admin 
            var user = await userManager.FindByEmailAsync(configuration.GetSection("AdminSettings")["Email"]);
            if (user == null)
            {
                var admin = new UserApp()
                {
                    Email = configuration.GetSection("AdminSettings")["Email"],
                    UserName = configuration.GetSection("AdminSettings")["Username"],
                    Status = true,
                    PersonelId = 1
                };

                var userPass = configuration.GetSection("AdminSettings")["Password"];

                var createAdminResult = await userManager.CreateAsync(admin, userPass);

                if (createAdminResult.Succeeded)
                {
                    // here we assign the new user "Admin" role
                    await userManager.AddToRolesAsync(admin, roleNames);
                }
            }

        }

    }
}
