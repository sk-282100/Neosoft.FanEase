using MediatR;


namespace Neosoft.FAMS.Application.Features.VideoPage.Commands.CheckClickId
{
    public class CheckClickIdCommand :IRequest<bool>
    {
        public long id { get; set; }
    }
}
