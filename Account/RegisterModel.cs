using System.ComponentModel.DataAnnotations;

namespace ProjectManage.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(10, MinimumLength = 3)]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 8)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password don't match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}