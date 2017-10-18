using AutoMapper;
using HanaSpa.Business;
using HanaSpa.Data.DbContext;
using HanaSpa.Data.Repository;
using HanaSpa.Infrastructure.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RivonHouse.Infrastructure.Repository;

namespace HanaSpa.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // For cross server communication	
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
            });

            // Add framework services.
            services.AddMvc();
            services.AddSession();

            services.AddAutoMapper();
            //Add DBContext
            services.AddDbContext<HanaSpaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            // Register application business
            services.AddTransient<IService, Service>();
            services.AddTransient<IUnitOfWorkFactory<IUnitOfWork>, UnitOfWorkFactory<UnitOfWork,HanaSpaContext>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Shows UseCors with named policy.
            app.UseCors("AllowSpecificOrigin");

            // Session must use before MVC
            app.UseSession();
            app.UseMvc();
        }
    }
}
