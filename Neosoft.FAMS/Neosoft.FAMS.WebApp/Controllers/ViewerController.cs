using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Models.ViewerModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class ViewerController : Controller
    {
        IViewer _viewer;

        public ViewerController(IViewer viewer)
        {
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
                string FirstName = viewerRegisteration.FirstName;
                string MiddleName = viewerRegisteration.MiddleName;
                string LastName = viewerRegisteration.LastName;
                string Address1 = viewerRegisteration.Address1;
                string Address2 = viewerRegisteration.Address2;
                string EmailId = viewerRegisteration.EmailId;
                string MobileNumber = viewerRegisteration.MobileNumber;
                string password = viewerRegisteration.Password;
                long id = await _viewer.SaveViewer(new ViewerCreateCommand
                {
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    LastName = LastName,
                    Address1 = Address1,
                    Address2 = Address2,
                    EmailId = EmailId,
                    MobileNumber = MobileNumber,
                    Password = password,
                    CityId = 1,
                    CountryId = 2
                });
                if (id > 0)
                    ViewData["isInsert"] = true;

                return View();
            }
            ViewData["isInsert"] = false;
            return View();
        }
    }
}
