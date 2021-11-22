using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<VideoDetail>
    {
        Task<VideoDetail> GetByIdAsync(long id);
        Task<List<VideoDetail>> GetCreatedByIdAsync(long id);
        int GetTotalVideoByIdAsync(long id);
        Task<string> GetCampaignName(long VideoId);
        int GetTotalVideoViewsByIdAsync(long id);
        int GetTotalVideoClicksByIdAsync(long id);
        Task<List<VideoDetail>> GetLatestVideo();
        Task<List<VideoDetail>> GetLatestCreatorVideos(long id);
    }
}
