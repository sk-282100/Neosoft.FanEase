using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class ContentCreatorRepo : BaseRepository<ContentCreatorDetail>, IContentCreatorRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public ContentCreatorRepo(ApplicationDbContext dbContext, ILogger<ContentCreatorDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Login> AddLoginDetailAsync(string email,string password)
        {
            var user = new Login {Username=email,Password=password,RoleId=2 };
           var result= await _dbContext.AddAsync<Login>(user);
            return result.Entity;
        }
        public async Task<ContentCreatorDetail> GetByIdAsync(long id)
        {
            return await _dbContext.ContentCreatorDetails.FirstOrDefaultAsync(p => p.ContentCreatorId == id);
        }
    }
}
