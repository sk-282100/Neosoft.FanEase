using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Delete
{
    class DeleteCampaignByIdCommandHandler : IRequestHandler<DeleteCampaignByIdCommand, Response<bool>>
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
            var data = await _campaignDetailRepo.GetByIdAsync(request.CampaignId);
            if (data != null)
            {
                await _campaignDetailRepo.DeleteAsync(data);
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
