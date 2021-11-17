﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        IAdminDashboard _adminDashboard;

        public AdminController(ICreator creator, IViewer viewer, IVideo video, IWebHostEnvironment hostEnvironment, IMapper mapper, ICommon common, IAdminDashboard adminDashboard)
        {
            _mapper = mapper;
            _creator = creator;
            _viewer = viewer;
            _video = video;
            webHostEnvironment = hostEnvironment;
            _common = common;
            _adminDashboard = adminDashboard;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            var data = _adminDashboard.GetAdminStats();
            TempData["ContentCreator"] = data[0];
            TempData["Advertisements"] = data[1];
            TempData["Videos"] = data[2];
            TempData["Views"] = data[3];
            ViewData["AdminStats"] = data;
            return View();
        }

        [HttpGet]
        public bool checkForEmailExist([FromQuery] string email)
        {
            bool isPresent = _common.checkForEmail(email);
            return isPresent;
        }
        [HttpGet]
        public long GetPhoneCode(int id)
        {
            var phoneCode = _common.GetPhoneCode(id);
            return phoneCode;
        }
        [HttpGet]
        public IActionResult GetCountry()
        {
            return Json(_common.GetCountryList());
        }
        [HttpGet]
        [Route("Admin/GetStates/{id:int}")]
        public IActionResult GetState([FromRoute] int id)
        {
            return Json(_common.GetStateList(id));
        }

        [HttpGet]
        [Route("Admin/GetCity/{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            return Json(_common.GetCityList(id));

        }

        public IActionResult CreatorRegisteration()
        {
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatorRegisteration(CreatorRegisteration registeration)
        {
            registeration.CreatedOn = DateTime.Now;
            registeration.CreatedBy = long.Parse(HttpContext.Session.GetString("LoginId"));
            if (ModelState.IsValid)
            {
                var isEmailPresent = _creator.GetCreatorByEmail(registeration.EmailId);
                if (isEmailPresent != null)
                {
                    ViewData["isInsert"] = false;
                    ModelState.AddModelError(" ", "Email Id already Present");
                    return View();
                }
                var updateCreator = _mapper.Map<UpdateCreatorByIdCommand>(registeration);
                string uniqueFileName = UploadedFile(registeration);
                updateCreator.ProfilePhotoPath = uniqueFileName;

                long id = await _creator.SaveCreatorDetail(updateCreator);
                if (id > 0)
                    ViewData["isInsert"] = true;
                ModelState.Clear();
                return View();
            }
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpGet]
        public IActionResult EditCreator([FromRoute] long id)
        {
            var data = _creator.GetCreatorById(id);
            ViewData["data"] = data;
            TempData["imgPath"] = data.ProfilePhotoPath;
            TempData["isPassword"] = data.isPassowrdUpdated;
            TempData["isDeleted"] = data.isDeleted;
            return View();
        }

        [HttpPost]
        public IActionResult EditCreator([FromRoute] long id, CreatorRegisteration editCreator)
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
                return RedirectToAction("CreatorsList");

            }
            var record = _creator.GetCreatorById(id);
            ViewData["data"] = record;
            return View();
        }
        [HttpGet]
        public IActionResult DeleteCreator([FromRoute] long id)
        {
            var delete = new DeleteCreatorByIdCommand { CreatorId = id };
            var isDeleted = _creator.DeleteCreator(delete);
            TempData["isDeleted"] = true;
            return RedirectToAction("CreatorsList");
        }
        public IActionResult VideoTable()
        {
            var data = _video.GetAllVideoList();
            ViewData["data"] = data;
            return View();
        }
        public IActionResult CreatorsList()
        {
            if (TempData["isDeleted"] != null)
            {
                ViewData["isDelete"] = TempData["isDeleted"];
            }
            else
            {
                ViewData["isDelete"] = false;
            }
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
        [HttpGet]
        public IActionResult GetCreatorVideoListById([FromRoute] long id,string CreatorName)
        {
            var data = _video.creatorVideoListById(id);
            ViewData["data"] = data;
            ViewData["CreatorName"] = CreatorName;
            return View();
        }
    }
}
