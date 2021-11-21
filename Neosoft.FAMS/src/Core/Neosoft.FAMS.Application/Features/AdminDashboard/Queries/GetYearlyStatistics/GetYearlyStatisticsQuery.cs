using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetYearlyStatistics
{
    public class GetYearlyStatisticsQuery: IRequest<List<long>>
    {
        public long year { get; set; }
    }
}
