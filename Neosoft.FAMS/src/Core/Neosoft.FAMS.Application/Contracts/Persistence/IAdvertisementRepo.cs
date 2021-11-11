using Neosoft.FAMS.Domain.Entities;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IAdvertisementRepo : IAsyncRepository<AdvertisementDetail>
    {
        public Task<AdvertisementDetail> GetByIdAsync(long id);
        public Task<CampaignAdvertiseMapping> AddMapperDataAsync(CampaignAdvertiseMapping entity);
    }
}
