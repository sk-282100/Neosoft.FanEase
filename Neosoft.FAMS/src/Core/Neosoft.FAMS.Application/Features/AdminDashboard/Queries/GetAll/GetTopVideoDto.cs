using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll
{
    public class GetTopVideoDto
    {
        
        public long topVideoId { get; set; }
        public string UploadVideoPath { get; set; }
        public string Title { get; set; }
        public long topViews { get; set; }
        public long topClicks { get; set; }
        public long topShares { get; set; }
        public string Decription { get; set; }
        public string videoImage { get; set; }
        
    }
}
