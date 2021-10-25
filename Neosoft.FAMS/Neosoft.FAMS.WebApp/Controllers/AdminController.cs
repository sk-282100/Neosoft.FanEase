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
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult CreatorRegisteration()
        {
            return View();
        }
        public ActionResult VideoTable()
        {
            return View();
        }
        public ActionResult CreatorsList()
        {
            return View();
        }
    }
}
