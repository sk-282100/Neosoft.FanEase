using MediatR;

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    public class GetPhoneCodeQuery : IRequest<long>
    {
        public int countryId { get; set; }

    }
}
