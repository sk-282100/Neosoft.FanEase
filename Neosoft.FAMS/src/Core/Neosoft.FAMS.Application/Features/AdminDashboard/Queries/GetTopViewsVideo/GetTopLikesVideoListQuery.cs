using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetTopViewsVideo
{
    public class GetTopLikesVideoListQuery : IRequest<List<GetTopLikesVideoListDto>>
    {
    }
}
