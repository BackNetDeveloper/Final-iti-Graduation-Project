using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Atwan",
                    Email = "Ahmed@gmail.com",
                    UserName = "ahmed.atwan",
                    Address = new Address()
                    {
                        FirstName = "Ahmed",
                        LastName = "Atwan",
                        Country = "Egypt",
                        City = "Giza",
                        Street = "Shehata Rashwan St."
                    }
                };
                await userManager.CreateAsync(user, "12345@Atwan");
            }
        }
    }
}
