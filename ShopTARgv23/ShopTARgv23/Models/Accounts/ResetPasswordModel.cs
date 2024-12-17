using System.ComponentModel.DataAnnotations;

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string Token { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
}
