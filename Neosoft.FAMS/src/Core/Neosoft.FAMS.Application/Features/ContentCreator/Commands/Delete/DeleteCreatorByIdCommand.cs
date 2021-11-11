using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete
{
    public class DeleteCreatorByIdCommand : IRequest<Response<bool>>
    {
        public long CreatorId { get; set; }
    }
}
