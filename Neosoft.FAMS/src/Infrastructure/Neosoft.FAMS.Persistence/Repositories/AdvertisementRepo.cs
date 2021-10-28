﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class AdvertisementRepo : BaseRepository<AdvertisementDetail>,IAdvertisementRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public AdvertisementRepo(ApplicationDbContext dbContext, ILogger<AdvertisementDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<AdvertisementDetail> GetByIdAsync(long id)
        {
            return await _dbContext.AdvertisementDetails.FirstOrDefaultAsync(p => p.AdvertisementId == id);
        }
    }
}
