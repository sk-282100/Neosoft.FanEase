using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    public class GetAllStateListQueryHandler : IRequestHandler<GetAllStateListQuery, Response<IEnumerable<States>>>
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        public GetAllStateListQueryHandler(IMapper mapper, ICommonRepository commonRepository)
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
        }
        public async Task<Response<IEnumerable<States>>> Handle(GetAllStateListQuery request, CancellationToken cancellationToken)
        {
            var allStateList = (await _commonRepository.GetStateListByCountryId(request.countryId));
            var StateList = _mapper.Map<List<States>>(allStateList);
            var response = new Response<IEnumerable<States>>(StateList);
            return response;
        }
    }
}
