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
using AutoMapper;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.WebApp.Models.CampaignModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
        private IMapper  _mapper;
        private IVideo _video;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ICampaign _campaign;
        private IAsset _asset;

        public CreatorController(IMapper mapper,IVideo video,ICampaign campaign, IWebHostEnvironment webHostEnvironment, IAsset asset)
        {
            _mapper = mapper;
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
            var data = _video.VideosCreatedByContentCreator(2);
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
            DateTime StartDate = (DateTime)model.StartDate;
            DateTime EndDate = (DateTime)model.EndDate;
            if (ModelState.IsValid)
            {
                var createCommand = _mapper.Map<VideoCreateCommand>(model);
                createCommand.VideoImage = UniqueName(model.VideoImage);
                createCommand.UploadVideoPath = UniqueName(model.UploadVideoPath);

                var VideoId = _video.CreateVideo(createCommand);
                if (VideoId != null)
                {
                    ViewData["isInsert"] = true;
                }
                return RedirectToAction("AddCampaignView", "Creator");
            }
            return View();
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
        public IActionResult AddAsset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAsset(AddAsset addAsset)
        {
            addAsset.CreatedOn = DateTime.Now;
            var createAdvertisement = _mapper.Map<CreateAdvertisementCommand>(addAsset);

            string uniquePath = UniqueName(addAsset.ProfilePhotoPath);
            createAdvertisement.ImagePath = uniquePath;
            createAdvertisement.VideoPath = uniquePath;
            createAdvertisement.CreatedBy = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));

            var result = _asset.SaveAssetDetail(createAdvertisement);
            do
            {

            } while (!result.IsCompletedSuccessfully);
            TempData["VideoId"] =  TempData["VideoId"];
            TempData["CampaignId"] = TempData["CampaignId"];
            TempData["AdvertisementId"] = result.Result;

            AddMappedData();
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
        public IActionResult EditAsset([FromRoute] long id, AddAsset editCreator)
        {
            editCreator.AdvertisementId = id;
            if (ModelState.IsValid)
            {
                var updateCreator = _mapper.Map<UpdateAdvertisementCommand>(editCreator);
                if (editCreator.ProfilePhotoPath == null)
                    updateCreator.ImagePath = TempData["imgPath"].ToString();
                else
                {
                    string uniqueFileName = UniqueName(editCreator.ProfilePhotoPath);
                    updateCreator.ImagePath = uniqueFileName;
                    updateCreator.VideoPath = uniqueFileName;
                }

                var isupdated = _asset.UpdateAssetDetail(updateCreator);
                return RedirectToAction("SelectAsset");

            }
            var record = _asset.GetAssetById(id);
            ViewData["data"] = record;
            return View();
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

        private void AddMappedData()
        {
            var addCampaignAdvertisement = new AddCampaignAdvertisementCommand();
            addCampaignAdvertisement.AdvertisementId = MappingViewModel.AdvertisementId;
            addCampaignAdvertisement.CampaignId =MappingViewModel.CampaignId;
            addCampaignAdvertisement.VideoId = MappingViewModel.VideoId;
            addCampaignAdvertisement.CreatedBy = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            addCampaignAdvertisement.CreatedOn=DateTime.Now;
           
            var id =_asset.AddCampaignAdvertiseMappedData(addCampaignAdvertisement);

        }

    }
}
