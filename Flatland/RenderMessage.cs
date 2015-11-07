using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messaging;
using System.Windows.Controls;

namespace Flatland
{
    public class RenderMessage : Message
    {
        public Action<Canvas> DrawAction { get; set; }
    }
}
