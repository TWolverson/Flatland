using Messaging;
using System.Windows;

namespace Flatland
{
    internal class UpdatePositionMessage : Message
    {
        public UpdatePositionMessage(Point newPosition)
        {
            this.NewPosition = newPosition;
        }
        public Point NewPosition { get; private set; }
    }
}