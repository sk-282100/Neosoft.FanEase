using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetTopViewsVideo
{
    public class GetTopLikesVideoListDto
    {
        public long topVideoId { get; set; }
        public string UploadVideoPath { get; set; }
        public string Title { get; set; }
        public long topViews { get; set; }
        public long topLikes { get; set; }
        public string Decription { get; set; }
        public string videoImage { get; set; }
        public DateTime? createdOn { get; set; }
    }
}
