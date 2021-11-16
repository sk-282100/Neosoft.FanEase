using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class VideoViewerController : Controller
    {
        private IVideoStatistics _videoStatistics;
        private IVideo _video;
        private ICreator _creator;
        
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VideoViewerController(IVideo video,ICreator creator,IWebHostEnvironment webHostEnvironment,IVideoStatistics videoStatistics)
        {
            _video = video;
            _creator = creator;
            _videoStatistics = videoStatistics;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public long GetLikes(long id,long viewerId)
        {
            long likes = _videoStatistics.GetLikes(id,viewerId);
            return likes;
        }

        [HttpGet]
        public long GetDislikes(long id, long viewerId)
        {
            long likes = _videoStatistics.GetDislikes(id, viewerId);
            return likes;
        }

        [HttpGet]
        public long GetViews(long id,long viewerId)
        {
            long likes = _videoStatistics.GetViews(id,viewerId);
            return likes;
        }
        [HttpGet]
        public IActionResult VideoDisplay([FromRoute]long id)
        {
            var videoData = _video.VideoGetById(id);
            ViewData["videoData"] = videoData;
            long createdBy = Convert.ToInt64( videoData.CreatedBy);
           
            var session = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));

            _videoStatistics.CheckClickBy(id, session);
            TempData["Session"] = session;
            var creatorData = _creator.GetCreatorById(createdBy);
            var statData = _videoStatistics.StatsGetById(id);
            TempData["Likes"] = statData[0];
            TempData["Dislikes"] = statData[1];
            TempData["Views"] = statData[2];
            TempData["Share"] = statData[3];

            ViewData["VideoStats"] = statData;
            ViewData["videoData"] = videoData;
            ViewData["creatorData"] = creatorData;
            return View();
        }


    }
}
