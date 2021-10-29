using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Author: Shankar Kadam
        /// Date: 29-10-2021
        /// Reason: To validate user credential and get user role
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckUsernameAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CheckUsernameAndPassword(string username, string password)
        {
            LoginQuery loginQuery = new LoginQuery();
            loginQuery.Password = password;
            loginQuery.UserName = username;
            var data = await _mediator.Send(loginQuery);
            return Ok(data);
        }

        [HttpGet]
        [Route("checkUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ForgotPassword(string EmailAddress)
        {
            CheckUsernameCommand checkUsernameCommand = new CheckUsernameCommand();
            checkUsernameCommand.UserName = EmailAddress;
            var data = await _mediator.Send(checkUsernameCommand);
            return Ok(data);
        }

        [HttpPost]
        [Route("Check-Otp")]
        public async Task<IActionResult> CheckOtp(CheckOtpQuery checkOtp)
        {
            var data = await _mediator.Send(checkOtp);
            return Ok(data);
        }


        [HttpGet]
        [Route("ResetPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ResetPassword(string EmailAddress, string Password, string NewPassword)
        {
            ResetPasswordCommand resetPasswordCommand=new ResetPasswordCommand();
            resetPasswordCommand.Username = EmailAddress;
            resetPasswordCommand.Password = Password;
            resetPasswordCommand.newPassword = NewPassword;
            var data = await _mediator.Send(resetPasswordCommand);
            return Ok(data);
        }
    }
}
