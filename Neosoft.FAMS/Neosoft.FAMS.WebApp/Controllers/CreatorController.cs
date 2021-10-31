using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.VideoModel;
using Neosoft.FAMS.WebApp.Models.AdvertisementModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
        IVideo _video;
        public CreatorController(IVideo video)
        {
            _video = video;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CampaignTable()
        {
            return View();
        }
        public ActionResult ViewCampaign()
        {
            return View();
        }
        public ActionResult VideoTable()
        {
            var data = _video.GetAllVideoList();
            ViewData["data"] = data;
            return View();
        }

       

        public IActionResult AddVideoView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVideoView(AddVideo model)
        {
            string VideoImage = model.VideoImage;
            DateTime StartDate = (DateTime)model.appt;
            DateTime EndDate = (DateTime)model.appt;
            string Title = model.Title;
            short VideoTypeId = (short)model.VideoTypeId;

            string VideoUrl = model.VideoUrl;
            //short CreatedBy = 1;

            //bool IsDeleted = false;




            var serviceresult = _video.CreateVideo(new VideoCreateCommand
            {
                VideoImage = "abcd",
                StartDate = StartDate,
                EndDate=EndDate,
                Title=Title,
                VideoTypeId=VideoTypeId,
                VideoUrl=VideoUrl,
                PlayerTypeId = 1,
                VideoStatus = 1,
                PublishStatus = false,
                VideoCategoryId = 1,
                UploadVideoPath = "abd"

            }) ;

            return View();
        }
        public ActionResult AddCampaignView()
        {
            return View();
        }
        public ActionResult ExistingCampaign()
        {
            return View();
        }
        public ActionResult AddAsset(AddAsset addAsset)
        {
            return View();
        }
        public ActionResult SelectAsset()
        {
            return View();
        }
    }
}
