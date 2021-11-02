﻿using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<City>> GetCityListByStateId(int stateId) {
            return await _dbContext.Cities.Where(x => x.StateId== stateId).ToListAsync();
        }
    }
}
