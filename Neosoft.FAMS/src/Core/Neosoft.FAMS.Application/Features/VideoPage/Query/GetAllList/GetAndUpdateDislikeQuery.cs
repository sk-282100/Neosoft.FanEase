using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllList
{
    public class GetAndUpdateDislikeQuery : IRequest<long>
    {
        public long videoId { get; set; }
    }
}
