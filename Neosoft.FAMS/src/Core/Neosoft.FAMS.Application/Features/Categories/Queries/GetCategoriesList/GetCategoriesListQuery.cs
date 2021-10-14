using MediatR;
using Neosoft.FAMS.Application.Responses;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
