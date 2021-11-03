﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;

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

        public async Task<CampaignAdvertiseMapping> AddMapperDataAsync(CampaignAdvertiseMapping entity)
        {
            var result = await _dbContext.CampaignAdvertiseMappings.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            result.Entity.CampaignAdvertiseMappingId = await _dbContext.CampaignAdvertiseMappings.MaxAsync(u => u.CampaignAdvertiseMappingId);
            return result.Entity;
        }
    }
}
