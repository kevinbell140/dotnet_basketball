
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using NBAMvc1._1.Areas.Auth;

namespace NBAMvc1._1.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string pw)
        {
            using(var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var adminID = await EnsureUser(serviceProvider, "Password12#", "admin@fbbm.com");
                await EnsureRole(serviceProvider, adminID, Constants.AdministratorRole);
                //new branch

            }
        }
        
        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string pw, string userName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(userName);
            if(user == null)
            {
                user = new IdentityUser { UserName = userName };
                await userManager.CreateAsync(user, pw);
            }
            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            IdentityResult IR = null;

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            if(roleManager == null)
            {
                throw new Exception("roleManager null");
            }
            if(!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

    }
}
