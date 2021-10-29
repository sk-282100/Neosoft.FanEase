using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.VideoModel
{
    public class AddVideo
    {
        public string VideoImage { get; set; }
        public DateTime? appt { get; set; }
        public string Title { get; set; }
        public short? VideoTypeId { get; set; }
        public string VideoUrl { get; set; }
        public string UploadVideoPath { get; set; }
        public short? VideoCategoryId { get; set; }

    }
}
