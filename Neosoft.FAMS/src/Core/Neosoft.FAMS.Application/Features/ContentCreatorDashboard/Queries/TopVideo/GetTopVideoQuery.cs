using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopVideo
{
    public class GetTopVideoQuery : IRequest<List<GetTopVideoDto>>
    {
        public long ContentCreatorId { get; set; }
    }
}
