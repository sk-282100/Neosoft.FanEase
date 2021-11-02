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

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    public class GetAllCityListQueryHandler : IRequestHandler<GetAllCityListQuery, Response<IEnumerable<City>>>
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;
        public GetAllCityListQueryHandler(IMapper mapper, ICommonRepository commonRepository)
        {
            _mapper = mapper;
            _commonRepository = commonRepository;
        }
        public async Task<Response<IEnumerable<City>>> Handle(GetAllCityListQuery request, CancellationToken cancellationToken)
        {
            var allCityList = (await _commonRepository.GetCityListByStateId(request.stateId));
            var CityList = _mapper.Map<List<City>>(allCityList);
            var response = new Response<IEnumerable<City>>(CityList);
            return response;
        }
    }
}
