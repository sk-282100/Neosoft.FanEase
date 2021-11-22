using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetCreatorStatisticById
{
    public class GetCreatorVideoStatisticQuery : IRequest<List<long>>
    {
        public long ContentCreatorId { get; set; }
    }
}
