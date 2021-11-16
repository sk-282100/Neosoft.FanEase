using System;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetCreatorVideoStatistic
{
    public class GetCreatorVideoStatisticDto
    {
        public List<VideoDetail> VideoDetail { get; set; }
        public List<List<long>> VideoStatisticsDetails { get; set; }
    }
}
