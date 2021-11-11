using MediatR;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetAll
{
    public class VideoGetAllCommand : IRequest<List<VideoGetAllDto>>
    {
    }
}
