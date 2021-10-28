using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetAll
{
    public class VideoGetAllCommand : IRequest<List<VideoGetAllDto>>
    {
    }
}
