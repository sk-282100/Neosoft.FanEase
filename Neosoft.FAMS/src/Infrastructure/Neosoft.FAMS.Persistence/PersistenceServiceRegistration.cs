using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Persistence.Repositories;

namespace Neosoft.FAMS.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepo, LoginRepo>();
            services.AddScoped<IContentCreatorRepo, ContentCreatorRepo>();
            services.AddScoped<IViewerRepo, ViewerRepo>();
            services.AddScoped<IVideoRepository, VideoRepo>();
            services.AddScoped<ICampaignDetailRepo, CampaignDetailRepo>();
            services.AddScoped<IAdvertisementRepo, AdvertisementRepo>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            return services;
        }
    }
}
