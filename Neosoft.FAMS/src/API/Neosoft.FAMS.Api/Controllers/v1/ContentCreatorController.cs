using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Create;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetByEmail;
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
        /// <summary>
        /// Author :Aman Sharma,Sana Haju <br></br>
        /// Date : 25/10/2021 <br></br>
        /// Reason : It will Add New Content Creator
        /// </summary>
        /// <param name="createCommand"></param>
        /// <returns>name="ContentCreatorId</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ContentCreaterCommand createCommand)
        {
            var data = await _mediator.Send(createCommand);
            return Ok(data);
        }

        /// <summary>
        /// Author:Aman Sharma,Sana Haju
        /// Date:25/10/2021
        /// Reason:It Will Get All Content Creators List
        /// </summary>
        /// <returns>List of All Content Creators</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var creatorQuery = new ContentCreatorQuery();
            var data = await _mediator.Send(creatorQuery);
            return Ok(data);
        }
        /// <summary>
        /// Author:Aman Sharma,Sana Haju <br></br>
        /// Date:25/10/2021 <br></br>
        /// Reason:It will return Content Creators of specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author:Aman Sharma, Sana Haju <br></br>
        /// Date:25/10/2021 <br></br>
        /// Reason:Will delete content creator for a specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var delete = new DeleteCreatorByIdCommand { CreatorId = id };
            var data =  await _mediator.Send(delete);
            return Ok(data);
        }
        /// <summary> 
        /// Author:Aman Sharma, Sana Haju <br></br>
        /// Date:25/10/2021 <br></br>
        /// Reason:It Will Update Record of a specific content creator by id 
        /// </summary>
        /// <param name="updateCreatorByIdCommand"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateById(UpdateCreatorByIdCommand updateCreatorByIdCommand)
        {
            var data = await _mediator.Send(updateCreatorByIdCommand);
            return Ok(data);

        }
        /// <summary>
        ///Author:Aman Sharma <br></br>
        /// Date:02/11/2021 <br></br>
        /// Reason:It Will Return Record of a specific content creator by Email 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCreatorByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery]string username)
        {
            var Email = username.Split('?');
            var creatorQuery = new GetCreatorByEmailQuery { Username = Email[0] };
            var data = await _mediator.Send(creatorQuery);
            if (data != null)
                return Ok(data);
            return BadRequest();
        }

    }
}
