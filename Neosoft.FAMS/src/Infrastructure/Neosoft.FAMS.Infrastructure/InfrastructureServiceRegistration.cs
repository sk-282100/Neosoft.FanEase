using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neosoft.FAMS.Application.Contracts.Infrastructure;
using Neosoft.FAMS.Application.Models.Mail;
using Neosoft.FAMS.Infrastructure.Mail;

namespace Neosoft.FAMS.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
