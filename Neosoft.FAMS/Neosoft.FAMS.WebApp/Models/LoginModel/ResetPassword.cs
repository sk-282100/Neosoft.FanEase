using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.LoginModel
{
    public class ResetPassword
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Old Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Should have at least one lower case,at least one upper case,at least one number,at least one special character,Minimum 8 characters")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string confirmPassword { get; set; }
    }
}
