using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class ContentCreatorRepo : BaseRepository<ContentCreatorDetail>, IContentCreatorRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public ContentCreatorRepo(ApplicationDbContext dbContext, ILogger<ContentCreatorDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}
