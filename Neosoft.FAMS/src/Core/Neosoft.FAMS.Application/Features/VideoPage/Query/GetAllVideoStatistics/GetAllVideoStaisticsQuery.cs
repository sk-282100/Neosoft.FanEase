using MediatR;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics
{
    public class GetAllVideoStaisticsQuery: IRequest<List<GetAllVideoStatisticsDto>>
    {
        public long id { get; set; }
    }
}
