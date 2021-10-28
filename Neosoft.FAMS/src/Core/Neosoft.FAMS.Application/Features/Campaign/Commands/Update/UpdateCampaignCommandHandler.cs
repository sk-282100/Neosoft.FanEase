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

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Update
{
    class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Response<bool>>
    {

        private readonly ICampaignDetailRepo _campaignDetailRepo;
        private readonly IMapper _mapper;
        public UpdateCampaignCommandHandler(ICampaignDetailRepo campaignDetailRepo, IMapper mapper)
        {
            _campaignDetailRepo = campaignDetailRepo;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var update = _mapper.Map<CampaignDetail>(request);
            await _campaignDetailRepo.UpdateAsync(update);

            var Response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
            return Response;
        }
    }
}
