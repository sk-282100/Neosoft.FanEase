using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class CreatorController : Controller
    {
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
            return View();
        }
        public ActionResult AddVideoView()
        {
            return View();
        }
        public ActionResult AddCampaignView()
        {
            return View();
        }
        public ActionResult ExistingCampaign()
        {
            return View();
        }
        public ActionResult AddAsset()
        {
            return View();
        }
        public ActionResult SelectAsset()
        {
            return View();
        }
    }
}
