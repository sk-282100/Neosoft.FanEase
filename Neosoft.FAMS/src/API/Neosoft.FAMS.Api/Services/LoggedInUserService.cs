using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.Application.Contracts;
using System.Security.Claims;

namespace Neosoft.FAMS.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
