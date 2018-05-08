using System.Reflection;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using RawRabbit;
using RawRabbit.Pipe;

namespace Kapul.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
        => bus.SubscribeAsync<TCommand>(message => handler.HandleAsync(message),
            context => context.UseConsumerConfiguration(
                configuration => configuration.FromDeclaredQueue(
                    queue => queue.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
        => bus.SubscribeAsync<TEvent>(message => handler.HandleAsync(message),
            context => context.UseConsumerConfiguration(
                configuration => configuration.FromDeclaredQueue(
                    queue => queue.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>()
        {
            return $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
        }
    }
}
