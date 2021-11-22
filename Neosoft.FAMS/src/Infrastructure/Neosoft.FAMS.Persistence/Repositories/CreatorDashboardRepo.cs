using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public List<string> GetTopCampaigns(long id)
        {
            var data = (from VSvID in _dbContext.VideoStatisticsDetails.Where(p => p.IsLiked == true)

                join CMvID in _dbContext.CampaignAdvertiseMappings
                    on VSvID.VideoId equals CMvID.VideoId
                join CDID in _dbContext.CampaignDetails
                    on CMvID.CampaignId equals CDID.CampaignId
                //group VSvID by VSvID.VideoId into gb
                select new
                {
                    VSvID.VideoId,
                    CDID.CampaignName

                }).ToList();
            List<string> campaignName = new List<string>();
            var groupedData = data.GroupBy(c => c.VideoId).ToList();
            var counts = 0;
            var Name = "";

            foreach (var gd in groupedData)
            {
                var county = gd.ToList();
                counts = county.Count();
                Name = county[0].CampaignName;
                campaignName.Add(Name);
            }



            return campaignName;
        }

        public List<long> GetYearlyStats(long id,long years)
        {
            List<long> data = new List<long>();
            var year = _dbContext.VideoDetails.Where(p => p.CreatedOn.Value.Year == years && p.IsDeleted == false && p.CreatedBy==id);
            for (int i = 1; i <= 12; i++)
            {
                var months = year.Where(p => p.CreatedOn.Value.Month == i).Count();
                data.Add(months);
            }
            return data;
        }
    }
}
