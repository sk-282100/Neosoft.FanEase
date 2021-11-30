using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetYearlyLiveStatistics
{
    public class GetYearlyLiveStatisticsQueryHandler : IRequestHandler<GetYearlyLiveStatisticsQuery, List<long>>
    {
        private readonly IAdminDashboard _adminDashboard;
        public GetYearlyLiveStatisticsQueryHandler(IAdminDashboard adminDashboard)
        {
            _adminDashboard = adminDashboard;
        }

        public Task<List<long>> Handle(GetYearlyLiveStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = _adminDashboard.GetYearlyLiveVideoStats(request.year);
            return Task.FromResult(result);
        }
    }
}
