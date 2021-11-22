using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetYearlyStats
{
    public class GetYearlyStatisticQueryHandler : IRequestHandler<GetYearlyStatisticQuery, List<long>>
    {
        private readonly ICreatorDashboard _creatorDashboard;
        public GetYearlyStatisticQueryHandler(ICreatorDashboard creatorDashboard)
        {
            _creatorDashboard=creatorDashboard;
        }
        public Task<List<long>> Handle(GetYearlyStatisticQuery request, CancellationToken cancellationToken)
        {
            var result = _creatorDashboard.GetYearlyStats(request.ContentCreatorId,request.year);
            return Task.FromResult(result);

        }
    }
}
