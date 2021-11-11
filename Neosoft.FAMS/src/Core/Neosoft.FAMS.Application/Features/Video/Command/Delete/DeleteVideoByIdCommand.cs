using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.Video.Commands.Delete
{
    public class DeleteVideoByIdCommand : IRequest<Response<bool>>
    {
        public long VideoId { get; set; }
    }
}
