using MediatR;

namespace Neosoft.FAMS.Application.Features.Login.Commands
{
    public class CheckUsernameCommand : IRequest<bool>
    {
        public string UserName { get; set; }
    }
}
