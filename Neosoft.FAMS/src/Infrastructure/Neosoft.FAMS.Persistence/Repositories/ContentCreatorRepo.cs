using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class ContentCreatorRepo : BaseRepository<ContentCreatorDetail>, IContentCreatorRepo
    {
        private new readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public ContentCreatorRepo(ApplicationDbContext dbContext, ILogger<ContentCreatorDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<ContentCreatorDetail>> GetAllCreator()
        {
            return await _dbContext.ContentCreatorDetails.Where(p => p.isDeleted == false).OrderByDescending(p => p.ContentCreatorId).ToListAsync();
        }
        public async Task<Login> AddLoginDetailAsync(string email, string password)
        {
            var user = new Login { Username = email, Password = password, RoleId = 2 };
            var result = await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            result.Entity.Id = await _dbContext.Logins.MaxAsync(u => u.Id);
            return result.Entity;
        }

        public async Task<ContentCreatorDetail> GetByEmailAsync(string username)
        {
            return await _dbContext.ContentCreatorDetails.FirstOrDefaultAsync(p => p.EmailId == username);
        }

        public async Task<ContentCreatorDetail> GetByIdAsync(long id)
        {
            return await _dbContext.ContentCreatorDetails.FirstOrDefaultAsync(p => p.ContentCreatorId == id);
        }
    }
}
