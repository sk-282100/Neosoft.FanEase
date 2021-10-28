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

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Delete
{
    class DeleteCampaignByIdCommandHandler: IRequestHandler<DeleteCampaignByIdCommand, Response<bool>>
    {
        private readonly ICampaignDetailRepo _campaignDetailRepo;
        private readonly IMapper _mapper;
        public DeleteCampaignByIdCommandHandler(ICampaignDetailRepo campaignDetailRepo, IMapper mapper)
        {
            _campaignDetailRepo = campaignDetailRepo;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteCampaignByIdCommand request, CancellationToken cancellationToken)
        {
            _campaignDetailRepo.DeleteAsync(new CampaignDetail { CampaignId = request.CampaignId });

            var response = new Response<bool> { Data = true, Message = "Deleted Successfully", Succeeded = true };
            return response;
        }
    }
}
