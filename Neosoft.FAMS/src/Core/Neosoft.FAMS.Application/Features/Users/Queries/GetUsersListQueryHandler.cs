using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Users.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, Response<IEnumerable<UserListVm>>>
    {
        private readonly IAsyncRepository<UserDemo> _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IMapper mapper, IAsyncRepository<UserDemo> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<IEnumerable<UserListVm>>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var allUserList = (await _userRepository.ListAllAsync());
            var UserList = _mapper.Map<List<UserListVm>>(allUserList);
            var response = new Response<IEnumerable<UserListVm>>(UserList);
            return response;
        }
    }
}
