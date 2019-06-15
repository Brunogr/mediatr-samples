using Commander.Abstractions;
using Flunt.Notifications;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr.Samples.Domain.Base
{
    public abstract class AggregateRoot : Notifiable
    {
        public AggregateRoot()
        {
            DomainEvents = new List<IEvent>();
        }

        [BsonIgnore]
        public List<IEvent> DomainEvents { get; private set; }

        protected void AddEvent(IEvent @event)
        {
            this.DomainEvents.Add(@event);
        }
    }
}
