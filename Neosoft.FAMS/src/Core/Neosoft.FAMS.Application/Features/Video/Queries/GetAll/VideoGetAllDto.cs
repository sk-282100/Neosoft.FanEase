using System;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetAll
{
    public class VideoGetAllDto
    {
        public long VideoId { get; set; }
        public string VideoImage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public short? VideoTypeId { get; set; }
        public short? PlayerTypeId { get; set; }
        public string VideoUrl { get; set; }
        public string UploadVideoPath { get; set; }
        public short? VideoCategoryId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public short? VideoStatus { get; set; }
        public bool? PublishStatus { get; set; }
        public string Decription { get; set; }
    }
}
