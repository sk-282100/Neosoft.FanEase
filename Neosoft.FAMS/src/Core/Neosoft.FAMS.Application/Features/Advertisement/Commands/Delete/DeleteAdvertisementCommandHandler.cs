using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete
{
    public class DeleteAdvertisementCommandHandler : IRequestHandler<DeleteAdvertisementCommand, Response<bool>>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public DeleteAdvertisementCommandHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var data = await _advertisementRepo.GetByIdAsync(request.AdvertisementId);
            data.IsDeleted = true;
            if (data != null)
            {

                //await _advertisementRepo.DeleteAsync(data);
                await _advertisementRepo.UpdateAsync(data);

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
