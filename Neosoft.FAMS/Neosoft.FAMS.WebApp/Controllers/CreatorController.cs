using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Commands.Delete;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.AdvertisementModel;
using Neosoft.FAMS.WebApp.Models.CampaignModel;
using Neosoft.FAMS.WebApp.Models.VideoModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.IO;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Delete;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
        private IMapper _mapper;
        private ICommon _common;
        private IVideo _video;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ICampaign _campaign;
        private IAsset _asset;

        public CreatorController(IMapper mapper,ICommon common, IVideo video, ICampaign campaign, IWebHostEnvironment webHostEnvironment, IAsset asset)
        {
            _mapper = mapper;
            _common = common;
            _video = video;
            _webHostEnvironment = webHostEnvironment;
            _campaign = campaign;
            _asset = asset;

        }

        public IActionResult GetAdvertisement()
        {
            return Json(_common.GetAdvertisement());
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCampaign()
        {
            return View();
        }
        public ActionResult VideoTable()
        {
            var id = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            var data = _video.VideosCreatedByContentCreator(id);
            ViewData["data"] = data;
            return View();
        }


        public IActionResult AddVideoView()
        {
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpPost]
        public IActionResult AddVideoView(AddVideo model)
        {
            model.CreatedBy = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            model.PublishStatus = false;
            model.VideoCategoryId = 0;
            model.VideoStatus = 0;
            model.CreatedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                var createCommand = _mapper.Map<VideoCreateCommand>(model);
                createCommand.VideoImage = UniqueName(model.VideoImage);
                createCommand.UploadVideoPath = UniqueName(model.UploadVideoPath);
                var id = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
                var VideoId = _video.CreateVideo(createCommand);
                if (VideoId != null)
                {
                    ViewData["isInsert"] = true;
                    ViewData["data"] = id;
                }
                return RedirectToAction("AddCampaignView", "Creator");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteVideo([FromRoute] long id)
        {
            var delete = new DeleteVideoByIdCommand { VideoId = id };
            var isDeleted = _video.DeleteVideo(delete);
            TempData["isDeleted"] = true;
            return RedirectToAction("VideoTable");
        }

        public IActionResult AddCampaignView()
        {
            var data = _asset.GetAllAsset();
            ViewData["data"] = data;
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpPost]
        public IActionResult AddCampaignView(CreateCampaign model)
        {
            if (ModelState.IsValid)
            {
                var createCampaign = _mapper.Map<CampaignCreateCommand>(model);

                createCampaign.CreatedOn = DateTime.Now;
                createCampaign.CreatedBy = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
                var result = _campaign.SaveCampaignDetail(createCampaign);
                if (result != null)
                {
                    ViewData["isInsert"] = true;
                }
                return RedirectToAction("AddAsset", "Creator");
            }
            ViewData["isInsert"] = false;
            return View();
        }

        public IActionResult ExistingCampaign()
        {
            var data = _campaign.GetAllCampaign();
            ViewData["data"] = data;
            return View();
        }
        public IActionResult CampaignTable()
        {
            var data = _campaign.GetAllCampaign();
            ViewData["data"] = data;
            return View();
        }


        [HttpGet]
        public IActionResult EditCampaign([FromRoute] long id)
        {
            var data = _campaign.GetCampaignById(id);
            ViewData["data"] = data;
            return View();
        }

        [HttpPost]
        public IActionResult EditCampaign([FromRoute] long id, CreateCampaign campaign)
        {
            campaign.CampaignId = id;
            if (ModelState.IsValid)
            {
                var updateCampaign = _mapper.Map<UpdateCampaignCommand>(campaign);

                var isupdated = _campaign.UpdateCampaignDetail(updateCampaign);
                return RedirectToAction("CampaignTable");

            }
            var record = _campaign.GetCampaignById(id);
            ViewData["data"] = record;
            return View();
        }

        [HttpGet]
        public IActionResult DeleteCampaign([FromRoute] long id)
        {
            var delete = new DeleteCampaignByIdCommand { CampaignId = id };
            var isDeleted = _campaign.DeleteCampaign(delete);
            TempData["isDeleted"] = true;
            return RedirectToAction("CampaignTable");
        }


        public IActionResult AddAsset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAsset(AddAsset addAsset)
        {
            addAsset.CreatedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                var createAdvertisement = _mapper.Map<CreateAdvertisementCommand>(addAsset);
                if (addAsset.ProfilePhotoPath != null)
                {
                    string uniquePath = UniqueName(addAsset.ProfilePhotoPath);
                    createAdvertisement.ImagePath = uniquePath;
                }
                else
                {
                    string uniquePath = UniqueName(addAsset.VideoPath);
                    createAdvertisement.VideoPath = uniquePath;
                }
                createAdvertisement.CreatedBy = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));

                var result = _asset.SaveAssetDetail(createAdvertisement);
                ModelState.Clear();
                return View();

            }
            return View();
        }



        [HttpGet]
        public IActionResult EditAsset([FromRoute] long id)
        {
            var data = _asset.GetAssetById(id);
            ViewData["data"] = data;
            TempData["imgPath"] = data.ImagePath;
            return View();
        }

        [HttpPost]
        public IActionResult EditAsset([FromRoute] long id, AddAsset editAsset)
        {
            editAsset.AdvertisementId = id;
            if (ModelState.IsValid)
            {
                var updateAsset = _mapper.Map<UpdateAdvertisementCommand>(editAsset);
                if (editAsset.ProfilePhotoPath == null)
                    updateAsset.ImagePath = TempData["imgPath"].ToString();
                else
                {
                    string uniqueFileName = UniqueName(editAsset.ProfilePhotoPath);
                    updateAsset.ImagePath = uniqueFileName;
                    updateAsset.VideoPath = uniqueFileName;
                }

                var isupdated = _asset.UpdateAssetDetail(updateAsset);
                return RedirectToAction("SelectAsset");

            }
            var record = _asset.GetAssetById(id);
            ViewData["data"] = record;
            return View();
        }

        [HttpGet]
        public IActionResult DeleteAsset([FromRoute] long id)
        {
            var delete = new DeleteAdvertisementCommand { AdvertisementId = id };
            var isDeleted = _asset.DeleteAsset(delete);
            TempData["isDeleted"] = true;
            return RedirectToAction("AddCampaignView");
        }

        public ActionResult SelectAsset()
        {
            var data = _asset.GetAllAsset();
            ViewData["data"] = data;
            return View();
        }
        [HttpGet]
        public IActionResult EditVideoView([FromRoute] long id)
        {
            var data = _video.VideoGetById(id);
            ViewData["data"] = data;
            TempData["imgPath"] = data.VideoImage;
            TempData["VideoPath"] = data.UploadVideoPath;
            return View();
        }
        [HttpPost]
        public IActionResult EditVideoView([FromRoute] long id, AddVideo editVideo)
        {
            editVideo.PublishStatus = false;
            //editCreator.CountryId = 1;
            if (ModelState.IsValid)
            {
                var updateVideo = _mapper.Map<UpdateVideoByIdCommand>(editVideo);
                if (editVideo.VideoImage == null && editVideo.UploadVideoPath != null)
                    updateVideo.VideoImage = TempData["imgPath"].ToString();
                else if (editVideo.UploadVideoPath == null && editVideo.VideoImage != null)
                    updateVideo.UploadVideoPath = TempData["VideoPath"].ToString();
                else if (editVideo.UploadVideoPath == null && editVideo.VideoImage == null)
                {
                    updateVideo.VideoImage = TempData["imgPath"].ToString();
                    updateVideo.UploadVideoPath = TempData["VideoPath"].ToString();

                }
                else
                {
                    string thumbnail = UniqueName(editVideo.VideoImage);
                    updateVideo.VideoImage = thumbnail;

                    string video = VideoFile(editVideo);
                    updateVideo.UploadVideoPath = video;
                }


                var isupdated = _video.UpdateVideoDetail(updateVideo);
                return RedirectToAction("VideoTable");

            }
            var record = _video.VideoGetById(id);
            ViewData["data"] = record;
            return View();
        }
        private string UniqueName(IFormFile nameFile)
        {
            string thumbnail = null;

            if (nameFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Creators/Videos");
                thumbnail = Guid.NewGuid().ToString() + "_" + nameFile.FileName;
                string filePath = Path.Combine(uploadsFolder, thumbnail);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    nameFile.CopyTo(fileStream);
                }
            }
            return thumbnail;
        }


        public string VideoFile(AddVideo model)
        {
            string video = null;

            if (model.VideoImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Creators/Videos");
                video = Guid.NewGuid().ToString() + "_" + model.UploadVideoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, video);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.VideoImage.CopyTo(fileStream);
                }
            }
            return video;
        }

       

    }
}
