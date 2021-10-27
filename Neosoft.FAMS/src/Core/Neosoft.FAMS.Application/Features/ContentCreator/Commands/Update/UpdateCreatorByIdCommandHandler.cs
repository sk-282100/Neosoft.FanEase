using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Exceptions;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update
{
    public class UpdateCreatorByIdCommandHandler : IRequestHandler<UpdateCreatorByIdCommand, Response<bool>>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IMapper _mapper;
        public UpdateCreatorByIdCommandHandler(IContentCreatorRepo creatorRepo, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateCreatorByIdCommand request, CancellationToken cancellationToken)
        {

            
            var update = _mapper.Map<ContentCreatorDetail>(request);
            await _creatorRepo.UpdateAsync(update);

            var Response = new Response<bool> { Data=true,Message="Updated Successfully",Succeeded=true};
            return Response;


        }
    }
}
