using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class VideoRepo : BaseRepository<VideoDetail>, IVideoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public VideoRepo(ApplicationDbContext dbContext, ILogger<VideoDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<VideoDetail> GetByIdAsync(long id)
        {
            return await _dbContext.VideoDetails.FirstOrDefaultAsync(p => p.VideoId == id);
        }
        public async Task<string> GetCampaignName(long VideoId)
        {
            var campaignId = await _dbContext.CampaignAdvertiseMappings.Where(p => p.VideoId == VideoId)
                .Select(p => p.CampaignId).FirstOrDefaultAsync();
            return await _dbContext.CampaignDetails.Where(c => c.CampaignId == campaignId).Select(c => c.CampaignName)
                .FirstOrDefaultAsync();
        }
        public async Task<List<VideoDetail>> GetCreatedByIdAsync(long id)
        {
            var listofVideos = await _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.IsDeleted == false).ToListAsync();
            return listofVideos;
        }
        public int GetTotalVideoByIdAsync(long id)
        {
            var listofVideos = _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.IsDeleted == false).Count();
            return listofVideos;
        }
        public int GetTotalVideoViewsByIdAsync(long id)
        {
            var listofVideos = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsViewed==true).Count();
            return listofVideos;
        }
        public int GetTotalVideoClicksByIdAsync(long id)
        {
            var listofVideos = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsClicked == true).Count();
            return listofVideos;
        }
    }
}
