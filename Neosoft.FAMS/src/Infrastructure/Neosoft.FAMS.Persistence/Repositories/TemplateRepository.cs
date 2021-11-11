using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class TemplateRepository : BaseRepository<TemplateDetail>, ITemplateRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public TemplateRepository(ApplicationDbContext dbContext,ILogger<TemplateDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
