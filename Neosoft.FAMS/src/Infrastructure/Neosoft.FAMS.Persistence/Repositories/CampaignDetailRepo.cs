using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class CampaignDetailRepo : BaseRepository<CampaignDetail>, ICampaignDetailRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public CampaignDetailRepo(ApplicationDbContext dbContext, ILogger<CampaignDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<CampaignDetail>> GetAllAsync()
        {
            //List<VideoDetail> result = new List<VideoDetail>();
            var temp = _dbContext.CampaignDetails.Where(p => p.IsDeleted == false && p.EndDate >= DateTime.Now);
            var result = (from vd in temp
                join CC in _dbContext.ContentCreatorDetails
                    on vd.CreatedBy equals CC.ContentCreatorId
                select vd);

            return result.ToList();
        }

        public async Task<CampaignDetail> GetByIdAsync(long id)
        {
            return await _dbContext.CampaignDetails.FirstOrDefaultAsync(p => p.CampaignId == id);
        }
    }
}
