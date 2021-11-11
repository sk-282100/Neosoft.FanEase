using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Delete
{
    public class DeleteViewerByIdCommand : IRequest<Response<bool>>
    {
        public long ViewerId { get; set; }
    }
}
