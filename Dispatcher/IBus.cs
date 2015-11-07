using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    public interface IBus : IPublisher
    {
        void Subscribe<TMessage>(IHandle<TMessage> handler) where TMessage : Message;
    }
}
