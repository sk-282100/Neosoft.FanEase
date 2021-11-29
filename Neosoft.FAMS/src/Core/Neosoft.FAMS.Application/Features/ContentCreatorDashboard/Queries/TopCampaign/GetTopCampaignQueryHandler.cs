using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopCampaign
{
    public class GetTopCampaignQueryHandler : IRequestHandler<GetTopCampaignQuery, List<GetTopCampaignDto>>
    {
        private readonly ICreatorDashboard _creatorDashboard;

        public GetTopCampaignQueryHandler(ICreatorDashboard creatorDashboard)
        {
            _creatorDashboard = creatorDashboard;
        }

        public Task<List<GetTopCampaignDto>> Handle(GetTopCampaignQuery request, CancellationToken cancellationToken)
        {
            List<GetTopCampaignDto> campaignDetails = new List<GetTopCampaignDto>();
            var data = _creatorDashboard.GetTopCampaigns(request.ContentCreatorId);

            //return Task.FromResult(data);
            for (int i = 0; i < (data.Count - 1); i += 4)
            {
                var views = data[i + 1].ToString();
                var Clicks = data[i + 2].ToString();
                var Likes = data[i + 3].ToString();
                campaignDetails.Add(new GetTopCampaignDto()
                {
                    CampaignName = data[i].ToString(),
                    ViewCount = Convert.ToInt64(views),
                    ClickCount = Convert.ToInt64(Clicks),
                    LikeCount = Convert.ToInt64(Likes)

                }); ;

            }
            return Task.FromResult(campaignDetails.OrderByDescending(p => p.ClickCount).ThenByDescending(p => p.ViewCount).ThenByDescending(p => p.LikeCount).ToList());
        }
    }
}


