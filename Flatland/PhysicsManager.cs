using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    class PhysicsManager : IHandle<UpdatePositionRequestMessage>
    {
        private IBus bus;
        public PhysicsManager(IBus bus)
        {
            this.bus = bus;
            bus.Subscribe(this);
        }
        public void Handle(UpdatePositionRequestMessage message)
        {
            //bus.Publish(new UpdatePositionMessage(message.CentreLeft, message.CentreTop));
            bus.Publish(new UpdatePositionMessage(
                message.CurrentLeft + (message.DesiredLeft - message.CurrentLeft) / 50,
                message.CurrentTop + (message.DesiredTop - message.CurrentTop) / 50));

            bus.Publish(new UpdatePositionMessage(
    message.CurrentLeft + Math.Sign(message.DesiredLeft - message.CurrentLeft) * 5,
    message.CurrentTop + Math.Sign(message.DesiredTop - message.CurrentTop) * 5));
        }
    }
}
