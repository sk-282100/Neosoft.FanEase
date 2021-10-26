using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
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
        private readonly ILogger _logger;
        public LoginRepo(ApplicationDbContext dbContext, ILogger<Login> logger)
        {
            _logger = logger;
        }
        List<LoginModel> list = new List<LoginModel>
        {
            new LoginModel{UserName="test",Password="test"},
            new LoginModel{UserName="test1",Password="test1"},
        };

        public bool CheckUsername(string userName)
        {
            var status = list.Find(p => p.UserName == userName);
            if (status != null)
            {
                return true;
            }
            return false;
        }

    }
}
