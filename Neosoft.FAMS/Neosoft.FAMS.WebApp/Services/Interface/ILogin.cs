using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Queries;
using Neosoft.FAMS.Application.Features.Users.Queries;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
  public  interface ILogin
    {
        public int CheckUsernameAndPassword(string userName, string password);
        Task<bool> SavePassword(ResetPasswordCommand resetPasswordCommand);
        Task<bool> SaveOTP(CheckUsernameCommand checkUsernameCommand);
        Task<int> CheckOTP(CheckOtpQuery checkOtpQuery);
    }
}
