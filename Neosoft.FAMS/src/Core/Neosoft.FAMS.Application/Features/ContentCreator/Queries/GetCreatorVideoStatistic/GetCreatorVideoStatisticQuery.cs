using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetCreatorVideoStatistic
{
    public class GetCreatorVideoStatisticQuery:IRequest<GetCreatorVideoStatisticDto>
    {
        public long CreatedById { get; set; }
    }
}
