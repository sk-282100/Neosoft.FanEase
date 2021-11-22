using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

namespace Neosoft.FAMS.Persistence.Repositories
{
    public class AdminDashboardRepo : BaseRepository<VideoDetail>, IAdminDashboard
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public AdminDashboardRepo(ApplicationDbContext dbContext, ILogger<VideoDetail> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }

        public List<object> GetTopCampaigns()
        {

            var data = (from VSvID in _dbContext.VideoStatisticsDetails.Where(p => p.IsClicked == true)
                        join CMvID in _dbContext.CampaignAdvertiseMappings
                        on VSvID.VideoId equals CMvID.VideoId 
                        join CDID in _dbContext.CampaignDetails
                        on CMvID.CampaignId equals CDID.CampaignId
                        select new
                        {
                            VSvID.VideoId,
                            CDID.CampaignName,
                           

                        }).ToList();



            List<object> campaignName = new List<object>();
            var groupedData = data.GroupBy(c => c.VideoId).ToList();
            var counts = 0;
            var Name = "";

            foreach (var gd in groupedData)
            {
                var county = gd.ToList();
                counts = county.Count();
                Name = county[0].CampaignName;
                campaignName.Add(Name);
                campaignName.Add(county.Count());
            }



            return campaignName;
        }

        public List<long> GetYearlyStats(long years)
        {
            List<long> data = new List<long>();
            var year = _dbContext.VideoDetails.Where(p => p.CreatedOn.Value.Year == years && p.IsDeleted == false);
            for (int i = 1; i <= 12; i++)
            {
                var months = year.Where(p => p.CreatedOn.Value.Month == i).Count();
                data.Add(months);
            }
            return data;
        }
    }
}
