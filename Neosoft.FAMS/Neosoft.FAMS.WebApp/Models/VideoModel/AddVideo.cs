using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Neosoft.FAMS.WebApp.Models.VideoModel
{
    public class AddVideo
    {

        public long VideoId { get; set; }
        public IFormFile VideoImage { get; set; }
        [Required(ErrorMessage = "Date And Time is required")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30,ErrorMessage="Title Length Cannot Exceed 30 characters")]
        public string Title { get; set; }
        
        public short? VideoTypeId { get; set; }
        public short? PlayerTypeId { get; set; }


        [Required(ErrorMessage = "Video Url is required")]
        public string VideoUrl { get; set; }
        public IFormFile UploadVideoPath { get; set; }
        public short? VideoCategoryId { get; set; }
        public short? VideoStatus { get; set; }
        public bool? PublishStatus { get; set; }


    }
}
