using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.ViewerModel;
using Neosoft.FAMS.WebApp.Profiles;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class ViewerController : Controller
    {
        private IMapper _mapper;
        IViewer _viewer;
        ICommon _common;

        public ViewerController(IMapper mapper,IViewer viewer, ICommon common)
        {
            _mapper = mapper;
            _viewer = viewer;
            _common = common;
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
            ViewData["isInsert"] = false;
            return View();
        }

        [HttpGet]
        public bool checkForEmailExist([FromQuery] string email)
        {
            bool isPresent = _viewer.checkEmail(email);
            return isPresent;
        }
    }
}
