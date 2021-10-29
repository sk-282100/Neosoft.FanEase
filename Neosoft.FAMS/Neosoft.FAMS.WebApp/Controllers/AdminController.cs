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
        public AdminController(ICreator creator, IViewer viewer)
        {
            _creator = creator;
            _viewer = viewer;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreatorRegisteration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatorRegisteration(CreatorRegisteration registeration)
        {
            registeration.CityId = 1;
            registeration.CountryId = 1;
            _creator.SaveCreatorDetail(registeration);
            return View();
        }
        public ActionResult VideoTable()
        {
            return View();
        }
        public ActionResult CreatorsList()
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
