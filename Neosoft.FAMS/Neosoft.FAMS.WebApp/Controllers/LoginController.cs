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
using Neosoft.FAMS.WebApp.Models;

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
                        MappingViewModel.CreatedBy = creatorData.ContentCreatorId;
                        if (creatorData.isPassowrdUpdated)
                            return RedirectToAction("Index", "Creator");
                        return RedirectToAction("ResetPassword", "Login");
                    }
                    else if (RoleId == 3)
                    {
                        HttpContext.Session.SetString("Username", model.Username);
                        HttpContext.Session.SetString("RoleId", RoleId.ToString());
                        return RedirectToAction("DisplayAllVideos", "Viewer");
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
            ViewData["isTrueCredentials"] = false;
            return View(new ResetPassword());
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                string Password = model.Password;
                string newPassword = model.newPassword;
                var result = _login.SavePassword(new ResetPasswordCommand
                {
                    Username = HttpContext.Session.GetString("Username"),
                    Password = Password,
                    newPassword = newPassword
                });
                if(Convert.ToBoolean(result.Result))
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewData["isTrueCredentials"] = true;
                    return View();
                }
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
                var result = _login.SaveOTP(new CheckUsernameCommand
                {
                    UserName = Username,

                });
                if (Convert.ToBoolean(result.Result))
                {
                    return RedirectToAction("CheckOtp", "Login");
                }
                else
                {
                    ViewData["isTrueCredentials"] = true;
                    return View();
                }
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
            var result = _login.CheckOTP(new CheckOtpQuery
            {
                Username=id,
                Otp = code,

            });
            if (result.Result>0)
            {
                return RedirectToAction("ForgotPassword", "Login");
            }
            else
            {
                ViewData["isTrueCredentials"] = true;
                return View();
            }

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
            var result = _login.ForgotPassword(new ForgotPasswordCommand
            {
                Username = id,
                newPassword = newPassword,
                
            });
            if (Convert.ToBoolean(result.Result))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["isTrueCredentials"] = true;
                return View();
            }

                
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
