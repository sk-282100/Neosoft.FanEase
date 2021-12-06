using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetTopViewsVideo;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.WebApp.Models.ViewerModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class ViewerController : Controller
    {
        private IMapper _mapper;
        IAdminDashboard _adminDashboard;
        IViewer _viewer;
        ICommon _common;
        IVideo _video;

        public ViewerController(IMapper mapper, IViewer viewer, ICommon common,IVideo video,IAdminDashboard adminDashboard)
        {
            _mapper = mapper;
            _adminDashboard = adminDashboard;
            _viewer = viewer;
            _common = common;
            _video = video;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCountry()
        {
            return Json(_common.GetCountryList());
        }
        [HttpGet]
        [Route("Viewer/GetStates/{id:int}")]
        public IActionResult GetState([FromRoute] int id)
        {
            return Json(_common.GetStateList(id));
        }

        [HttpGet]
        [Route("Viewer/GetCity/{id:int}")]
        public IActionResult GetCity([FromRoute] int id)
        {
            return Json(_common.GetCityList(id));

        }

        public ActionResult ViewerRegisteration()
        {
           
            ViewData["isInsert"] = false;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ViewerRegisteration(ViewerRegisteration viewerRegisteration)
        {
            if (ModelState.IsValid)
            {
                var isEmailPresent = _viewer.GetViewerByEmail(viewerRegisteration.EmailId);
                if (isEmailPresent != null)
                {
                    ViewData["countryId"] = viewerRegisteration.CountryId;
                    ViewData["stateId"] = viewerRegisteration.StateId;
                    ViewData["cityId"] = viewerRegisteration.CityId;
                    ViewData["isInsert"] = false;
                    ModelState.AddModelError(" ", "Email Id already Present");
                    return View();
                }

                var createViewer = _mapper.Map<ViewerCreateCommand>(viewerRegisteration);
                var result = await _viewer.SaveViewer(createViewer);
                if (result > 0)
                    ViewData["isInsert"] = true;
                ModelState.Clear();
                return View();
            }
            ViewData["countryId"] = viewerRegisteration.CountryId;
            ViewData["stateId"] = viewerRegisteration.StateId;
            ViewData["cityId"] = viewerRegisteration.CityId;
            ViewData["isInsert"] = false;
            return View();
        }

        [HttpGet]
        public bool checkForEmailExist([FromQuery] string email)
        {
            bool isPresent = _viewer.checkEmail(email);
            return isPresent;
        }

        [CustomAuthorizationFilter]
        public ActionResult DisplayAllVideos()
        {
            return View();
        }

        [CustomAuthorizationFilter]
        public List<GetTopVideoDto> topViewsVideo()
        {
            var videoList = _adminDashboard.GetTopVideo();
            return videoList;

        }

        [CustomAuthorizationFilter]
        [HttpGet]
        public List<VideoGetAllDto> GetVideos([FromQuery] long videoId, [FromQuery] long viewerId)
        { 
            var videoList = _video.GetAllVideoList();
            return videoList;
        }

        [CustomAuthorizationFilter]
        public List<GetTopLikesVideoListDto> GetTopLikedVideos()
        {
            var videoList = _viewer.GetTopLikedVideo();
            return videoList;
        }

    }
}
