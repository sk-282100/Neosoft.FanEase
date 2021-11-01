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
using Neosoft.FAMS.Application.Features.Video.Commands.Update;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
        IMapper  _mapper;
        IVideo _video;
        private readonly IWebHostEnvironment _webHostEnvironment;
        ICampaign _campaign;
        public CreatorController(IMapper mapper,IVideo video,ICampaign campaign, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
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
            var data = _video.VideoGetById(6);
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
            DateTime EndDate = (DateTime)model.endappt;
            _video.CreateVideo(new VideoCreateCommand
            {
                VideoImage = VideoImageFile(model),
                StartDate = StartDate,
                EndDate=EndDate,
                Title= model.Title,
                VideoTypeId= (short)model.VideoTypeId,
                VideoUrl = model.VideoUrl,
                PlayerTypeId = 1,
                VideoStatus = 1,
                PublishStatus = false,
                VideoCategoryId = model.VideoCategoryId,
                UploadVideoPath = VideoFile(model)

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
        public IActionResult EditVideoView([FromRoute] long id)
        {

            var data = _video.VideoGetById(id);
            ViewData["data"] = data;
            TempData["imgPath"] = data.VideoImage;
            TempData["VideoPath"] = data.UploadVideoPath;
            return View();
        }

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
                    string thumbnail = VideoImageFile(editVideo);
                    updateVideo.VideoImage = thumbnail;

                    string video = VideoFile(editVideo);
                    updateVideo.VideoImage = video;
                }

                var isupdated = _video.UpdateVideoDetail(updateVideo);
                return RedirectToAction("VideoTable");

            }
            var record = _video.VideoGetById(id);
            ViewData["data"] = record;
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
