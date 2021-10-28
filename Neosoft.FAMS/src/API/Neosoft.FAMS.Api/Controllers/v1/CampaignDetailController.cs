using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Delete;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CampaignDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CampaignCreateCommand createCommand)
        {
            var data = await _mediator.Send(createCommand);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campaignQuery = new CampaignGetAllQuery();
            var data = await _mediator.Send(campaignQuery);
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var creatorQuery = new GetCampaignByIdQuery { CampaignId = id };
            var data = await _mediator.Send(creatorQuery);
            if (data != null)
                return Ok(data);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var delete = new DeleteCampaignByIdCommand { CampaignId = id };
            var data = await _mediator.Send(delete);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCampaignCommand updateCampaign)
        {
            var result = await _mediator.Send(updateCampaign);
            return Ok(result);
        }
    }
}
