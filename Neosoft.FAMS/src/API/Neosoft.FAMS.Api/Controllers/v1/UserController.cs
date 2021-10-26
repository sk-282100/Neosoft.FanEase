using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Users.Queries;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;


        public UserController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllUserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUserList()
        {
            _logger.LogInformation("GetAllUserList Initiated");
            var dtos = await _mediator.Send(new GetUsersListQuery());
            _logger.LogInformation("GetAllUserList Completed");
            return Ok(dtos);
        }

        [HttpGet("save", Name = "SaveUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            _logger.LogInformation("SaveUser Initiated");
            var dtos = await _mediator.Send(createUserCommand);
            _logger.LogInformation("SaveUser Completed");
            return Ok(dtos);
        }
    }
}
