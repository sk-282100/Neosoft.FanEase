using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Video.Command.Create
{
    public class VideoCreateCommand:IRequest<Response<long>>
    {
        public string VideoImage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public short? VideoTypeId { get; set; }
        public short? PlayerTypeId { get; set; }
        public string VideoUrl { get; set; }
        public string UploadVideoPath { get; set; }
        public short? VideoCategoryId { get; set; }
        public long CreatedBy { get; set; }
        public string Decription { get; set; }
        public short? VideoStatus { get; set; }
        public bool? PublishStatus { get; set; }
    }
}
