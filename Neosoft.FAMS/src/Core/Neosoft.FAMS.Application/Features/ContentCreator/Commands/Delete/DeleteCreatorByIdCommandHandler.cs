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
            var data = await _creatorRepo.GetByIdAsync(request.CreatorId);
            data.isDeleted = true;
            if (data != null)
            {
               // await _creatorRepo.DeleteAsync(data);
               await _creatorRepo.UpdateAsync(data);

                var response = new Response<bool> { Data = true, Message = "Deleted Successfully", Succeeded = true };
                return response;
            }
            else
            {
                var response = new Response<bool> { Message = "No Data Found", Succeeded = true };
                return response;
            }

        }
    }
}
