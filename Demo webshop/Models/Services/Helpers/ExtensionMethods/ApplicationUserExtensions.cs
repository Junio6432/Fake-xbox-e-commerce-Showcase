using Microsoft.AspNetCore.Identity;

namespace Demo_webshop.Models.Services.Helpers.ExtensionMethods
{
    public static class ApplicationUserExtensions
    {

        public static async Task<bool> SetUserInfoAsync<TUser>(this UserManager<TUser> userManager, TUser user, string firstName, string lastName)
           where TUser : ApplicationUser
        {

            if (user is ApplicationUser applicationUser)
            {
                applicationUser.FirstName = firstName;
                applicationUser.LastName = lastName;

                var result = await userManager.UpdateAsync((TUser)applicationUser);

                return result.Succeeded;
            }

            return false;
        }

        public static bool SetUserShoppingCartAsync<TUser>(this UserManager<TUser> userManager, TUser user, string shoppingCartId)
           where TUser : ApplicationUser
        {

            if (user is ApplicationUser applicationUser)
            {
                applicationUser.ShoppingCartId = shoppingCartId;

                var result = userManager.UpdateAsync((TUser)applicationUser).GetAwaiter().GetResult();

                return result.Succeeded;
            }

            return false;
        }

        public static string GetUserShoppingCart<TUser>(this UserManager<TUser> userManager, TUser user)
           where TUser : ApplicationUser
            => user.ShoppingCartId ?? "";




    }

}
