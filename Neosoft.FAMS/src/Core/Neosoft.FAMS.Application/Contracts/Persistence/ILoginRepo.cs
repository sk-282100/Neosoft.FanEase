using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ILoginRepo
    {
        public LoginModel GetLoginDetail(string UserName, string Password);
        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public int RoleID { get; set; }

        }
    }
}
