using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class AdminDashboardRepo : BaseRepository<ContentCreatorDetail>, IAdminDashboard
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public AdminDashboardRepo(ApplicationDbContext dbContext, ILogger<ContentCreatorDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
