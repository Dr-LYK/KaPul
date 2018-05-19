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

namespace Kapul.Services.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateCar>()
                       .SubscribeToCommand<CreateUser>()
                       .SubscribeToCommand<DeleteUser>()
                       .SubscribeToCommand<UpdateUser>()
                       .SubscribeToCommand<DeleteUser>()
                       .SubscribeToCommand<AuthenticateUser>()
                //Add subscription
                .Build()
                .Run();
        }
    }
}
