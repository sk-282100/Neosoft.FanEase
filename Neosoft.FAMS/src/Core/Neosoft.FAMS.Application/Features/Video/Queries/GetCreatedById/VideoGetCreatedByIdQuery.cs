using MediatR;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetCreatedById
{
    public class VideoGetCreatedByIdQuery : IRequest<List<VideoGetAllDto>>
    {
        public long CreatedById { get; set; }
    }
}
