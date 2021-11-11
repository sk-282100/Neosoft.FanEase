using Microsoft.AspNetCore.Mvc;

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
