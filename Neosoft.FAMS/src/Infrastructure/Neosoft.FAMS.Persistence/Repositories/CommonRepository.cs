using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class CommonRepository : BaseRepository<Country>, ICommonRepository
    {
        private new readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public CommonRepository(ApplicationDbContext dbContext, ILogger<Country> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<States>> GetStateListByCountryId(int countryId)
        {
            return await _dbContext.State.Where(x => x.CountryId == countryId).ToListAsync();
        }
        public async Task<List<City>> GetCityListByStateId(int stateId)
        {
            return await _dbContext.Cities.Where(x => x.StateId == stateId).ToListAsync();
        }

        public async Task<Country> GetCountryById(long countryId)
        {
            return await _dbContext.Countries.Where(p => p.CountryId == countryId).FirstOrDefaultAsync();
        }
    }
}
