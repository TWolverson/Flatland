using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flatland
{
    public class Waypoint : IHandle<TickMessage>
    {
        private readonly IBus bus;
        public double centreLeft;
        public double centreTop;

        public Waypoint(IBus bus, double centreLeft, double centreTop)
        {
            this.bus = bus;
            this.centreLeft = centreLeft;
            this.centreTop = centreTop;
            var ellipse = new Ellipse();
            ellipse.Width = 5;
            ellipse.Height = 5;
            ellipse.Fill = Brushes.Red;

            bus.Publish(new RenderMessage()
            {
                DrawAction = canvas =>
                {
                    canvas.Children.Add(ellipse);
                    Canvas.SetLeft(ellipse, centreLeft);
                    Canvas.SetTop(ellipse, centreTop);
                }
            });

        }

        public void Handle(TickMessage message)
        {
        }
    }
}
