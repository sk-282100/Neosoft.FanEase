using System;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetVideoOfCreatorById
{
    public class GetVideoOfCreatorDto
    {
        public VideoDetail VideoDetail { get; set; }
        public string AssignedCampaign { get; set; }
        public long Views { get; set; }
        public long Clicks { get; set; }
    }
}
