using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.LoginModel
{
    public class ResetPassword
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
