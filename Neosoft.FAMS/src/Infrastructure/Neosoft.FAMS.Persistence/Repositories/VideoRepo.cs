using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
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
            var temp = await _dbContext.VideoDetails.FirstOrDefaultAsync(p => p.VideoId == id);
            return temp;
        }
        public async Task<string> GetCampaignName(long VideoId)
        {
            var campaignId = await _dbContext.CampaignAdvertiseMappings.Where(p => p.VideoId == VideoId)
                .Select(p => p.CampaignId).FirstOrDefaultAsync();
            return await _dbContext.CampaignDetails.Where(c => c.CampaignId == campaignId && c.EndDate >= DateTime.Now).Select(c => c.CampaignName)
                .FirstOrDefaultAsync();
        }
        public async Task<List<VideoDetail>> GetCreatedByIdAsync(long id)
        {
            var listofVideos = await _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.IsDeleted == false && p.EndDate >= DateTime.Now).ToListAsync();
            return listofVideos;
        }
        public long GetAllVideoCount()
        {
            var temp = _dbContext.VideoDetails.Where(p => p.IsDeleted == false && p.EndDate >= DateTime.Now);
            var result = (from vd in temp
                          join CC in _dbContext.ContentCreatorDetails
                          on vd.CreatedBy equals CC.ContentCreatorId
                          select vd);

            return result.Count();
        }
        public int GetTotalVideoByIdAsync(long id)
        {
            var listofVideos = _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.IsDeleted == false &&  p.EndDate >= DateTime.Now).Count();
            return listofVideos;
        }
        public int GetTotalVideoViewsByIdAsync(long id)
        {
            var listofVideos = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsViewed == true).Count();
            return listofVideos;
        }
        public int GetTotalVideoClicksByIdAsync(long id)
        {
            var listofVideos = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsClicked == true).Count();
            return listofVideos;
        }

        public async Task<List<VideoDetail>> GetLatestVideo()
        {
            var data = await _dbContext.VideoDetails.Where(p => p.CreatedOn >= DateTime.Today && p.IsDeleted==false).OrderByDescending(p => p.VideoId).ToListAsync();
            return data;
        }

        public async Task<List<VideoDetail>> GetLatestCreatorVideos(long id)
        {
            var data = await _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.CreatedOn >= DateTime.Today && p.IsDeleted == false).OrderByDescending(p => p.VideoId).ToListAsync();
            return data;
        }

        public async Task<VideoDetail> GetCreatorVideo(long CreatorId, long VideoId)
        {
            var temp = await _dbContext.VideoDetails.Where(p => p.IsDeleted == false).FirstOrDefaultAsync(p => p.CreatedBy == CreatorId && p.VideoId == VideoId);
            return temp;
        }

        public async Task<List<VideoDetail>> GetAllVideos()
        {
            //List<VideoDetail> result = new List<VideoDetail>();
            var temp = _dbContext.VideoDetails.Where(p => p.IsDeleted == false && p.EndDate >= DateTime.Now);
            var result = (from vd in temp
                          join CC in _dbContext.ContentCreatorDetails
                          on vd.CreatedBy equals CC.ContentCreatorId
                          select vd);

            return result.ToList();

        }

    }
}
