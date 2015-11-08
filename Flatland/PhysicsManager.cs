using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Flatland
{
    class PhysicsManager : IHandle<UpdatePositionRequestMessage>, IHandle<UpdateHeadingRequestMessage>
    {
        private IBus bus;
        public PhysicsManager(IBus bus)
        {
            this.bus = bus;
            bus.Subscribe<UpdateHeadingRequestMessage>(this);
            bus.Subscribe<UpdatePositionRequestMessage>(this);
        }

        public void Handle(UpdateHeadingRequestMessage message)
        {
            var matrix = Matrix.Identity;

            var angle = Vector.AngleBetween(message.DesiredHeading, message.CurrentHeading);// * 360 / (Math.PI*2);

            if (Math.Sign(angle) != message.Sense)
            {
                angle = -angle;
            }

            angle = Math.Sign(angle) * Math.Min(Math.Abs(angle), 20);
            Console.WriteLine("new heading: " + angle);
            matrix.Rotate(angle);

            var newHeading = message.CurrentHeading * matrix;

            bus.Publish(new UpdateHeadingMessage(newHeading, Math.Sign(angle)));
        }

        public void Handle(UpdatePositionRequestMessage message)
        {
            var newPosition = message.CurrentPosition + message.DesiredDisplacement;
            Console.WriteLine("new position: " + newPosition);
            bus.Publish(new UpdatePositionMessage(newPosition));
        }
    }
}
