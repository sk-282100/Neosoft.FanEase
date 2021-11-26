using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class LoginRepo : BaseRepository<Login>, ILoginRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LoginRepo(ApplicationDbContext dbContext, ILogger<Login> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Login> GetLoginDetail(string userName, string Password)
        {
            var data = await _dbContext.ContentCreatorDetails.Where(e => e.EmailId == userName).FirstOrDefaultAsync();
            if (data != null)
            {
                if (data.isDeleted == true)
                    return null;
            }

            //return await _dbContext.Logins.FirstOrDefaultAsync(u => u.Username == userName);
            return await _dbContext.Logins.FirstOrDefaultAsync(u => u.Username == userName && u.Password==Password);
        }
        public async Task<Login> CheckUsername(string userName)
        {
            return await _dbContext.Logins.FirstOrDefaultAsync(u => u.Username == userName);
        }
        public async Task<Login> ResetPassword(string userName, string Password)
        {
            return await _dbContext.Logins.FirstOrDefaultAsync(u=>u.Username==userName && u.Password==Password);
        }

        public async Task<PasswordResetRequest> AddCode(PasswordResetRequest passwordResetRequest)
        {
            var data = new PasswordResetRequest { LoginId = passwordResetRequest.LoginId, RequestedOn = passwordResetRequest.RequestedOn, ValidCode = passwordResetRequest.ValidCode, ExpiredOn = passwordResetRequest.ExpiredOn };
            await _dbContext.PasswordResetRequests.AddAsync(data);
            await _dbContext.SaveChangesAsync();

            //await _dbContext.PasswordResetRequests.AddAsync(passwordResetRequest);

            return data;
        }

        public Task<PasswordResetRequest> CheckOtp(long LoginId,string Otp)
        {
            var result = _dbContext.PasswordResetRequests.OrderByDescending(i => i.RequestId).FirstOrDefaultAsync(u=>u.LoginId==LoginId && u.ValidCode==Otp);
            return result;
        }

    }
}
