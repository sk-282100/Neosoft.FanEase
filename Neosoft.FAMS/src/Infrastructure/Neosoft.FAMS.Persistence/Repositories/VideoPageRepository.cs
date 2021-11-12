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
    public class VideoPageRepository : BaseRepository<VideoStatisticsDetail>, IVideoPageRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public VideoPageRepository(ApplicationDbContext dbContext, ILogger<VideoStatisticsDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
       
        
        public async Task<VideoStatisticsDetail> CheckClickId(long id)
        {
            return await _dbContext.VideoStatisticsDetails.FirstOrDefaultAsync(p => p.ClickedBy == id);
        }
    }
}
