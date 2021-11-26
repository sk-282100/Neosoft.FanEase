using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neosoft.FAMS.WebApp.Profiles;
using Neosoft.FAMS.WebApp.Services;
using System;
using Neosoft.FAMS.WebApp.Models;

namespace Neosoft.FAMS.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mappers());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<Services.Interface.ILogin, Login>();
            services.AddScoped<Services.Interface.ICreator, Creator>();

            services.AddScoped<Services.Interface.IUser, User>();
            services.AddScoped<Services.Interface.IVideo, Video>();
            services.AddScoped<Services.Interface.IViewer, Viewer>();
            services.AddScoped<Services.Interface.ICampaign, Campaign>();
            services.AddScoped<Services.Interface.IAsset, Asset>();
            services.AddScoped<Services.Interface.ICommon, Common>();
            services.AddScoped<Services.Interface.Itemplate, Template>();
            services.AddScoped<Services.Interface.IVideoStatistics, VideoStatistics>();
            services.AddScoped<Services.Interface.IAdminDashboard, AdminDashboard>();
            services.AddScoped<Services.Interface.ICreatorDashboard, CreatorDashboard>();
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            //services.AddDbContext<SuperHeroContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DemoCustDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* if (env.IsDevelopment())
             {

                 app.UseDeveloperExceptionPage();

             }
             else
             {
                 app.UseExceptionHandler("/Home/Error");
                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                 app.UseHsts();
             }*/
            app.UseExceptionHandler("/Error/Error500");
            //app.UseExceptionHandlerMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Home}/{id?}");
            });
        }
    }
}
