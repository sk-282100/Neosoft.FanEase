using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using static Neosoft.FAMS.Application.Contracts.Persistence.ILoginRepo;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class LoginRepo:ILoginRepo
    {
        public LoginModel GetLoginDetail(string userName, string Password)
        {
            LoginModel obj = new LoginModel();
            obj.UserName = "admin";
            obj.Password = "Admin";
            obj.RoleID = 1;
            return obj;

        }
    }
}
