using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign
{
    public class GetTopCampaignQueryHandler : IRequestHandler<GetTopCampaignQuery, List<GetTopCampaignDto>>
    {
        
        private readonly IAdminDashboard _adminDashboard;
        
        public GetTopCampaignQueryHandler( IAdminDashboard adminDashboard)
        {
             _adminDashboard = adminDashboard;
        }

        public  Task<List<GetTopCampaignDto>> Handle(GetTopCampaignQuery request, CancellationToken cancellationToken)
        {
            List<GetTopCampaignDto> campaignDetails = new List<GetTopCampaignDto>();
            var data =  _adminDashboard.GetTopCampaigns();
            
            //return Task.FromResult(data);
            for(int i = 0; i<(data.Count-1);i+=2 )
            {
                var temp = data[i + 1].ToString();
                campaignDetails.Add(new GetTopCampaignDto()
                {
                    CampaignName =data[i].ToString(),
                    ClickCount = int.Parse(temp)

                });;

            }
            return Task.FromResult(campaignDetails.OrderByDescending(p => p.ClickCount).ToList());
        }
    }
}
