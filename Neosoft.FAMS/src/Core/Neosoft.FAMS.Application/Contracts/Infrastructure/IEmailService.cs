using Neosoft.FAMS.Application.Models.Mail;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
