using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IAdminDashboard
    {
        public List<long> GetAdminStats();
        public List<GetTopVideoDto> GetTopVideo();
        public List<string> GetTopCampaignName();
    }
}
