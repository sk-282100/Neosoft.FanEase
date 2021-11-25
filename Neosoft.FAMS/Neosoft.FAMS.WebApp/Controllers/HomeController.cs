using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.WebApp.Models;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
           var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
           var statusCode = exception.Error.GetType().Name switch
           {
               "ArgumentException" => HttpStatusCode.BadRequest,
               _ => HttpStatusCode.ServiceUnavailable
           };
            return Problem(detail:exception.Error.Message,statusCode:(int)statusCode);
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
