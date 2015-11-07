using Messaging;

namespace Flatland
{
    internal class UpdatePositionMessage : Message
    {
        private double centreLeft;
        private double centreTop;

        public UpdatePositionMessage(double centreLeft, double centreTop)
        {
            this.CentreLeft = centreLeft;
            this.CentreTop = centreTop;
        }

        public double CentreLeft
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

        public double CentreTop
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
    }
}