using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IAdminDashboard: IAsyncRepository<VideoDetail>
    {
        public List<string> GetTopCampaigns();
        public List<long> GetYearlyStats(long years);
    }
}
