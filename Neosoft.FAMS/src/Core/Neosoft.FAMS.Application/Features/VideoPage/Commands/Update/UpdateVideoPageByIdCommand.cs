using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Neosoft.FAMS.Application.Features.VideoPage.Commands.Update
{
    public class UpdateVideoPageByIdCommand :IRequest<Response<bool>>
    {
        [ReadOnly(true)]
        public long VideoStatisticsId { get; set; }
        [ReadOnly(true)]
        public long? VideoId { get; set; }
        public bool? IsClicked { get; set; }
        public long? ClickedBy { get; set; }
        public DateTime? ClickedOn { get; set; }
        public bool? IsViewed { get; set; }
        public long? ViewBy { get; set; }
        public DateTime? ViewOn { get; set; }
        public bool? IsLiked { get; set; }
        public long? LikeBy { get; set; }
        public DateTime? LikeOn { get; set; }
        public bool? IsShared { get; set; }
        public DateTime? SharedOn { get; set; }
        public long? SharedBy { get; set; }
    }
}
