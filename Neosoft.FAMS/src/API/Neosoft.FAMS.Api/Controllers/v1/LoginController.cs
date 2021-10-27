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

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Login(LoginQuery loginQuery)
        {
            var data = await _mediator.Send(loginQuery);
            return Ok(data);
        }

        [HttpPost]
        [Route("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(CheckUsernameCommand checkUsernameCommand)
        {
            var data = await _mediator.Send(checkUsernameCommand);
            return Ok(data);
        }

        [HttpPost]
        [Route("Reset-Password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetPasswordCommand)
        {
            var data = await _mediator.Send(resetPasswordCommand);
            return Ok(data);
        }
    }
}
