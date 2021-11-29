﻿using AutoMapper;
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
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Delete;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.WebApp.Models.CreatorModel;

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
        private ICreator _creator;
        private ICreatorDashboard _creatorDashboard;
        public CreatorController(IMapper mapper,ICommon common, IVideo video, ICampaign campaign, IWebHostEnvironment webHostEnvironment, IAsset asset, ICreator creator,ICreatorDashboard creatorDashboard)
        {
            _mapper = mapper;
            _common = common;
            _video = video;
            _webHostEnvironment = webHostEnvironment;
            _campaign = campaign;
            _asset = asset;
            _creator = creator;
            _creatorDashboard = creatorDashboard;

        }
        public IActionResult AddExistingCampaignIdToMapped(long id)
        {
            MappingViewModel.CampaignId = id;
            _campaign.GetMappedVideoIdCampaign(id);
            HttpContext.Session.SetString("isCampaignAdded",true.ToString());
            return RedirectToAction("AddAsset");
        }

        public IActionResult AddExistingCampaignId(long id)
        {
            var campaignData=_campaign.GetCampaignById(id);
            ViewData["campaignData"] = campaignData;
          
            ViewData["AdvertisementData"] = _asset.GetAllMappedAsset(id);
            return View("AddCampaignView");
        }

        public IActionResult AddExistingAssets()
        {
            foreach (var id in AddExistingAssetViewModel.AdvertisementId)
            {
                MappingViewModel.AdvertisementId = id;
                _asset.AddMappedData();
            }

            return RedirectToAction("AddCampaignView");
        }
        public void AddExistingAssetId(long id)
        {
            //long advertisementId = Convert.ToInt64(id);
            if (AddExistingAssetViewModel.AdvertisementId.Contains(id))
                AddExistingAssetViewModel.AdvertisementId.Remove(id);
            else
                AddExistingAssetViewModel.AdvertisementId.Add(id);
        }
        public IActionResult GetAdvertisement()
        {
            return Json(_common.GetAdvertisement());
        }
        [HttpGet]
        public IActionResult Index()
        {
            var id = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            TempData["CreatorId"] = id;
            ViewData["CampaignDetails"] = _creatorDashboard.GetTopCampaignName(id);
            var record = _creatorDashboard.GetTopVideo(id);
            ViewData["records"] = record;
            var CreatorStatRecord = _creatorDashboard.GetCreatorStats(id);
            ViewData["CreatorStatRecords"] = CreatorStatRecord;
            var CreatorStatData = _creatorDashboard.GetCreatorVideoStats(id);
            TempData["CreatorStatVideos"] = CreatorStatRecord[0];
            TempData["CreatorStatAdvertisements"] = CreatorStatRecord[1];
            TempData["LatestCreatorVideo"] = CreatorStatRecord[2];
            TempData["LatestCreatorAds"] = CreatorStatRecord[3];
            TempData["CreatorStatViews"] = CreatorStatData[0];
            TempData["CreatorStatLikes"] = CreatorStatData[1];
            TempData["CreatorLatestViews"] = CreatorStatData[2];
            TempData["CreatorLatestLikes"] = CreatorStatData[3];
            return View();
        }

        [HttpGet]
        [Route("Creator/yearlyStats/{id}/{years}")]

        public List<long> yearlyStats([FromRoute]long id,[FromRoute]long years)
        {
            var result = _creatorDashboard.GetYearlyStatistics(id,years);
            return result;
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
                    ViewData["data"] = id;
                }
                HttpContext.Session.SetString("isVideoAdded",true.ToString());
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
                HttpContext.Session.SetString("isCampaignAdded", true.ToString());
                return RedirectToAction("AddCampaignView", "Creator");
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
                HttpContext.Session.SetString("isAssetAdded", true.ToString());
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
            TempData["startDate"] = data.StartDate;
            TempData["endDate"] = data.EndDate;

            return View();
        }
        [HttpPost]
        public IActionResult EditVideoView([FromRoute] long id, AddVideo editVideo)
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
            ModelState.Remove("UploadVideoPath");

            if (editVideo.StartDate == (DateTime) TempData["startDate"] &&
                editVideo.EndDate == (DateTime) TempData["endDate"])
            {
                ModelState.Remove("StartDate");
                ModelState.Remove("EndDate");
                if (ModelState.IsValid)
                {
                    var isupdated = _video.UpdateVideoDetail(updateVideo);
                    return RedirectToAction("VideoTable");
                }
            }
            else if (editVideo.StartDate == (DateTime) TempData["startDate"])
            {
                ModelState.Remove("StartDate");
                if (ModelState.IsValid)
                {
                    var isupdated = _video.UpdateVideoDetail(updateVideo);
                    return RedirectToAction("VideoTable");

                }
            }
            else if (editVideo.EndDate == (DateTime) TempData["endDate"])
            {
                ModelState.Remove("EndDate");
                if (ModelState.IsValid)
                {
                    var isupdated = _video.UpdateVideoDetail(updateVideo);
                    return RedirectToAction("VideoTable");

                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var isupdated = _video.UpdateVideoDetail(updateVideo);
                    return RedirectToAction("VideoTable");

                }
            }
            
            var record = _video.VideoGetById(id);
            ViewData["data"] = record;
            TempData["imgPath"] = record.VideoImage;
            TempData["VideoPath"] = record.UploadVideoPath;
            TempData["startDate"] = record.StartDate;
            TempData["endDate"] = record.EndDate;
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

        [HttpGet]
        public IActionResult EditCreatorProfile([FromRoute] long id)
        {
            var data = _creator.GetCreatorById(id);
            ViewData["data"] = data;
            TempData["imgPath"] = data.ProfilePhotoPath;
            TempData["isPassword"] = data.isPassowrdUpdated;
            TempData["isDeleted"] = data.isDeleted;
            return View();
        }

        [HttpPost]
        public IActionResult EditCreatorProfile([FromRoute] long id, CreatorRegisteration editCreator)
        {
            editCreator.ContentCreatorId = id;
            editCreator.isPassowrdUpdated = Convert.ToBoolean(TempData["isPassword"]);
            editCreator.isDeleted = Convert.ToBoolean(TempData["isDeleted"]);
            if (ModelState.IsValid)
            {
                var updateCreator = _mapper.Map<UpdateCreatorByIdCommand>(editCreator);
                if (editCreator.ProfilePhotoPath == null)
                    updateCreator.ProfilePhotoPath = TempData["imgPath"].ToString();
                else
                {
                    string uniqueFileName = UploadedFile(editCreator);
                    updateCreator.ProfilePhotoPath = uniqueFileName;
                }

                var isupdated = _creator.UpdateCreatorDetail(updateCreator);
                return RedirectToAction("Index");

            }
            var record = _creator.GetCreatorById(id);
            ViewData["data"] = record;
            return View();
        }
        private string UploadedFile(CreatorRegisteration model)
        {
            string uniqueFileName = null;

            if (model.ProfilePhotoPath != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Creators/Images");
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
