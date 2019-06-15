using Commander.Abstractions;
using Commander.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Core
{
    internal class DomainEventHandler : EventHandler<DomainEvent>
    {
        private readonly IMessageBus messageBus;
        private readonly IHandler handler;

        public DomainEventHandler(IMessageBus messageBus, IHandler handler)
        {
            this.messageBus = messageBus;
            this.handler = handler;
        }
        public async override Task HandleEvent(DomainEvent @event)
        {
            if (@event.Event is IEventAsync)
                await this.messageBus.PublishAsync(@event.Event);
            else
                await handler.RaiseEvent(@event.Event);
        }
    }
}
