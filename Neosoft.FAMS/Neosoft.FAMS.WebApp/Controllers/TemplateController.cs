using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Neosoft.FAMS.WebApp.Services.Interface;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class TemplateController : Controller
    {
        IMapper _mapper;
        Itemplate _template;

        public TemplateController(IMapper mapper, Itemplate template)
        {
            _mapper = mapper;
            _template = template;
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
    }
}
