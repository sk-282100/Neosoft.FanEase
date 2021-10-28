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
    public class VideoRepo:BaseRepository<VideoDetail>, IVideoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public VideoRepo(ApplicationDbContext dbContext, ILogger<VideoDetail> logger) : base(dbContext,logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<VideoDetail> GetByIdAsync(long id)
        {
            return await _dbContext.VideoDetails.FirstOrDefaultAsync(p => p.VideoId == id);
        }

    }
}
