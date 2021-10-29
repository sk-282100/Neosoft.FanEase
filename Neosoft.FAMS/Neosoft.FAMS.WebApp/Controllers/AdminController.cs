using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class AdminController : Controller
    {
        ICreator _creator;
        IViewer _viewer;
        IVideo _video;
        public AdminController(ICreator creator, IViewer viewer,IVideo video)
        {
            _creator = creator;
            _viewer = viewer;
            _video = video;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CreatorRegisteration()
        {
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> CreatorRegisteration(CreatorRegisteration registeration)
        {
            registeration.CityId = 1;
            registeration.CountryId = 1;
            long id = await _creator.SaveCreatorDetail(registeration);
            if(id>0)
                ViewData["isInsert"] = true;
            return View();
        }
        [HttpGet]
        public IActionResult EditCreator([FromRoute]long id)
        {
            var data = _creator.GetCreatorById(id);
            ViewData["data"] = data;
            return View();
        }
       
        [HttpPost]
        public IActionResult EditCreator([FromRoute]long id,CreatorRegisteration editCreator)
        {
            editCreator.ContentCreatorId = id;
            editCreator.CityId = 1;
            editCreator.CountryId = 1;
            var isupdated = _creator.UpdateCreatorDetail(editCreator);
            if(isupdated.IsCompleted)
                return RedirectToAction("CreatorsList");

            var data = _creator.GetCreatorById(1);
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
    }
}
