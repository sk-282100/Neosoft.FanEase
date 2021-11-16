using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetVideoOfCreatorById
{
    public class GetVideoOfCreatorQuery:IRequest<List<GetVideoOfCreatorDto>>
    {
        public long CreatedBy { get; set; }
    }
}
