using Moq;
using Neosoft.FAMS.Application.Contracts.Infrastructure;
using Neosoft.FAMS.Application.Models.Mail;

namespace Neosoft.FAMS.Application.UnitTests.Mocks
{
    public class EmailServiceMocks
    {
        public static Mock<IEmailService> GetEmailService()
        {
            var mockEmailService = new Mock<IEmailService>();
            mockEmailService.Setup(x => x.SendEmail(It.IsAny<Email>())).ReturnsAsync(true);
            return mockEmailService;
        }
    }
}
