using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class AdvertisementRepo : BaseRepository<AdvertisementDetail>, IAdvertisementRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public AdvertisementRepo(ApplicationDbContext dbContext, ILogger<AdvertisementDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<AdvertisementDetail> GetByIdAsync(long id)
        {
            return await _dbContext.AdvertisementDetails.FirstOrDefaultAsync(p => p.AdvertisementId == id);
        }

        public async Task<CampaignAdvertiseMapping> AddMapperDataAsync(CampaignAdvertiseMapping entity)
        {
            var result = await _dbContext.CampaignAdvertiseMappings.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            result.Entity.CampaignAdvertiseMappingId = await _dbContext.CampaignAdvertiseMappings.MaxAsync(u => u.CampaignAdvertiseMappingId);
            return result.Entity;
        }

        public async Task<List<AdvertisementDetail>> GetAllById(long id)
        {
            return await _dbContext.AdvertisementDetails.Where(p => p.AdvertisementId == id).ToListAsync();
        }
    }
}
