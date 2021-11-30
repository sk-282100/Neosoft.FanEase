using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IAdminDashboard: IAsyncRepository<VideoDetail>
    {
        public List<object> GetTopCampaigns();
        public List<long> GetYearlyStats(long years);
        public List<long> GetYearlyLiveVideoStats(long years);
    }
}
