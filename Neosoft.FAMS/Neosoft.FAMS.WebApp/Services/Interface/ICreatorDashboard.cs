using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICreatorDashboard
    {
        public List<long> GetCreatorStats(long id);
        public List<long> GetCreatorVideoStats(long id);
    }
}
