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
    public class CreatorDashboardRepo : BaseRepository<VideoDetail>, ICreatorDashboard
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public CreatorDashboardRepo(ApplicationDbContext dbContext, ILogger<VideoDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }

        public async Task<List<VideoDetail>> GetCreatedByIdAsync(long id)
        {
            var listofVideos = await _dbContext.VideoDetails.Where(p => p.CreatedBy == id && p.IsDeleted == false && p.EndDate >= DateTime.Now).ToListAsync();
            return listofVideos;
        }
        public List<object> GetTopCampaigns(long id)
        {
            
            var data = (from VSvID in _dbContext.VideoStatisticsDetails.Where
                    (p => p.IsClicked == true)
                join VD in _dbContext.VideoDetails
                    on VSvID.VideoId equals VD.VideoId
                join CMvID in _dbContext.CampaignAdvertiseMappings
                    on VSvID.VideoId equals CMvID.VideoId
                join CDID in _dbContext.CampaignDetails
                    on CMvID.CampaignId equals CDID.CampaignId
                
                        select new
                {
                    VSvID.VideoId,
                    CDID.CampaignName,
                    VD.CreatedBy


                }).ToList();

            List<object> campaignName = new List<object>();
            var groupedData = data.GroupBy(c => c.VideoId).ToList();
            var counts = 0;
            var Name = "";

            foreach (var gd in groupedData)
            {
                var Likes = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == gd.Key && p.IsLiked == true).Count();
                var Clicks = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == gd.Key && p.IsClicked == true).Count();
                var Views = _dbContext.VideoStatisticsDetails.Where(p => p.VideoId == gd.Key && p.IsViewed == true).Count();

                var county = gd.ToList();
                if (county[0].CreatedBy == id)
                {
                    Name = county[0].CampaignName;
                    campaignName.Add(Name);
                    campaignName.Add(Views);
                    campaignName.Add(Clicks);
                    campaignName.Add(Likes);
                }
            }



            return campaignName;
        }


        public List<long> GetYearlyStats(long id,long years)
        {
            List<long> data = new List<long>();
            var year = _dbContext.VideoDetails.Where(p => (p.CreatedOn.Value.Year == years && p.IsDeleted == false) && p.CreatedBy==id);
            for (int i = 1; i <= 12; i++)
            {
                var months = year.Where(p => p.CreatedOn.Value.Month == i).Count();
                data.Add(months);
            }
            return data;
        }

    }
}
