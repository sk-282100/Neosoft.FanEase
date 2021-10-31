using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.VideoModel
{
    public class AddVideo
    {
        [Required(ErrorMessage = "Video Image is required")]
        public string VideoImage { get; set; }
        [Required(ErrorMessage = "Date And Time is required")]
        public DateTime? appt { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30,ErrorMessage="Title Length Cannot Exceed 30 characters")]
        public string Title { get; set; }
        
        public short? VideoTypeId { get; set; }
        [Required(ErrorMessage = "Video Url is required")]
        public string VideoUrl { get; set; }
        public string UploadVideoPath { get; set; }
        public short? VideoCategoryId { get; set; }

    }
}
