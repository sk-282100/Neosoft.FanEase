using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.LoginModel
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$", ErrorMessage = "Please Enter Valid Email.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
