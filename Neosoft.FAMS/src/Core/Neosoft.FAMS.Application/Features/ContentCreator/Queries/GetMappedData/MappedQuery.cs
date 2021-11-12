using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData
{
    public class MappedQuery : IRequest<MappedDto>
    {
        public long VideoId { get; set; }
    }
}
