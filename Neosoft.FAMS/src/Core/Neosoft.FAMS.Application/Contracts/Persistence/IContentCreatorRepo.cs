using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IContentCreatorRepo : IAsyncRepository<ContentCreatorDetail>
    {
        Task<ContentCreatorDetail> GetByIdAsync(long id);
        Task<List<CampaignAdvertiseMapping>> GetMappedDataByIdAsync(long id);
        Task<Login> AddLoginDetailAsync(string emailId, string password);
        Task<ContentCreatorDetail> GetByEmailAsync(string username);
        Task<List<ContentCreatorDetail>> GetAllCreator();
        List<long> GetAllVideoStatisticsById(long id);
    }
}
