using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IAdminDashboard
    {
        public List<long> GetAdminStats();
        public List<GetTopVideoDto> GetTopVideo();
        public List<GetTopCampaignDto> GetTopCampaignName();
        public List<long> GetYearlyStatistics(long year);
        public List<long> GetYearlyLiveStatistics(long year);
    }
}
