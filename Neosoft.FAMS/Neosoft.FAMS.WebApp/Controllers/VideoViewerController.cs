using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class VideoViewerController : Controller
    {
        private IVideo _video;
        private ICreator _creator;
        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VideoViewerController(IVideo video,ICreator creator,IWebHostEnvironment webHostEnvironment)
        {
            _video = video;
            _creator = creator;
            
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult VideoDisplay([FromRoute]long id)
        {
            var videoData = _video.VideoGetById(id);
            ViewData["videoData"] = videoData;
            long createdBy = Convert.ToInt64( videoData.CreatedBy);
            TempData["Session"] = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            var creatorData = _creator.GetCreatorById(createdBy);
           
            ViewData["videoData"] = videoData;
            ViewData["creatorData"] = creatorData;
            return View();
        }
    }
}
