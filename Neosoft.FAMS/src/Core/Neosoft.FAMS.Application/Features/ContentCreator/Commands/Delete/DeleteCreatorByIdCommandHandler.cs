using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete
{
    class DeleteCreatorByIdCommandHandler : IRequestHandler<DeleteCreatorByIdCommand, Response<bool>>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IMapper _mapper;
        public DeleteCreatorByIdCommandHandler(IContentCreatorRepo creatorRepo, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteCreatorByIdCommand request, CancellationToken cancellationToken)
        {
             _creatorRepo.DeleteAsync(new ContentCreatorDetail { ContentCreatorId=request.CreatorId});

            var response = new Response<bool> { Data = true, Message = "Deleted Successfully" ,Succeeded=true};
            return response;
        }
    }
}
