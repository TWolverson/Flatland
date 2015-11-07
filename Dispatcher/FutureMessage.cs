using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    public class FutureMessage:Message
    {
        public Message Message { get; private set; }

        public DateTimeOffset RetryAt { get; set; }

        public FutureMessage(Message message, DateTimeOffset retryAt)
        {
            Message = message;
            RetryAt = retryAt;
        }
    }
}
