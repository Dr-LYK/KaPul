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
            services.AddLogging();

            services.AddDbContext<DataAccess.IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);

            services.AddScoped<DataAccess.IdentityContext, DataAccess.IdentityContext>();

            services.AddScoped<ICommandHandler<CreateCar>, CreateCarHandler>();
            services.AddScoped<DataAccess.Interfaces.ICarRepository, DataAccess.Repositories.CarRepository>();
            services.AddScoped<BusinessManagement.Interfaces.ICarService, BusinessManagement.CarService>();

            services.AddScoped<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddScoped<DataAccess.Interfaces.IUserRepository, DataAccess.Repositories.UserRepository>();
            services.AddScoped<BusinessManagement.Interfaces.IUserService, BusinessManagement.UserService>();
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
