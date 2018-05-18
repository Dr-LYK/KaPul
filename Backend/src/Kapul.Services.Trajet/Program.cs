using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kapul.Services.Trajet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateTrajet>()
                .SubscribeToCommand<DeleteTrajet>()
                .SubscribeToCommand<BookTrajet>()
                //Add subscription
                .Build()
                .Run();
        }
    }
}
