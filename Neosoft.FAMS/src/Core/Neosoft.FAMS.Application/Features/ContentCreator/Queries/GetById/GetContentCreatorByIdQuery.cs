using MediatR;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetById
{
    public class GetContentCreatorByIdQuery : IRequest<ContentCreatorDto>
    {
        public long creatorId { get; set; }
    }
}
