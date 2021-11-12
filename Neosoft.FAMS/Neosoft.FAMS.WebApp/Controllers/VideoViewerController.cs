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

        public VideoViewerController(IVideo video,ICreator creator)
        {
            _video = video;
            _creator = creator;
        }
        [HttpGet]
        public IActionResult VideoDisplay([FromRoute]long id)
        {
            var videoData = _video.VideoGetById(id);
            ViewData["videoData"] = videoData;
            long createdBy = Convert.ToInt64( videoData.CreatedBy);
            var ContentCreatorId = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            var creatorData = _creator.GetCreatorById(createdBy);
           
            ViewData["videoData"] = videoData;
            ViewData["creatorData"] = creatorData;
            return View();
        }
    }
}
