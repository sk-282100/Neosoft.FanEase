using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    class GetPhoneCodeQueryHandler : IRequestHandler<GetPhoneCodeQuery, long>
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        public GetPhoneCodeQueryHandler(IMapper mapper, ICommonRepository commonRepository)
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
        }

        public async Task<long> Handle(GetPhoneCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _commonRepository.GetCountryById(request.countryId);
            return long.Parse(data.PhoneCode);
        }
    }
}
