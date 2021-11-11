using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<TemplateDetail> GetByIdAsync(long id)
        {
            return await _dbContext.Set<TemplateDetail>().Where(i => i.TemplateId == id).FirstOrDefaultAsync();
        }
    }
}
