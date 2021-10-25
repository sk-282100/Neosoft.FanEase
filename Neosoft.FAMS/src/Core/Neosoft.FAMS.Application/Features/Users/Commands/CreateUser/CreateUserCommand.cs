using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Response<Guid>>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsAdmin { get; set; }
        public override string ToString()
        {
            return $"FirstName: {FirstName}; MiddleName: {MiddleName}; LastName: {LastName}; DateOfJoining: {DateOfJoining}; IsAdmin: {IsAdmin}";
        }
    }
}
