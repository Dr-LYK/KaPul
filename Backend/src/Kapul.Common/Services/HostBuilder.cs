using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Services
{
    public class HostBuilder : BuilderBase
    {
        private readonly IWebHost _webHost;
        private IBusClient _bus;

        public HostBuilder(IWebHost webHost)
        {
            this._webHost = webHost;
        }

        public BusBuilder UseRabbitMq()
        {
            this._bus = (IBusClient)this._webHost.Services.GetService(typeof(IBusClient));
            return new BusBuilder(_webHost, _bus);
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}
