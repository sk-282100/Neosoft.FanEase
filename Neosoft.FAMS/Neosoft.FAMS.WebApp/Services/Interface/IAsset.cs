using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;

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
