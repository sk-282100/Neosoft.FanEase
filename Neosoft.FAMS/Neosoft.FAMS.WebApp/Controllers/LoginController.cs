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
using Neosoft.FAMS.WebApp.Services.Interface;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        ILogin _login;
        IUser _user;
        public LoginController(ILogin login, IUser user)
        {
            _login = login;
            _user = user;
        }
        public IActionResult Index()
        {
            return View(new Login());
        }
        [HttpPost]
        public IActionResult Index(Login model)
        {
            string Username = model.Username;
            string Password = model.Password;
           // var userList = _user.GetAllUserList();

            var serviceresult=_user.SaveUser(new CreateUserCommand {
            DateOfJoining=DateTime.Now,
            FirstName="John",
            IsAdmin=true,
            LastName="john",
            MiddleName="John"
            });
            int result = _login.CheckUsernameAndPassword(Username, Password);
            if (result == 1)
            {
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("Index", "Admin");
            }
            else if (result == 2)
            {
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("ResetPassword", "Login");
            }
            else {
                return RedirectToAction("Index", "Login");
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

            string Password = model.Password;
            string newPassword = model.newPassword;
            var serviceresult = _login.SavePassword(new ResetPasswordCommand
            {
                Username = "test",
                Password = Password,
                newPassword = newPassword
            });

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

            /*
            bool status = repo.SaveOtp(to,code);
            if(status)
            {
                return RedirectToAction("CheckOtp", "Login");
            }
            else
            {
                
            }
            
            //method
           public bool SaveOtp(string user,string code)
           {
            
            DateTime currentTime = DateTime.Now;
            DateTime x10MinsLater = currentTime.AddMinutes(10);
            Console.WriteLine(string.Format("{0} {1}", currentTime, x10MinsLater));

            Login lUser = (from c in db.Logins
                               where c.UserName == user
                               select c).FirstOrDefault();
            int id = lUser.Id;

            if(id!=null)
            {
                PasswordResetRequest passwordResetRequest = new PasswordResetRequest();
                passwordResetRequest.Add(id);
                passwordResetRequest.Add(currentTime);
                passwordResetRequest.Add(code);
                passwordResetRequest.Add(x10MinsLater);
                db.PasswordResetRequests.Add(passwordResetRequest);
                Save();
                return true;
            }
            else
            {
                return false;
            }

            }
             */
            return RedirectToAction("CheckOtp", "Login");

        }


        public ActionResult CheckOtp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOtp(string Otp)
        {
            string code=Otp;

            /*
            bool status = repo.CheckOtp(user, code);
            if (status)
            {
                return RedirectToAction("ForgotPassword", "Login");
            }
            else
            {

            }

            //method
           public bool CheckOtp(string user,string code)
           {
            
            DateTime currentTime = DateTime.Now;

            Login lUser = (from c in db.Logins
                               where c.UserName == user
                               select c).FirstOrDefault();
            int id = lUser.Id;

            PasswordResetRequest r = (from c in db.PasswordResetRequest
                               where c.LoginId == id
                               select c).FirstOrDefault();
            DateTime expairyDate = r.ExpiredOn;

            int result = DateTime.Compare(currentTime, expairyDate);

            if(result<0)
            {
                return false;
            }
            else
            {
                return true;
            }

            }
            */
            return RedirectToAction("ForgotPassword", "Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(Login model)
        {
            string Password = model.Password;


            /*
            bool status = repo.ResetPassword(user, Password);
            if (status)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

            }

            //method
           public bool ResetPassword(string user,string Password)
           {

            Login lUser = (from c in db.Logins
                               where c.UserName == user
                               select c).FirstOrDefault();
            int id = lUser.Id; 


            Login updatedCust = (from c in db.Logins
                              where c.Id == id
                              select c).FirstOrDefault();
            updatedCust.Password = Password; 
            Save();

            */

            return RedirectToAction("Index", "Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Home", "Login");
        }
    }
}
