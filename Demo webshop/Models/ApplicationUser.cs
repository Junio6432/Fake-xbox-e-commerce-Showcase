using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Demo_webshop.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [BindNever]
        public string ShoppingCartId { get; set; } = string.Empty;
    }
}
