using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.Abstractions
{

    public interface IEventAsync : IEvent
    {
    }
    public interface IEvent : INotification, IMessage
    {
    }
}
