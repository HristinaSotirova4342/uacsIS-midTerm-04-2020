using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using UniversityApplication.Data;
using UniversityApplication.Data.Profiles;
using UniversityApplication.Service.Service;
using UniversityApplication.WebApi.Infrastructure;

namespace UniversityApplication.WebApi
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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new StudentProfile()); 
                mc.AddProfile(new TranscriptProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services
                .Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services
                .AddSingleton<IConfiguration>(Configuration);
            services
                .AddDbContextPool<UniversityDataContext>((serviceProvider, options) =>
                {
                    options
                        .UseSqlServer(Configuration.GetSection("ConnectionStrings")
                            .GetSection("DefaultConnection").Value,
                            x => x.MigrationsAssembly("UniversityApplication.Data"));
                    options
                        .UseInternalServiceProvider(serviceProvider);
                });

            services
                .AddScoped<IUniversityService, UniversityService>()
                .AddScoped<ITranscriptService, TranscriptService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            app.EnsureMigrationOfContext<UniversityDataContext>(); /* Automatic Migrations Version 2*/
            //UpdateDatabase(app); /* Automatic Migrations Version 2*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<UniversityDataContext>();
            context.Database.Migrate();
        }
    }
}
