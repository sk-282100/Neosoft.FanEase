using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<VideoStatisticsDetail>> GetAllVideoStatisticsById(long id)
        {
            var listofVideos = await _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id).ToListAsync();
            return listofVideos;
        }
        public async Task<long> GetLikesById(long id)
        {
            long likes =  _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsLiked == true).Count();
            return likes;
        }
        public async Task<long> GetDislikesById(long id)
        {
            long likes = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsLiked == false).Count();
            return likes;
        }

        public async Task<VideoStatisticsDetail> UpdateLike(long id, long viewerId)
        {
            var modify = await _dbContext.VideoStatisticsDetails.FirstOrDefaultAsync(m => m.VideoId == id && m.LikeBy == viewerId);
            return modify;
        }
        public async Task<VideoStatisticsDetail> UpdateDislike(long id, long viewerId)
        {
            var modify = await _dbContext.VideoStatisticsDetails.FirstOrDefaultAsync(m => m.VideoId == id && m.LikeBy == viewerId);
            return modify;
        }

        public async Task<long> GetViewsById(long id)
        {
            long views = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsViewed == true).Count();
            return views;
        }

        public async Task<VideoStatisticsDetail> UpdateViews(long id, long viewerId)
        {
            var modify = await _dbContext.VideoStatisticsDetails.FirstOrDefaultAsync(m => m.VideoId == id && m.ViewBy == viewerId);
            return modify;
        }
    }
}
