using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetYearlyStatistics
{
    public class GetYearlyStatisticsQueryHandler : IRequestHandler<GetYearlyStatisticsQuery, List<long>>
    {
        private readonly IAdminDashboard _adminDashboard;
        public GetYearlyStatisticsQueryHandler(IAdminDashboard adminDashboard)
        {
            _adminDashboard = adminDashboard;
        }

        public Task<List<long>> Handle(GetYearlyStatisticsQuery request, CancellationToken cancellationToken)
        {
            
            var result = _adminDashboard.GetYearlyStats(request.year);
            return Task.FromResult(result);
            
        }
    }
}
