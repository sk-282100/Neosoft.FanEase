using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IAdminDashboard
    {
        public List<long> GetAdminStats();
    }
}
