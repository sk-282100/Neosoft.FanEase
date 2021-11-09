using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class VideoViewerController : Controller
    {
        public IActionResult VideoDisplay()
        {
            return View();
        }
    }
}
