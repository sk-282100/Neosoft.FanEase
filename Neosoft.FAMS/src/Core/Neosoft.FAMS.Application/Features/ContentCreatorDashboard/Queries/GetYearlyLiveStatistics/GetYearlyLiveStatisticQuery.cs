using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetYearlyLiveStatistics
{
    public class GetYearlyLiveStatisticQuery : IRequest<List<long>>
    {
        public long ContentCreatorId { get; set; }
        public long year { get; set; }
    }
}
