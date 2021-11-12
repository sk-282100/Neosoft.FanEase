using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IVideoPageRepository:IAsyncRepository<VideoStatisticsDetail>
    {
        Task<VideoStatisticsDetail> CheckClickId(long id);
    }
}
