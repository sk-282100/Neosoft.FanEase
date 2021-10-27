using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Create;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentCreatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContentCreatorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContentCreaterCommand createCommand)
        {
            var data = await _mediator.Send(createCommand);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var creatorQuery = new ContentCreatorQuery();
            var data = await _mediator.Send(creatorQuery);
            return Ok(data);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var creatorQuery = new GetContentCreatorByIdQuery { creatorId = id };
            var data = await _mediator.Send(creatorQuery);
            if(data!=null)
                return Ok(data);
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var delete = new DeleteCreatorByIdCommand { CreatorId = id };
            var data =  await _mediator.Send(delete);
            return Ok(data);
        }
    }
}
