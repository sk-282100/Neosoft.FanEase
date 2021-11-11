using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICampaign
    {
        public List<CampaignGetAllDto> GetAllCampaign();
        public Task<long> SaveCampaignDetail(CampaignCreateCommand campaignCreateCommand);
    }
}
