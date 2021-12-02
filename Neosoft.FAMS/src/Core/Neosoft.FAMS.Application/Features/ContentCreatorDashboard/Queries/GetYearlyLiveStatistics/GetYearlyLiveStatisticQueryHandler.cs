using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetYearlyLiveStatistics
{
    public class GetYearlyLiveStatisticQueryHandler : IRequestHandler<GetYearlyLiveStatisticQuery, List<long>>
    {
        private readonly ICreatorDashboard _creatorDashboard;
        public GetYearlyLiveStatisticQueryHandler(ICreatorDashboard creatorDashboard)
        {
            _creatorDashboard = creatorDashboard;
        }

        public Task<List<long>> Handle(GetYearlyLiveStatisticQuery request, CancellationToken cancellationToken)
        {
            var result = _creatorDashboard.GetYearlyLiveVideoStats(request.ContentCreatorId,request.year);
            return Task.FromResult(result);
        }
    }
}