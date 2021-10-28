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

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Create
{
    class ContentCreaterCommandHandler : IRequestHandler<ContentCreaterCommand, Response<long>>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IMapper _mapper;
        public ContentCreaterCommandHandler(IContentCreatorRepo creatorRepo, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(ContentCreaterCommand request, CancellationToken cancellationToken)
        {
            var validator = new ContentCreatorCommandValidator(_creatorRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            string password = "Pass123";
            var createrData = await _creatorRepo.AddLoginDetailAsync(request.EmailId,password);

            var record = _mapper.Map<ContentCreatorDetail>(request);
            record.CreatedOn = DateTime.Now;
            var data = await _creatorRepo.AddAsync(record);
            var response = new Response<long>(data.ContentCreatorId, "Inserted successfully ");
            return response;
        }
    }
}
