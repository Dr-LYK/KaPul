using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kapul.Common.Events;
using Kapul.Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kapul.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<TrajetCreated>()
                .SubscribeToEvent<TrajetDeleted>()
                .SubscribeToEvent<TrajetBooked>()
                //Add subscription
                .Build()
                .Run();
        }
    }
}
