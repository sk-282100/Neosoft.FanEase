using MediatR;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetById
{
    public class GetViewerByIdQuery : IRequest<ViewerDto>
    {
        public long ViewerId { get; set; }
    }
}
