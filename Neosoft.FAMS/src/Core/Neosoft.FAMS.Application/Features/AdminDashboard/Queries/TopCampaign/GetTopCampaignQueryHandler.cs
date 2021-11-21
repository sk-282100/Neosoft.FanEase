using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign
{
    public class GetTopCampaignQueryHandler : IRequestHandler<GetTopCampaignQuery, List<string>>
    {
        
        private readonly IAdminDashboard _adminDashboard;
        
        public GetTopCampaignQueryHandler( IAdminDashboard adminDashboard)
        {
             _adminDashboard = adminDashboard;
        }

        public  Task<List<string>> Handle(GetTopCampaignQuery request, CancellationToken cancellationToken)
        {
            var data =  _adminDashboard.GetTopCampaigns();
            return Task.FromResult(data);
        }
    }
}
