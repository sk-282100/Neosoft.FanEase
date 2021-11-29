using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign
{
    public class GetTopCampaignDto
    {
        public long ClickCount { get; set; }
        public long ViewCount { get; set; }
        public long LikeCount { get; set; }
        public string CampaignName { get; set; }

    }
}
