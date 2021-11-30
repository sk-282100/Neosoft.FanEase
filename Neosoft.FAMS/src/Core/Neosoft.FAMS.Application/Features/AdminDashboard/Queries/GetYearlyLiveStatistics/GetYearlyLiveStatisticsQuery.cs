using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetYearlyLiveStatistics
{
    public class GetYearlyLiveStatisticsQuery : IRequest<List<long>>
    {
        public long year { get; set; }
    }
}
