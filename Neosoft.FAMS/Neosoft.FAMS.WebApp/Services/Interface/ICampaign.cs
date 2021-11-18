using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Delete;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICampaign
    {
        public List<CampaignGetAllDto> GetAllCampaign();
        public Task<long> SaveCampaignDetail(CampaignCreateCommand campaignCreateCommand);
        public CampaignGetAllDto GetCampaignById(long id);
        public Task<bool> UpdateCampaignDetail(UpdateCampaignCommand update);
        public Task<bool> DeleteCampaign(DeleteCampaignByIdCommand command);
        public long GetMappedVideoIdCampaign(long campaignId);
    }
}
