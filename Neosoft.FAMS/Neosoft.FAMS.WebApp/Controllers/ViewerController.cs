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

        public ViewerController(IMapper mapper,IViewer viewer)
        {
            _mapper = mapper;
            _viewer = viewer;
        }

        public IActionResult Index()
        {
            return View();
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
                viewerRegisteration.CityId = 1;
                viewerRegisteration.CountryId = 2;
                var createViewer = _mapper.Map<ViewerCreateCommand>(viewerRegisteration);
                var result = await _viewer.SaveViewer(createViewer);
                if (result > 0)
                    ViewData["isInsert"] = true;

                return View();
            }
            ViewData["isInsert"] = false;
            return View();
        }
    }
}
