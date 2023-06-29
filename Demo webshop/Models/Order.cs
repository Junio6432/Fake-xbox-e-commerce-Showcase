using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Demo_webshop.Models
{
    public class Order
    {

        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your first address")]
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Address Line 2")]
        public string? AddressLine2 { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Please enter your ZIP Code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; } = string.Empty;

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; } = string.Empty;

        [StringLength(10)]
        [Required(ErrorMessage = "Please enter your State")]
        public string? State { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your  Country")]
        public string Country { get; set; } = string.Empty;

        [StringLength(25)]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; } = string.Empty;

        [BindNever]
        public double OrderTotal { get; set; }

        [BindNever]
        public DateTime OrderPlaced { get; set; }

    }
}
