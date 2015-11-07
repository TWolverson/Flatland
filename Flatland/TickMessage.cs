using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flatland
{
    public class TickMessage : Message
    {
        public int TimeSinceLastTick { get; set; }
    }
}
