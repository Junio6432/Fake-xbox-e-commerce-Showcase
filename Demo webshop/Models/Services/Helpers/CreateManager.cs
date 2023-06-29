using Microsoft.AspNetCore.Identity;

namespace Demo_webshop.Models.Services.Helpers
{
    public class CreateManager
    {


        public CreateManager()
        {

        }

        public async Task CreateDemoUser(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            //var user = new ApplicationUser
            //{
            //    UserName = "demo@example.com",
            //    Email = "demo@example.com"
            //};

            //var createUserResult = await userManager.CreateAsync(user, "Password123!");

            ////if (createUserResult.Succeeded)
            ////{
            //    var roleExists = await roleManager.RoleExistsAsync("manager");

            //    if (!roleExists)
            //    {
            //        await roleManager.CreateAsync(new IdentityRole("manager"));
            //    }

            //    await userManager.AddToRoleAsync(user, "manager");
            //}
        }


    }
}
