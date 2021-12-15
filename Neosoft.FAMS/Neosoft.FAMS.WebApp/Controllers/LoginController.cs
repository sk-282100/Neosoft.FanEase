﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword;
using Neosoft.FAMS.Application.Features.Login.Queries;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.WebApp.Models.LoginModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Linq;
using Neosoft.FAMS.WebApp.Models;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Neosoft.FAMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;
        private ICreator _creator;
        private readonly ICommon _common;
        private IUser _user;
        private readonly INotyfService _notyf;
        public LoginController(ILogin login, IUser user, ICreator creator,ICommon common, INotyfService notyfService)
        {
            _login = login;
            _creator = creator;
            _common = common;
            _user = user;
            _notyf = notyfService;

        }
        public IActionResult Index()
        {
            ViewData["isTrueCredentials"] = false;
            return View(new Login());
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login model)
        {
            if (ModelState.IsValid)
            {
                string Username = model.Username;
                string Password = model.Password;

                var data = await _login.CheckUsernameAndPassword(Username, Password);
                if (data != null)
                {
                    int RoleId = Convert.ToInt32(data.RoleId);
                    HttpContext.Session.SetString("LoginId", data.Id.ToString());
                    RoleSessionStaticModel.RoleId = Convert.ToInt32(data.RoleId);
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

        public async Task<Domain.Entities.Login> ValidateUser(string Username, string Password) {
            return await _login.CheckUsernameAndPassword(Username, Password);
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            ViewData["isTrueCredentials"] = false;
            ViewData["isMatching"] = false;
            return View(new ResetPassword());
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                string Password = model.Password;
                string newPassword = model.newPassword;
                string confirmPassword = model.confirmPassword;
                ViewData["oldPassword"] = Password;
                ViewData["newPassword"] = newPassword;
                ViewData["confirmPassword"] = confirmPassword;
                if (newPassword == confirmPassword)
                {
                    var result = _login.SavePassword(new ResetPasswordCommand
                    {
                        Username = HttpContext.Session.GetString("Username"),
                        Password = Password,
                        newPassword = newPassword
                    });
                    if (Convert.ToBoolean(result.Result))
                    {
                       /* _notyf.Success("Password has been updated successfully", 6);*/
                        Logout();
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ViewData["isTrueCredentials"] = true;
                        return View();
                    }
                }
                else
                {
                    ViewData["isMatching"] = true;
                    return View();
                }
            }
            ViewData["oldPassword"] = model.Password;
            ViewData["newPassword"] = model.newPassword;
            ViewData["confirmPassword"] = model.confirmPassword;
            return View();
        }

        public IActionResult SendOtp()
        {
            ViewData["isTrueCredentials"] = false;
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
            ViewData["isTrueCredentials"] = false;
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
            ViewData["isTrueCredentials"] = false;
            ViewData["isMatching"] = false;
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(Login model)
        {
            string id = HttpContext.Session.GetString("UserName");
            string newPassword = model.Password;
            string confirmPassword = model.confirmPassword;

            ViewData["newPassword"] = newPassword;
            ViewData["confirmPassword"] = confirmPassword;
            if (newPassword == confirmPassword)
            {
                var result = _login.ForgotPassword(new ForgotPasswordCommand
                {
                    Username = id,
                    newPassword = newPassword,

                });
                if (Convert.ToBoolean(result.Result))
                {
                    /*_notyf.Success("Password has been updated successfully", 6);*/
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewData["isTrueCredentials"] = true;
                    return View();
                }
            }
            else
            {
                ViewData["isMatching"] = true;
                return View();
            }


        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("RoleId");
            HttpContext.Session.Remove("LoginId");
            HttpContext.Session.Remove("isVideoAdded");
            HttpContext.Session.Remove("isCampaignAdded");
            HttpContext.Session.Remove("isAssetAdded");
            return RedirectToAction("Index", "Login");
        }
    }
}
