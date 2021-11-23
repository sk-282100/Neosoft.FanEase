using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.CheckIsLikedById
{
    public class CheckIsLikedByIdQuery : IRequest<bool?>
    {
        public long VideoId { get; set; }
        public long ViewerId { get; set; }
    }
}
