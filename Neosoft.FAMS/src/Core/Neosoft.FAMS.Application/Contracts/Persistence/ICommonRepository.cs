using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
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
