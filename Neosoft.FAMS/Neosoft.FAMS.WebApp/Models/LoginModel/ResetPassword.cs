using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.LoginModel
{
    public class ResetPassword
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Old Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string confirmPassword { get; set; }
    }
}
