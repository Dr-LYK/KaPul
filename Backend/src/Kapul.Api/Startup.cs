using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kapul.Api.Handler;
using Kapul.Api.Repositories;
using Kapul.Common.Auth;
using Kapul.Common.Events;
using Kapul.Common.Mongo;
using Kapul.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kapul.Api
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
            services.AddJwt(Configuration);
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<IEventHandler<TrajetCreated>, TrajetCreatedHandler>();
            services.AddScoped<IEventHandler<TrajetDeleted>, TrajetDeletedHandler>();
            //services.AddScoped<IEventHandler<UserAuthenticated>, UserAuthenticatedHandler>();
            //services.AddScoped<IEventHandler<UserCreated>, UserCreatedHandler>();
            services.AddScoped<ITrajetRepository, TrajetRepository>();
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
