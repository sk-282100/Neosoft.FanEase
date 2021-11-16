using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IVideoStatistics
    {
        public List<long> StatsGetById(long videoId);
        public bool CheckClickBy(long videoId, long viewerId);
    }
}
