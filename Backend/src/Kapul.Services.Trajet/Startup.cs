using Kapul.Common.Commands;
using Kapul.Common.Mongo;
using Kapul.Common.RabbitMq;
using Kapul.Services.Trajet.Handler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kapul.Services.Trajet
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
            services.AddRabbitMq(Configuration);
            services.AddMongoDB(Configuration);
            services.AddScoped<ICommandHandler<CreateTrajet>, CreateTrajetHandler>();
            services.AddScoped<Domain.Repositories.ITrajetRepository, Repository.TrajetRepository>();
            services.AddScoped<IDatabaseSeeder, Services.CustomMongoSeeder>();
            services.AddScoped<Services.ITrajetService, Services.TrajetService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
