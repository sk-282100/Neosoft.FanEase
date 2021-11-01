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

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: 1 It will check whether username is valid
        ///         2 If valid then it will send OTP
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will check whether OTP is valid or not and also check whether it is expired or not
        /// </summary>
        /// <param name="Otp"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckOtp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CheckOtp(string Otp)
        {
            CheckOtpQuery checkOtpQuery = new CheckOtpQuery();
            checkOtpQuery.Otp = Otp;
            var data = await _mediator.Send(checkOtpQuery);
            return Ok(data);
        }


        /// <summary>
        /// Author: Sana Haju
        /// Date: 27-10-2021
        /// Reason: To ResetPassword Using oldPassword and newPassword
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <param name="Password"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
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
