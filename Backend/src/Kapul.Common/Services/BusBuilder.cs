using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Services
{
    public class BusBuilder : BuilderBase
    {
        private readonly IWebHost _webHost;
        private IBusClient _bus;

        public BusBuilder(IWebHost webHost, IBusClient bus)
        {
            this._webHost = webHost;
            this._bus = bus;
        }

        public BusBuilder SubscribeToCommand<TCommand>() where TCommand: ICommand
        {
            ICommandHandler<TCommand> handler = (ICommandHandler<TCommand>)_webHost.Services.GetService(typeof(ICommandHandler<TCommand>));
            this._bus.WithCommandHandlerAsync(handler);
            return this;
        }

        public BusBuilder SubscribeToEvent<TEvent>() where TEvent: IEvent
        {
            IEventHandler<TEvent> handler = (IEventHandler<TEvent>)_webHost.Services.GetService(typeof(IEventHandler<TEvent>));
            this._bus.WithEventHandlerAsync(handler);
            return this;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}
