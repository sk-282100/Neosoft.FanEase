using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword;
using Neosoft.FAMS.Application.Features.Login.Queries;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.WebApp.Models.LoginModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;
        private ICreator _creator;
        private IUser _user;
        public LoginController(ILogin login, IUser user, ICreator creator)
        {
            _login = login;
            _creator = creator;
            _user = user;
        }
        public IActionResult Index()
        {
            ViewData["isTrueCredentials"] = false;
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
                var data = _login.CheckUsernameAndPassword(Username, Password);
                if (data != null)
                {
                    int RoleId = Convert.ToInt32(data[1]);
                    HttpContext.Session.SetString("LoginId", data[0].ToString());

                    if (RoleId == 1)
                    {
                        HttpContext.Session.SetString("Username", model.Username);
                        HttpContext.Session.SetString("RoleId", RoleId.ToString());

                        return RedirectToAction("Index", "Admin");
                    }
                    else if (RoleId == 2)
                    {
                        HttpContext.Session.SetString("Username", model.Username);
                        HttpContext.Session.SetString("RoleId", RoleId.ToString());
                        var creatorData = _creator.GetCreatorByEmail(HttpContext.Session.GetString("Username"));
                        HttpContext.Session.SetString("ContentCreatorId", creatorData.ContentCreatorId.ToString());

                        if (creatorData.isPassowrdUpdated)
                            return RedirectToAction("Index", "Creator");
                        return RedirectToAction("ResetPassword", "Login");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    ViewData["isTrueCredentials"] = true;
                    return View();
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
                    Username = HttpContext.Session.GetString("Username"),
                    Password = Password,
                    newPassword = newPassword
                });

                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public IActionResult SendOtp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendOtp(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                string Username = model.Username;
                HttpContext.Session.SetString("UserName", model.Username);
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
        public ActionResult CheckOtp(PasswordResetRequest passwordResetRequest)
        {
            string id = HttpContext.Session.GetString("UserName");
            string code = passwordResetRequest.Otp;
            var serviceresult = _login.CheckOTP(new CheckOtpQuery
            {
                Username=id,
                Otp = code,

            });


            return RedirectToAction("ForgotPassword", "Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(Login model)
        {
            string id = HttpContext.Session.GetString("UserName");
            string newPassword = model.Password;
            var serviceresult = _login.ForgotPassword(new ForgotPasswordCommand
            {
                Username = id,
                newPassword = newPassword,
                
            });

            return RedirectToAction("Index", "Login");
                
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("RoleId");
            HttpContext.Session.Remove("LoginId");

            return RedirectToAction("Home", "Login");
        }
    }
}
