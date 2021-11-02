using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Delete;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetById;
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

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will add new Campaign and returns CampaignId
        /// </summary>
        /// <param name="createCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CampaignCreateCommand createCommand)
        {
            var data = await _mediator.Send(createCommand);
            return Ok(data);
        }

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will give list of Campaigns
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campaignQuery = new CampaignGetAllQuery();
            var data = await _mediator.Send(campaignQuery);
            return Ok(data);
        }


        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will give details of specific Campaign
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will delete details of specific Campaign
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var delete = new DeleteCampaignByIdCommand { CampaignId = id };
            var data = await _mediator.Send(delete);
            return Ok(data);
        }

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will update details of specific campaign
        /// </summary>
        /// <param name="updateCampaign"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCampaignCommand updateCampaign)
        {
            var result = await _mediator.Send(updateCampaign);
            return Ok(result);
        }
    }
}
