using MediatR;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetByEmail
{
    public class GetViewerByEmailQuery : IRequest<ViewerDto>
    {
        public string Username { get; set; }
    }
}
