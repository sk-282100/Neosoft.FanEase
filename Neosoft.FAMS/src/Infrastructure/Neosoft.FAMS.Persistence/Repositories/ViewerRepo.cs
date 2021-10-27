using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class ViewerRepo : BaseRepository<ViewerDetail>, IViewerRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public ViewerRepo(ApplicationDbContext dbContext, ILogger<ViewerDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ViewerDetail> GetByIdAsync(long id)
        {
            return await _dbContext.ViewerDetails.FirstOrDefaultAsync(p => p.ViewerId == id);

        }
    }
}
