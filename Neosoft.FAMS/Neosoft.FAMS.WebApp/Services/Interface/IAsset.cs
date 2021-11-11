using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IAsset
    {
        public List<AdvertisementListQueryDto> GetAllAsset();
        public Task<long> SaveAssetDetail(CreateAdvertisementCommand createAdvertisementCommand);
        public Task<long> AddCampaignAdvertiseMappedData(AddCampaignAdvertisementCommand command);
        public AdvertisementListQueryDto GetAssetById(long id);
        public Task<bool> UpdateAssetDetail(UpdateAdvertisementCommand update);
        public Task<bool> DeleteAsset(DeleteAdvertisementCommand command);
    }
}
