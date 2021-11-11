using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Users.Queries;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{

    [Route("api/[controller]")]
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

        [HttpGet()]
        [Route("GetAllUserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUserList()
        {
            _logger.LogInformation("GetAllUserList Initiated");
            var dtos = await _mediator.Send(new GetUsersListQuery());
            _logger.LogInformation("GetAllUserList Completed");
            return Ok(dtos);
        }

        [HttpPost]
        [Route("SaveUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            //CreateUserCommand createUserCommand = new CreateUserCommand();
            _logger.LogInformation("SaveUser Initiated");
            var dtos = await _mediator.Send(createUserCommand);
            _logger.LogInformation("SaveUser Completed");
            return Ok(dtos);
        }
    }
}
