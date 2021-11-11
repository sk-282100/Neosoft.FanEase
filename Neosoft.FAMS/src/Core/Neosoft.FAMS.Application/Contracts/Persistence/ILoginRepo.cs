using Neosoft.FAMS.Domain.Entities;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ILoginRepo : IAsyncRepository<Login>
    {
        Task<Login> GetLoginDetail(string UserName, string Password);
        Task<Login> ResetPassword(string UserName, string Password);
        Task<Login> CheckUsername(string userName);
        Task<PasswordResetRequest> AddCode(PasswordResetRequest passwordResetRequest);
        Task<PasswordResetRequest> CheckOtp(long id, string Otp);

    }
}
