using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    public class GetAllCountryListHandler : IRequestHandler<GetAllCountryListQuery, Response<IEnumerable<Country>>>
    {
        private readonly IAsyncRepository<Country> _countryRepository;
        private readonly IMapper _mapper;
        public GetAllCountryListHandler(IMapper mapper, IAsyncRepository<Country> countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        public async Task<Response<IEnumerable<Country>>> Handle(GetAllCountryListQuery request, CancellationToken cancellationToken)
        {
            var allCountryList = (await _countryRepository.ListAllAsync());
            var CountryList = _mapper.Map<List<Country>>(allCountryList);
            var response = new Response<IEnumerable<Country>>(CountryList);
            return response;
        }
    }
}
