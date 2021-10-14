using MediatR;
using Neosoft.FAMS.Application.Responses;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}
