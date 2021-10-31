using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Neosoft.FAMS.WebApp.Models.LoginModel
{
    public class ResetPassword
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string newPassword { get; set; }
    }
}
