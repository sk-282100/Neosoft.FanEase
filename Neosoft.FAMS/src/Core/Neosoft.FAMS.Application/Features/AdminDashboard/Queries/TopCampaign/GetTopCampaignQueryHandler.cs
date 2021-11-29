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
            for(int i = 0; i<(data.Count-1);i+=4 )
            {
                var views = data[i + 1].ToString();
                var Clicks = data[i + 2].ToString();
                var Likes = data[i + 3].ToString();
                campaignDetails.Add(new GetTopCampaignDto()
                {
                    CampaignName =data[i].ToString(),
                    ViewCount = Convert.ToInt64(views),
                    ClickCount = Convert.ToInt64(Clicks),
                    LikeCount = Convert.ToInt64(Likes)

                });

            }
            return Task.FromResult(campaignDetails.OrderByDescending(p => p.ClickCount).ThenByDescending(p=>p.ViewCount).ThenByDescending(p=>p.LikeCount).ToList());
        }
    }
}
