using Microsoft.AspNetCore.Identity;

namespace Demo_webshop.Models.Services.Helpers.ExtensionMethods
{
    public static class UserManagerExtension
    {

        public static async Task<string> GetFullNameAsync<TUser>(this UserManager<TUser> userManager, TUser user)
        where TUser : ApplicationUser
        {
            var firstName = await userManager.GetFirstNameAsync(user);
            var lastName = await userManager.GetLastNameAsync(user);

            return $"{firstName} {lastName}";
        }

        private static Task<string> GetFirstNameAsync<TUser>(this UserManager<TUser> userManager, TUser user)
            where TUser : ApplicationUser
        {
            return Task.FromResult(user.FirstName);
        }

        private static Task<string> GetLastNameAsync<TUser>(this UserManager<TUser> userManager, TUser user)
            where TUser : ApplicationUser
        {
            return Task.FromResult(user.LastName);
        }

    }
}
