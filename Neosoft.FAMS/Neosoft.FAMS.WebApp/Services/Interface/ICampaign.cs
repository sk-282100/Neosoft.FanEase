using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICampaign
    {
        public List<CampaignGetAllDto> GetAllCampaign();
        public Task<long> SaveCampaignDetail(CampaignCreateCommand campaignCreateCommand);
    }
}
