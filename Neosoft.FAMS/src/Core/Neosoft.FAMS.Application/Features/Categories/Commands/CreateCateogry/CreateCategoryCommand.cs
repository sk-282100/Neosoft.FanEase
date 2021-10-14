using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommand : IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
