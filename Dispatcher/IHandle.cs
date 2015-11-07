using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    public interface IHandle<TMessage> where TMessage : Message
    {
        void Handle(TMessage message);
    }

    public interface IHandle
    {
        void Handle(Message message);
    }
}
