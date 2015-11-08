using System;
using Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Threading;

namespace Flatland
{
    internal class Bot : IHandle<TickMessage>, IHandle<UpdatePositionMessage>, IHandle<UpdateHeadingMessage>
    {
        private IBus bus;
        private Waypoint currentWaypoint;

        public Bot(IBus bus, Point startingPosition)
        {
            this.bus = bus;
            Position = startingPosition;
            Thrust = 5;
            Heading = new Vector(1, 0);
            this.bus.Subscribe<TickMessage>(this);
            this.bus.Subscribe<UpdatePositionMessage>(this);
            this.bus.Subscribe<UpdateHeadingMessage>(this);
        }

        private readonly Queue<Waypoint> waypointQueue = new Queue<Waypoint>();
        public void AddWaypoint(Waypoint waypoint)
        {
            waypointQueue.Enqueue(waypoint);
        }

        public Point Position { get; private set; }

        public Vector Heading { get; private set; }
        public double Thrust { get; private set; }
        public int Sense { get; private set; }

        public void Handle(TickMessage message)
        {
            if (currentWaypoint == null)
            {
                if (waypointQueue.Count > 0)
                {
                    currentWaypoint = waypointQueue
                        .Peek();
                }
                else
                {
                    return;
                }
            }
            Thread.Sleep(0);
            bus.Publish(new UpdatePositionRequestMessage(this, this.Thrust * this.Heading, this.Position));
            Thread.Sleep(0);
            bus.Publish(new UpdateHeadingRequestMessage(this, this.Heading, currentWaypoint.Position - this.Position, this.Sense));
      
            bus.Publish(new RenderMessage()
            {
                DrawAction = canvas =>
                {
                    var poly = canvas.Children.OfType<Shape>().SingleOrDefault(c => c.Name == "poly");
                    //if (poly == null)
                    //{
                    //    poly = new Ellipse();
                    //    poly.Name = "poly";
                    //    poly.Height = 10;
                    //    poly.Width = 10;
                    //    poly.Fill = Brushes.Aquamarine;

                    //    canvas.Children.Add(poly);
                    //}
                    // var transform =new RotateTransform(Math.Acos(Heading.Y / Heading.Length), Position.X, Position.Y);
                    var transform = (poly.RenderTransform as RotateTransform);
                    transform.Angle = Math.Atan2(Heading.Y, Heading.X) * (360 / (2 * Math.PI)) - 90;
                    //transform.CenterX = Position.X;
                    //transform.CenterY = Position.Y;
                    //poly.RenderTransformOrigin = Position;
                    Canvas.SetLeft(poly, this.Position.X);
                    Canvas.SetTop(poly, this.Position.Y);
                }
            });
        }
        public void Handle(UpdatePositionMessage message)
        {
            this.Position = message.NewPosition;
            
            if (currentWaypoint != null)
            {
                if ((currentWaypoint.Position - this.Position).Length < 5)
                {
                    waypointQueue.Enqueue(waypointQueue.Dequeue());
                    currentWaypoint = waypointQueue.Peek();
                }
            }
        }

        public void Handle(UpdateHeadingMessage message)
        {
            Heading = message.NewHeading;
            var copy = Heading;
            copy.Normalize();
            Heading = copy;
            Sense = message.Sense;
        }
    }
}