using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    public interface IPublisher
    {
        void Publish(Message message);
    }
}
