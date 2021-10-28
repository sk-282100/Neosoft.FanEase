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
    public class CampaignDetailRepo : BaseRepository<CampaignDetail>, ICampaignDetailRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public CampaignDetailRepo(ApplicationDbContext dbContext, ILogger<CampaignDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CampaignDetail> GetByIdAsync(long id)
        {
            return await _dbContext.CampaignDetails.FirstOrDefaultAsync(p => p.CampaignId == id);
        }
    }
}
