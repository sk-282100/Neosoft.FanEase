using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<VideoDetail>
    {
        Task<VideoDetail> GetByIdAsync(long id);
        Task<List<VideoDetail>> GetCreatedByIdAsync(long id);
    }
}
