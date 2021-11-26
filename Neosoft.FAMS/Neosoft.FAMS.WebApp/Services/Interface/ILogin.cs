using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword;
using Neosoft.FAMS.Application.Features.Login.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ILogin
    {
        public Task<Domain.Entities.Login> CheckUsernameAndPassword(string userName, string password);
        Task<bool> SavePassword(ResetPasswordCommand resetPasswordCommand);
        Task<bool> SaveOTP(CheckUsernameCommand checkUsernameCommand);
        Task<int> CheckOTP(CheckOtpQuery checkOtpQuery);
        Task<bool> ForgotPassword(ForgotPasswordCommand forgotPasswordCommand);
    }
}
