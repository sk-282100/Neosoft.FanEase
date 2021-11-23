using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IVideoPageRepository:IAsyncRepository<VideoStatisticsDetail>
    {
        Task<VideoStatisticsDetail> CheckClickId(long viewerId,long videoId);
        List<long> GetAllVideoStatisticsById(long id);
        Task<long> GetLikesById(long id);
        Task<long> GetDislikesById(long id);
        Task<VideoStatisticsDetail> UpdateLike(long id, long viewerId);
        Task<VideoStatisticsDetail> UpdateDislike(long id, long viewerId);
        Task<long> GetViewsById(long id);
        Task<long> GetSharesById(long id);
        Task<VideoStatisticsDetail> UpdateViews(long id, long viewerId);
        long GetViewCount();
        Task<List<VideoStatisticsDetail>> GetLatestViews();
        List<long> GetTopVideos();
        List<VideoDetail> GetAllVideos();
        public Task<VideoStatisticsDetail> GetByIdAsync(long id);
        Task<long> GetLatestCreatorViews(long id);
        Task<long> GetLatestCreatorLikes(long id);
        Task<bool> CheckLikeById(long VideoId,long ViewerId);
    }
}
