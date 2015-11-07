﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging
{
    public class RetryMessage : Message
    {
        public Message Message { get; set; }

        public RetryMessage(Message message)
        {
            Message = message;
        }
    }
}
