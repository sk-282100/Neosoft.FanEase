using MediatR;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetById
{
    public class GetContentCreatorByIdQuery : IRequest<ContentCreatorDto>
    {
        public long creatorId { get; set; }
    }
}
