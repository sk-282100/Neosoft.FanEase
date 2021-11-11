using MediatR;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll
{
    public class ViewerQuery : IRequest<List<ViewerDto>>
    {
    }
}
