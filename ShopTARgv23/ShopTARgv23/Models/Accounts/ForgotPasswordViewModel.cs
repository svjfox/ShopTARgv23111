﻿using System.ComponentModel.DataAnnotations;

namespace ShopTARgv23.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
