using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddAdvertisement([FromBody]CreateAdvertisementCommand createAdvertisement)
        {
            var result = await _mediator.Send(createAdvertisement);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAdvertisement = new GetAdvertisementListQuery();
            var result = await _mediator.Send(getAdvertisement);
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var getAdvertisement = new GetAvertisementByIdQuery() {AdvertisementId=id };
            var result = await _mediator.Send(getAdvertisement);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var getAdvertisement = new DeleteAdvertisementCommand() { AdvertisementId = id };
            var result = await _mediator.Send(getAdvertisement);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdvertisementCommand updateAdvertisement)
        {
            var result = await _mediator.Send(updateAdvertisement);
            return Ok(result);
        }
    }
}
