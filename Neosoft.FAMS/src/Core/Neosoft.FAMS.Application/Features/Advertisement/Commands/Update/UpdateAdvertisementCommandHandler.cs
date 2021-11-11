using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.Update
{
    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, Response<bool>>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public UpdateAdvertisementCommandHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAdvertisementValidator(_advertisementRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var update = _mapper.Map<AdvertisementDetail>(request);
            await _advertisementRepo.UpdateAsync(update);

            var Response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
            return Response;
        }
    }
}
