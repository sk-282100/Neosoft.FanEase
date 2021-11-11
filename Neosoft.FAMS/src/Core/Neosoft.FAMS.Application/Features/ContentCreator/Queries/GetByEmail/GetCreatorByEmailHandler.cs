using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetByEmail
{
    class GetCreatorByEmailHandler : IRequestHandler<GetCreatorByEmailQuery, ContentCreatorDto>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IMapper _mapper;
        public GetCreatorByEmailHandler(IContentCreatorRepo creatorRepo, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
        }

        public async Task<ContentCreatorDto> Handle(GetCreatorByEmailQuery request, CancellationToken cancellationToken)
        {
            var data = await _creatorRepo.GetByEmailAsync(request.Username);
            var response = _mapper.Map<ContentCreatorDto>(data);
            return response;
        }
    }
}
