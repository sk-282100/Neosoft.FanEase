using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData;

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

        public async Task<List<ContentCreatorDetail>> GetLatestCreator()
        {
            var data= await _dbContext.ContentCreatorDetails.Where(p =>p.CreatedOn >= DateTime.Today && p.isDeleted == false ).OrderByDescending(p => p.ContentCreatorId).ToListAsync();
            return data;
        }

        public Task<MappedDto> GetMappedData()
        {
            throw new System.NotImplementedException();
        }


        public async Task <List<CampaignAdvertiseMapping>> GetMappedDataByIdAsync(long id)
        {
            return await _dbContext.CampaignAdvertiseMappings.Where(p => p.VideoId==id).ToListAsync();
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

        public List<long> GetAllVideoStatisticsById(long id)
        {
            long likes = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsLiked == true).Count();
            long views = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsViewed == true).Count();
            long clicks = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsClicked == true).Count();
            List<long> stats = new List<long>() { likes, views, clicks };
            return stats;
        }
    }
}
