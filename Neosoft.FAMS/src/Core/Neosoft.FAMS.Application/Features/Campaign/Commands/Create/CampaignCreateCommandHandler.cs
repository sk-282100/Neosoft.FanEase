using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Create
{
    class CampaignCreateCommandHandler : IRequestHandler<CampaignCreateCommand, Response<long>>
    {

        private readonly ICampaignDetailRepo _campaignDetailRepo;
        private readonly IMapper _mapper;
        public CampaignCreateCommandHandler(ICampaignDetailRepo campaignDetailRepo, IMapper mapper)
        {
            _campaignDetailRepo = campaignDetailRepo;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CampaignCreateCommand request, CancellationToken cancellationToken)
        {

            var validator = new CampaignCreateValidator(_campaignDetailRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var record = _mapper.Map<CampaignDetail>(request);
            record.IsDeleted = false;
            var data = await _campaignDetailRepo.AddAsync(record);
            var response = new Response<long>(data.CampaignId, "Inserted successfully ");
            return response;
            /*var data = await _campaignDetailRepo.AddAsync(_mapper.Map<CampaignDetail>(request));
            var response = new Response<long>(data.CampaignId, "Inserted Successfully");
            return response;*/
        }
    }
}
