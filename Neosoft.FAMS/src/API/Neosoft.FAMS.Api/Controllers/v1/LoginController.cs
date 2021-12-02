using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Queries;
using System.Threading.Tasks;
using Neosoft.FAMS.Domain.Entities;

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
        [HttpPost]
        [Route("CheckUsernameAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CheckUsernameAndPassword(Login _login)
        {
            LoginQuery loginQuery = new LoginQuery();
            loginQuery.Password = _login.Password;
            loginQuery.UserName = _login.Username;
            var data = await _mediator.Send(loginQuery);
            if(data==null)
                return NotFound();
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
        public async Task<IActionResult> CheckOtp(string Username, string Otp)
        {
            CheckOtpQuery checkOtpQuery = new CheckOtpQuery();
            checkOtpQuery.Otp = Otp;
            checkOtpQuery.Username = Username;
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
        [HttpPost]
        [Route("ResetPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand reset)
        {
            ResetPasswordCommand resetPasswordCommand = new ResetPasswordCommand();
            resetPasswordCommand.Username = reset.Username;
            resetPasswordCommand.Password = reset.Password;
            resetPasswordCommand.newPassword = reset.newPassword;
            var data = await _mediator.Send(resetPasswordCommand);
            return Ok(data);
        }


        /// <summary>
        /// Author: Sana Haju
        /// Date: 15-11-2021
        /// Reason:If User Forgot Password,Will be Able to Reset Password 
        /// </summary>
        /// <param name="forgot"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ForgotPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> NewPassword(ForgotPasswordCommand forgot)
        {
            ForgotPasswordCommand forgotPasswordCommand = new ForgotPasswordCommand();
            forgotPasswordCommand.Username = forgot.Username;
            forgotPasswordCommand.newPassword = forgot.newPassword;
            var data = await _mediator.Send(forgotPasswordCommand);
            return Ok(data);
        }
    }
}
