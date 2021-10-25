using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.ViewerModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class ViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ViewerRegisteration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewerRegisteration(ViewerRegisteration viewerRegisteration)
        {

            return View();
        }
    }
}
