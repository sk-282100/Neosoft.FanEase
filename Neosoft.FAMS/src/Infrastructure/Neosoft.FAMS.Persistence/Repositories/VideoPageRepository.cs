using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
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
        public async Task<VideoStatisticsDetail> CheckClickId(long viewerId, long videoId)
        {
            return await _dbContext.VideoStatisticsDetails.FirstOrDefaultAsync(p => p.ClickedBy == viewerId && p.VideoId == videoId);
        }
        public long GetViewCount()
        {
            var temp = _dbContext.VideoStatisticsDetails.Where(p => p.IsViewed == true);
            var result = (from vs in temp
                          join VD in _dbContext.VideoDetails.Where(p => p.IsDeleted == false && p.EndDate >= DateTime.Now)
                          on vs.VideoId equals VD.VideoId
                          join CD in _dbContext.ContentCreatorDetails
                          on VD.CreatedBy equals CD.ContentCreatorId
                          select vs);

           
            return result.Count();


        }
        public  List<long> GetAllVideoStatisticsById(long id)
        {
            
            //var listofVideos = await _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id).ToListAsync();
            long likes = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsLiked == true).Count();
            long dislikes = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsLiked == false).Count();
            long views  = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsViewed == true).Count();
            long shared = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsShared == true).Count();
            List<long> stats = new List<long>() {likes,dislikes,views,shared};
            return stats;
        }

        public  List<long> GetTopVideos()
        {
            var temp = _dbContext.VideoDetails.Where(p => p.IsDeleted == false && p.EndDate >= DateTime.Now);
            var result = (from vd in temp
                          join CC in _dbContext.ContentCreatorDetails
                          on vd.CreatedBy equals CC.ContentCreatorId
                          select vd);
            
            var data= result.Select(p => p.VideoId).Distinct().ToList();
            return data;

        }
        public List<VideoDetail> GetAllVideos()
        {
            var temp = _dbContext.VideoDetails.Where(p => p.IsDeleted == false && p.EndDate >= DateTime.Now);
            var result = (from vd in temp
                          join CC in _dbContext.ContentCreatorDetails
                          on vd.CreatedBy equals CC.ContentCreatorId
                          select vd);
            
            return result.ToList();

        }
        public async Task<VideoStatisticsDetail> GetByIdAsync(long id)
        {
            return await _dbContext.VideoStatisticsDetails.FirstOrDefaultAsync(p => p.VideoId == id);
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
        public async Task<long> GetSharesById(long id)
        {
            long likes = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.IsShared == true).Count();
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
        public async Task<List<VideoStatisticsDetail>> GetLatestViews()
        {
            var data = await _dbContext.VideoStatisticsDetails.Where(p => p.ViewOn >= DateTime.Today).OrderByDescending(p => p.VideoId).ToListAsync();
            return data;
        }

        public async Task<long> GetLatestCreatorViews(long id)
        {
            long data =  _dbContext.VideoStatisticsDetails.Where(p =>p.VideoId==id && p.ViewOn >= DateTime.Today).Count();
            return data;
        }

        public async Task<long> GetLatestCreatorLikes(long id)
        {
            long data =  _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == id && p.ViewOn >= DateTime.Today).Count();
            return data;
        }

        public async Task<bool?> CheckLikeById(long VideoId,long ViewerId)
        {
            var likes = await _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == VideoId && p.ViewBy==ViewerId && p.IsLiked != null).FirstOrDefaultAsync();
            if (likes != null)
                return likes.IsLiked;
            return null;
        }
    }
}
