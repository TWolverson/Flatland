using System.Windows;
using Messaging;

namespace Flatland
{
    internal class UpdateHeadingRequestMessage : Message
    {
        private Bot bot;


        public UpdateHeadingRequestMessage(Bot bot, Vector currentHeading, Vector desiredHeading, int sense)
        {
            this.bot = bot;
            this.CurrentHeading = currentHeading;
            this.DesiredHeading = desiredHeading;
            this.Sense = sense;
            //CurrentHeading.Normalize();
            //DesiredHeading.Normalize();

        }

        public Vector CurrentHeading { get; internal set; }
        public Vector DesiredHeading { get; private set; }
        public int Sense { get; private set; }
    }
}