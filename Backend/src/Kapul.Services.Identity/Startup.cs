using System;
using Kapul.Common.Auth;
using Kapul.Common.Commands;
using Kapul.Common.RabbitMq;
//using Kapul.Services.Identity.Domain.Repositories;
//using Kapul.Services.Identity.Domain.Services;
using Kapul.Services.Identity.Handler;
//using Kapul.Services.Identity.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kapul.Services.Identity
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
            services.AddMvc();

            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "kapul12345&";
            //var connString = $"Data Source={hostname};Initial Catalog=KontenaAspnetCore;User ID=sa;Password={password};";

            string _connStr = @"Server=localhost,1401;Database=KaPul;User Id=SA;Password=kapul12345&";

            services.AddDbContext<DataAccess.IdentityContext>(options => options.UseSqlServer(_connStr));

            services.AddMvc();
            services.AddLogging();
            services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<CreateCar>, CreateCarHandler>();
            services.AddScoped<DataAccess.IdentityContext, DataAccess.IdentityContext>();
            services.AddScoped<DataAccess.Interfaces.ICarRepository, DataAccess.Repositories.CarRepository>();
            services.AddScoped<BusinessManagement.Interfaces.ICarService, BusinessManagement.CarService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
