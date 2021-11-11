using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Events.Login.Commands
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IContentCreatorRepo _creator;
        private readonly IMapper _mapper;
        public ResetPasswordCommandHandler(ILoginRepo loginRepository, IMapper mapper, IContentCreatorRepo creator)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
            _creator = creator;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var data = await _loginRepository.ResetPassword(request.Username, request.Password);
            var creatorData = await _creator.GetByEmailAsync(request.Username);
            long id = data.Id;
            data.Password = request.newPassword;
            if (data != null)
            {
                var update = _mapper.Map<Neosoft.FAMS.Domain.Entities.Login>(data);
                await _loginRepository.UpdateAsync(update);
                creatorData.isPassowrdUpdated = true;
                await _creator.UpdateAsync(creatorData);

                return true;
            }

            return false;
        }
    }
}
