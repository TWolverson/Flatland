using Messaging;

namespace Flatland
{
    internal class UpdatePositionRequestMessage : Message
    {
        private object bot;
        private double centreLeft;
        private double centreTop;

        public UpdatePositionRequestMessage(object bot, double desiredLeft, double desiredTop, double currentLeft, double currentTop)
        {
            this.Bot = bot;
            this.DesiredLeft = desiredLeft;
            this.DesiredTop = desiredTop;
            this.CurrentLeft = currentLeft;
            this.CurrentTop = currentTop;
        }

        public object Bot
        {
            get
            {
                return bot;
            }

            set
            {
                bot = value;
            }
        }

        public double DesiredLeft
        {
            get
            {
                return centreLeft;
            }

            set
            {
                centreLeft = value;
            }
        }

        public double DesiredTop
        {
            get
            {
                return centreTop;
            }

            set
            {
                centreTop = value;
            }
        }

        public double CurrentLeft { get; internal set; }
        public double CurrentTop { get; internal set; }
    }
}