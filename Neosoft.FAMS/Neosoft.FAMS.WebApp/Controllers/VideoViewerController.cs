using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.WebApp.Services.Interface;

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
            var ContentCreatorId = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            var creatorData = _creator.GetCreatorById(ContentCreatorId);
            var videoData = _video.VideoGetById(id);
            ViewData["videoData"] = videoData;
            ViewData["creatorData"] = creatorData;
            return View();
        }
    }
}
