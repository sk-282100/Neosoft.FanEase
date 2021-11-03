using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.WebApp.Models.VideoModel;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class AdminController : Controller
    {
        ICreator _creator;
        IViewer _viewer;
        IVideo _video;
        IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        ICommon _common;

        public AdminController(ICreator creator, IViewer viewer,IVideo video, IWebHostEnvironment hostEnvironment, IMapper mapper, ICommon common)
        {
            _mapper = mapper;
            _creator = creator;
            _viewer = viewer;
            _video = video;
            webHostEnvironment = hostEnvironment;
            _common = common;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCountry()
        {
            return Json(_common.GetCountryList());

        }
        public IActionResult CreatorRegisteration()
        {
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> CreatorRegisteration(CreatorRegisteration registeration)
        {
            registeration.CreatedOn = DateTime.Now;
            registeration.CityId = 1;
            registeration.CountryId = 1;
            if (ModelState.IsValid)
            {
                var updateCreator = _mapper.Map<UpdateCreatorByIdCommand>(registeration);
                string uniqueFileName = UploadedFile(registeration);
                updateCreator.ProfilePhotoPath = uniqueFileName;

                long id = await _creator.SaveCreatorDetail(updateCreator);
                if (id > 0)
                    ViewData["isInsert"] = true;
                return View();
            }
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpGet]
        public IActionResult EditCreator([FromRoute]long id)
        {
            var data = _creator.GetCreatorById(id);
            ViewData["data"] = data;
            TempData["imgPath"] = data.ProfilePhotoPath;
            return View();
        }
       
        [HttpPost]
        public IActionResult EditCreator([FromRoute]long id,CreatorRegisteration editCreator)
        {
            editCreator.ContentCreatorId = id;
            editCreator.CityId = 1;
            editCreator.CountryId = 1;
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
                return RedirectToAction("CreatorsList");
               
            }
            var record = _creator.GetCreatorById(id);
            ViewData["data"] = record;
            return View();
        }
        public IActionResult VideoTable()
        {
            var data = _video.GetAllVideoList();
            ViewData["data"] = data;
            return View();
        }
        public IActionResult CreatorsList()
        {
            var data = _creator.GetAllCreator();
            ViewData["data"] = data;
            return View();
        }

        public ActionResult ViewerList()
        {
            var data = _viewer.GetAllViewer();
            ViewData["data"] = data;
            return View();
        }
        
        private string UploadedFile(CreatorRegisteration model)
        {
            string uniqueFileName = null;

            if (model.ProfilePhotoPath != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/Creators/Images");
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
