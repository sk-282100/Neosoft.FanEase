using MediatR;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;

using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetById
{
    public class VideoGetByIdCommand : IRequest<VideoGetAllDto>
    {
        public long VideoId { get; set; }
    }
}
