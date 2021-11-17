using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll
{
    public class GetTopVideoDto
    {
        public long topVideoId { get; set; }
        public long topViews { get; set; }
        public long topClicks { get; set; }
    }
}
