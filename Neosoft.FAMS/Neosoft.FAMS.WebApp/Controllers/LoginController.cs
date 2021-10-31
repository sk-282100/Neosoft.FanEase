using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Models.LoginModel;
using Neosoft.FAMS.WebApp.Models.LoginModel;
using System.Net.Mail;
using System.Security.Cryptography;
using Neosoft.FAMS.WebApp.Services.Interface;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;

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
            if (ModelState.IsValid)
            {
                string Username = model.Username;
                string Password = model.Password;
                // var userList = _user.GetAllUserList();

                var serviceresult = _user.SaveUser(new CreateUserCommand
                {
                    DateOfJoining = DateTime.Now,
                    FirstName = "John",
                    IsAdmin = true,
                    LastName = "john",
                    MiddleName = "John"
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
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
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
            if (ModelState.IsValid)
            {
                string Password = model.Password;
                string newPassword = model.newPassword;
                var serviceresult = _login.SavePassword(new ResetPasswordCommand
                {
                    Username = "test",
                    Password = Password,
                    newPassword = newPassword
                });

                return RedirectToAction("SendOtp", "Login");
            }
            return View();
        }

        public IActionResult SendOtp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendOtp(Login login)
        {
            if (ModelState.IsValid)
            {
                string Username = login.Username;
                var serviceresult = _login.SaveOTP(new CheckUsernameCommand
                {
                    UserName = Username,

                });
                return RedirectToAction("CheckOtp", "Login");
            }
            return View();

        }


        public ActionResult CheckOtp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOtp(string Otp)
        {
            string code=Otp;

           
            return RedirectToAction("ForgotPassword", "Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(Login model)
        {
            if (ModelState.IsValid)
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
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Home", "Login");
        }
    }
}
