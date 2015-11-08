using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Flatland
{
    public class Waypoint : IHandle<TickMessage>
    {
        private readonly IBus bus;

        public Point Position { get; private set; }

        public Waypoint(IBus bus, Point position)
        {
            this.bus = bus;
            this.Position = position;
            var ellipse = new Ellipse();
            ellipse.Width = 5;
            ellipse.Height = 5;
            ellipse.Fill = Brushes.Red;

            bus.Publish(new RenderMessage()
            {
                DrawAction = canvas =>
                {
                    canvas.Children.Add(ellipse);
                    Canvas.SetLeft(ellipse, position.X);
                    Canvas.SetTop(ellipse, position.Y);
                }
            });

        }

        public void Handle(TickMessage message)
        {
        }
    }
}
