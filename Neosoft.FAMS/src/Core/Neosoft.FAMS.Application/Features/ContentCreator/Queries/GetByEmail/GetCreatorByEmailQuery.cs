using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetByEmail
{
    public class GetCreatorByEmailQuery : IRequest<ContentCreatorDto>
    {
        public string Username { get; set; }
    }
}
