using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllList
{
    public class GetAndUpdateLikeQuery:IRequest<List<long>>
    {
        public long videoId { get; set; }
        public long viewerId { get; set; }
    }
}
