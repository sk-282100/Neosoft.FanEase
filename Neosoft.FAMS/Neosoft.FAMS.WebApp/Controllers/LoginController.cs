using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Models.LoginModel.Login;
using Neosoft.FAMS.WebApp.Models.LoginModel.ResetPassword;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(new Login());
        }
        [HttpPost]
        public IActionResult Index(Login model)
        {
            string Username = model.Username;
            string Password = model.Password;
            if (Username == "admin@gmail.com" && Password == "Admin123")
            {
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("Index", "Creator");
            }
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View(new ResetPassword());
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPassword model)
        {
            string oldPassword = model.oldPassword;
            string newPassword = model.newPassword;
            //_logInUserService.GetLoginUserDetail(model.Username, model.Password);
            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View(new Login());
        }
        [HttpPost]
        public IActionResult ForgotPassword(Login model)
        {
            string Password = model.Password;
            //_logInUserService.GetLoginUserDetail(model.Username, model.Password);
            return RedirectToAction("Index", "Login");
        }

        public ActionResult SendOtp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendOtp(Login login)
        {
            Random rdm = new Random();
            int code = rdm.Next(1000, 9999);
            string to = login.Username;
            string subject = "For reset password";
            string body = $"Your code is {code}";
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("kajalpadhiyar962@gmail.com");
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("kajalpadhiyar962@gmail.com", "Nisha@11");
            smtp.Send(mm);
            DateTime currentTime = DateTime.Now;
            DateTime x30MinsLater = currentTime.AddMinutes(30);
            Console.WriteLine(string.Format("{0} {1}", currentTime, x30MinsLater));
            return RedirectToAction("CheckOtp", "Login");
        }
       

        public ActionResult CheckOtp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOtp(string Otp)
        {
            string abc=Otp;
            DateTime currentTime = DateTime.Now;
            DateTime x30MinsLater = currentTime.AddMinutes(30);
            int result = DateTime.Compare(x30MinsLater,currentTime);
            return RedirectToAction("ForgotPassword", "Login");
        }
            public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Home", "Login");
        }
    }
}
