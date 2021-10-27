using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete
{
   public class DeleteCreatorByIdCommand : IRequest<Response<bool>>
    {
        public long CreatorId { get; set; }
    }
}
