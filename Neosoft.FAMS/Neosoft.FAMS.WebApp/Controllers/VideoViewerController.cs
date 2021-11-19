using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class VideoViewerController : Controller
    {
        private IVideoStatistics _videoStatistics;
        private IVideo _video;
        private ICreator _creator;
        private Itemplate _template;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public VideoViewerController(IVideo video,ICreator creator,IWebHostEnvironment webHostEnvironment,IVideoStatistics videoStatistics,Itemplate template)
        {
            _video = video;
            _creator = creator;
            _videoStatistics = videoStatistics;
            _webHostEnvironment = webHostEnvironment;
            _template = template;
        }

        [HttpGet]
        
        public List<long> GetLikes([FromQuery]long videoId,[FromQuery]long viewerId)
        {
            var likes = _videoStatistics.GetLikes(videoId, viewerId);
            return likes;
        }

        [HttpGet]
        public List<long> GetDislikes([FromQuery] long videoId, [FromQuery] long viewerId)
        {
            var likes = _videoStatistics.GetDislikes(videoId, viewerId);
            return likes;
        }

        [HttpGet]
        public long GetViews([FromQuery] long videoId, [FromQuery] long viewerId)
        { 
            long likes = _videoStatistics.GetViews(videoId,viewerId);
            return likes;
        }
        [HttpGet]
        public IActionResult VideoDisplay([FromRoute]long id)
        {
            var videoData = _video.VideoGetById(id);
            var advertisebyVideoId = _template.GetAdvertiseByVideoId(id);
            ViewData["advertiseData"] = advertisebyVideoId;
            ViewData["videoData"] = videoData;
            long createdBy = Convert.ToInt64( videoData.CreatedBy);
           
           // var session = long.Parse(HttpContext.Session.GetString("ContentCreatorId"));
            var session = 1;
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
