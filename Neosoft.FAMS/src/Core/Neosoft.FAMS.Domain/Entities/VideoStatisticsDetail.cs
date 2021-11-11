using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class VideoStatisticsDetail
    {
        [Key]
        public long VideoStatisticsId { get; set; }
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
