using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetCreatedById
{
    public class VideoGetCreatedByIdQuery : IRequest<List<VideoGetAllDto>>
    {
        public long CreatedById { get; set; }
    }
}
