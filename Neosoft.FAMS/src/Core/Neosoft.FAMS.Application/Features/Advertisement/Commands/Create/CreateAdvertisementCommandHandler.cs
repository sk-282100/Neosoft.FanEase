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

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.Create
{
    public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, Response<long>>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public CreateAdvertisementCommandHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAdvertisementValidator(_advertisementRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var data =  await _advertisementRepo.AddAsync(_mapper.Map<AdvertisementDetail>(request));
            var response = new Response<long> { Data = data.AdvertisementId, Message = "Added Successfully", Succeeded = true };
            return response;
        }
    }
}
