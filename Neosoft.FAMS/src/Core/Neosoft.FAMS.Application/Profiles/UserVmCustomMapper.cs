using AutoMapper;
using Neosoft.FAMS.Application.Features.Users.Queries;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Profiles
{
    public class UserVmCustomMapper : ITypeConverter<UserDemo, UserListVm>
    {
        public UserVmCustomMapper()
        {

        }
        public UserListVm Convert(UserDemo source, UserListVm destination, ResolutionContext context)
        {
            UserListVm dest = new UserListVm()
            {

                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                LastName = source.LastName
            };

            return dest;
        }
    }
}
