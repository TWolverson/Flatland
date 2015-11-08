using Messaging;
using System.Windows;

namespace Flatland
{
    internal class UpdateHeadingMessage : Message
    {
        public Vector NewHeading { get; private set; }
        public int Sense { get; private set; }

        public UpdateHeadingMessage(Vector newHeading, int sense)
        {
            this.NewHeading = newHeading;
            this.Sense = sense;
        }
    }
}