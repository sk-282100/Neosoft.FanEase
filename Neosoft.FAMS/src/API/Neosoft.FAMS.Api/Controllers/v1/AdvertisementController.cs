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
        /// <summary>
        /// Author:Aman Sharma
        /// Date:25/10/2021
        /// Reason:It will Add New Advertisement
        /// </summary>
        /// <param name="createAdvertisement"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAdvertisement([FromBody]CreateAdvertisementCommand createAdvertisement)
        {
            var result = await _mediator.Send(createAdvertisement);
            return Ok(result);
        }
        /// <summary>
        /// Author:Aman Sharma
        /// Date:25/10/2021
        /// Reason:It will Get List of All Advertisment as a List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAdvertisement = new GetAdvertisementListQuery();
            var result = await _mediator.Send(getAdvertisement);
            return Ok(result);
        }
        /// <summary>
        /// Author:Aman Sharma
        /// Date:25/10/2021
        /// Reason:It will get Details of a Specific Advertisement by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var getAdvertisement = new GetAvertisementByIdQuery() {AdvertisementId=id };
            var result = await _mediator.Send(getAdvertisement);
            return Ok(result);
        }
        /// <summary>
        /// Author:Aman Sharma
        /// Date:25/10/2021
        /// Reason:It will Delete Details of Specific Advertisement by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var getAdvertisement = new DeleteAdvertisementCommand() { AdvertisementId = id };
            var result = await _mediator.Send(getAdvertisement);
            return Ok(result);
        }

        /// <summary>
        /// Author:Aman Sharma
        /// Date:25/10/2021
        /// Reason:It will Update Specific Advertisement by Id
        /// </summary>
        /// <param name="updateAdvertisement"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAdvertisementCommand updateAdvertisement)
        {
            var result = await _mediator.Send(updateAdvertisement);
            return Ok(result);
        }
    }
}
