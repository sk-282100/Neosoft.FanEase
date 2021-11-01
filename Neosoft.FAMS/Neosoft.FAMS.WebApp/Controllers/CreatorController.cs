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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.WebApp.Models.CampaignModel;
using Microsoft.AspNetCore.Hosting;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
        IVideo _video;
        private readonly IWebHostEnvironment _webHostEnvironment;
        ICampaign _campaign;
        public CreatorController(IVideo video,ICampaign campaign, IWebHostEnvironment webHostEnvironment)
        {
            _video = video;
            _webHostEnvironment = webHostEnvironment;
            _campaign = campaign;
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
            DateTime StartDate = (DateTime)model.appt;
            DateTime EndDate = (DateTime)model.appt;
            string Title = model.Title;
            short VideoTypeId = (short)model.VideoTypeId;

            string VideoUrl = model.VideoUrl;
            //short CreatedBy = 1;

            //bool IsDeleted = false;




            var serviceresult = _video.CreateVideo(new VideoCreateCommand
            {
                VideoImage = VideoImageFile(model),
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
        public IActionResult AddCampaignView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCampaignView(CreateCampaign model)
        {
            string CampaignName = model.CampaignName;
            DateTime StartDate = (DateTime)model.StartDate;
            DateTime EndDate = (DateTime)model.EndDate;
            var serviceresult = _campaign.SaveCampaignDetail(new CampaignCreateCommand
            {
                CampaignName = CampaignName,
                StartDate = StartDate,
                EndDate = EndDate,
                CreatedBy = 2,
                CreatedOn = DateTime.Now
            });
            return View();
        }

        public ActionResult ExistingCampaign()
        {
            var data = _campaign.GetAllCampaign();
            ViewData["data"] = data;
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

        private string VideoImageFile(AddVideo model)
        {
            string thumbnail = null;

            if (model.VideoImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Creators/Videos");
                thumbnail = Guid.NewGuid().ToString() + "_" + model.VideoImage.FileName;
                string filePath = Path.Combine(uploadsFolder, thumbnail);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.VideoImage.CopyTo(fileStream);
                }
            }
            return thumbnail;
        }
    }
}
