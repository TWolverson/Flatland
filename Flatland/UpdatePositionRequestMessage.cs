using System.Windows;
using Messaging;

namespace Flatland
{
    internal class UpdatePositionRequestMessage : Message
    {
        private object bot;

        public UpdatePositionRequestMessage(Bot bot, Vector desired, Point currentPosition)
        {
            this.bot = bot;
            this.DesiredDisplacement = desired;
            this.CurrentPosition = currentPosition;
        }

        public object AppliesTo { get; private set; }

        public Vector DesiredDisplacement { get; private set; }
        public Point CurrentPosition { get; private set; }
    }
}