using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetById;
using Neosoft.FAMS.WebApp.Services.Interface;
using Neosoft.FAMS.Application.Features.Template.Commands.TemplateVideo;
using Neosoft.FAMS.WebApp.Models;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class TemplateController : Controller
    {
        private IMapper _mapper;
        private Itemplate _template;
        private IAsset _asset;

        public TemplateController(IMapper mapper, Itemplate template,IAsset asset)
        {
            _mapper = mapper;
            _template = template;
            _asset = asset;
        }
       
        public ActionResult TemplateList()
        {
            var data = _template.GetAllTemplate();
            ViewData["data"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult TemplateDetail([FromRoute]long id)
        {
            var data = _template.GetTemplate(id);
            ViewData["data"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult AddTemplate()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult AddTemplateVideoData(string id)
        {
            string[] arr = id.Split("-");
            for (int i = 0; i < arr.Length; i++)
            {
                var advertisementData = _asset.GetAssetById(Convert.ToInt64(arr[i]));
                var command = new TemplateVideoMappedCommand()
                {
                    TemplateFieldId = i+1,
                    VideoId = 73,
                    Title = advertisementData.Title,
                    Description = advertisementData.Description,
                    Link = advertisementData.Url,
                    CreatedOn = DateTime.Now
                };
                if (advertisementData.ImagePath != null)
                    command.ImagePath = advertisementData.ImagePath;
                else
                    command.ImagePath = advertisementData.VideoPath;

                  _template.AddTemplateVideo(command);
            }

            return RedirectToAction("TemplateList");
        }
    }
}
