using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class VideoRepo : BaseRepository<VideoDetail>, IVideoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public VideoRepo(ApplicationDbContext dbContext, ILogger<VideoDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<VideoDetail> GetByIdAsync(long id)
        {
            return await _dbContext.VideoDetails.FirstOrDefaultAsync(p => p.VideoId == id);
        }
        public async Task<List<VideoDetail>> GetCreatedByIdAsync(long id)
        {
            var listofVideos = await _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.IsDeleted == false).ToListAsync();
            return listofVideos;
        }
    }
}
