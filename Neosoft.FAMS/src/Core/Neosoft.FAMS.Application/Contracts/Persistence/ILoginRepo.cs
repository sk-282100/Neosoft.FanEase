using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ILoginRepo
    {
         Task<Login> GetLoginDetail(string UserName, string Password);
        Task<Login> ResetPassword(string password, string oldPassword);
         Task<Login> CheckUsername(string userName);
        Task<PasswordResetRequest> AddCode(PasswordResetRequest passwordResetRequest);

    }
}
