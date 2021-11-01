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
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
        IVideo _video;
        private readonly IWebHostEnvironment _webHostEnvironment;
        ICampaign _campaign;
        IAsset _asset;
        public CreatorController(IVideo video,ICampaign campaign, IWebHostEnvironment webHostEnvironment, IAsset asset)
        {
            _video = video;
            _webHostEnvironment = webHostEnvironment;
            _campaign = campaign;
            _asset = asset;
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
        public IActionResult AddAsset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAsset(AddAsset addAsset)
        {
            string Title = addAsset.Title;
            DateTime StartDate = (DateTime)addAsset.StartTime;
            DateTime EndDate = (DateTime)addAsset.EndTime;
            short ContentTypeId = (short)addAsset.ContentTypeId;
            string Description = addAsset.Description;
            string Url = addAsset.Url;
            string uniqueFileName = UploadedFile(addAsset);
            long PlacementId = (long)addAsset.PlacementId;
            var serviceresult = _asset.SaveAssetDetail(new CreateAdvertisementCommand
            {
                Title = Title,
                StartDate = StartDate,
                EndDate = EndDate,
                ContentTypeId = ContentTypeId,
                Description = Description,
                Url = Url,
                ImagePath = uniqueFileName,
                PlacementId = PlacementId,
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                VideoPath = "abc.mp4"
            });
            return View();
        }

        public ActionResult SelectAsset()
        {
            var data = _asset.GetAllAsset();
            ViewData["data"] = data;
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
        private string UploadedFile(AddAsset model)
        {
            string uniqueFileName = null;

            if (model.ProfilePhotoPath != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Asset/Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePhotoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfilePhotoPath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
