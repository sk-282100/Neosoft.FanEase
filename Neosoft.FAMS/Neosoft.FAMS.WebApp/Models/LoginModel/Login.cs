using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Neosoft.FAMS.WebApp.Models.LoginModel.Login
{
  public  class Login
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",ErrorMessage = "**Please Enter Valid Email.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }

    }
}
