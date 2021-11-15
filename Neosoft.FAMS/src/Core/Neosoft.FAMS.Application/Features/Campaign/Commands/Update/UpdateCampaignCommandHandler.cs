using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
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
            var validator = new UpdateCampaignValidator(_campaignDetailRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            request.IsDeleted = false;

            var update = _mapper.Map<CampaignDetail>(request);
            await _campaignDetailRepo.UpdateAsync(update);

            var Response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
            return Response;
        }
    }
}
