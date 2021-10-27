using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using static Neosoft.FAMS.Application.Contracts.Persistence.ILoginRepo;
using System.Threading.Tasks;
using System.Linq;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class LoginRepo:ILoginRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LoginRepo(ApplicationDbContext dbContext, ILogger<Login> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Login> GetLoginDetail(string userName, string Password)
        {
            return await _dbContext.Logins.FirstOrDefaultAsync(u => u.Username == userName);
        }
        public async Task<Login> CheckUsername(string userName)
        {
            return await _dbContext.Logins.FirstOrDefaultAsync(u => u.Username == userName);
        }
        public async Task<Login> ResetPassword(string password, string oldPassword)
        {
            return await _dbContext.Logins.FirstOrDefaultAsync(u => u.Password == oldPassword);
        }
    }
}
