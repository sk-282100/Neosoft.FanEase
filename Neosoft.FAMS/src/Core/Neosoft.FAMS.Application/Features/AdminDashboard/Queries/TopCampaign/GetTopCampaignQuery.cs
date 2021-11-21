using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign
{
    public class GetTopCampaignQuery: IRequest<List<string>>
    {
    }
}
