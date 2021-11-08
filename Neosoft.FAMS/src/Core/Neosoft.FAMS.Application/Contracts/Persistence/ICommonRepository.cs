using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ICommonRepository
    {
        Task<List<States>> GetStateListByCountryId(int countryId);
        Task<List<City>> GetCityListByStateId(int stateId);
        Task<Country> GetCountryById(long countryId);

    }
}
