using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
  public  class UserRepository : BaseRepository<UserDemo>, IUserRepository
    {
        private readonly ILogger _logger;
        public UserRepository(ApplicationDbContext dbContext, ILogger<UserDemo> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<UserDemo>> GetAllUserList()
        {
            _logger.LogInformation("GetAllUserList Initiated");
            var allUsersList = await _dbContext.Users.ToListAsync();
            _logger.LogInformation("GetCategoriesWithEvents Completed");
            return allUsersList;
        }

        //public async Task<UserDemo> SaveUserDetail(UserDemo user) {
        //    _logger.LogInformation("SaveUserDetail Initiated");
        //    await _dbContext.Users.AddAsync(user);
        //    _logger.LogInformation("SaveUserDetail Completed");
        //    return user;
        //}
    }
}
