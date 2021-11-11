using MediatR;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetById
{
    public class VideoGetByIdCommand : IRequest<VideoGetAllDto>
    {
        public long VideoId { get; set; }
    }
}
