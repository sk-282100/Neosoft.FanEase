using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Create
{
    public class ViewerCreateCommand : IRequest<Response<long>>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public long StateId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
}
