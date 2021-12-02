using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ICreatorDashboard : IAsyncRepository<VideoDetail>
    {
        public List<object> GetTopCampaigns(long id);
        public List<long> GetYearlyStats(long id,long years);
        Task<List<VideoDetail>> GetCreatedByIdAsync(long id);
        public List<long> GetYearlyLiveVideoStats(long id,long years);
    }
}
