using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShopTARgv23.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }

        [Required]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
    }
}