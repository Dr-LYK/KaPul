using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Services
{
    public class ServiceHost: IServiceHost
    {
        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            this._webHost = webHost;
        }

        public void Run()
        {
            _webHost.Run();
        }

        public static HostBuilder Create<TStartup>(string[] args) where TStartup: class
        {
            Console.Title = typeof(TStartup).Namespace;
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();
            return new HostBuilder(webHostBuilder.Build());
        }
    }
}
