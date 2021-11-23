using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ICreatorDashboard : IAsyncRepository<VideoDetail>
    {
        public List<object> GetTopCampaigns(long id);
        public List<long> GetYearlyStats(long id,long years);
    }
}
