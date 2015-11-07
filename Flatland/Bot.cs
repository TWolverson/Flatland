using System;
using Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Flatland
{
    internal class Bot : IHandle<TickMessage>, IHandle<UpdatePositionMessage>
    {
        private IBus bus;
        private Waypoint currentWaypoint;

        public Bot(IBus bus)
        {
            this.bus = bus;
            this.bus.Subscribe<TickMessage>(this);
            this.bus.Subscribe<UpdatePositionMessage>(this);
        }

        private readonly Queue<Waypoint> waypointQueue = new Queue<Waypoint>();
        public void AddWaypoint(Waypoint waypoint)
        {
            waypointQueue.Enqueue(waypoint);
        }

        private double centreLeft;

        private double centreTop;

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

            bus.Publish(new UpdatePositionRequestMessage(this, currentWaypoint.centreLeft, currentWaypoint.centreTop, centreLeft,centreTop));
            bus.Publish(new RenderMessage()
            {
                DrawAction = canvas =>
                {
                    var poly = canvas.Children.OfType<Shape>().SingleOrDefault(c => c.Name == "poly");
                    if (poly == null)
                    {
                        //poly = new Polygon()
                        //{
                        //    Points = new System.Windows.Media.PointCollection() {
                        //    new System.Windows.Point() { X=centreLeft+ 5 * Math.Cos(0), Y =  centreTop + 5 * Math.Sin(0) } ,
                        //    new System.Windows.Point() { X = centreLeft + 5 * Math.Cos(Math.PI / 3), Y = centreTop + 5 * Math.Sin(Math.PI / 3) },
                        //    new System.Windows.Point() { X = centreLeft + 5 * Math.Cos(2 * Math.PI / 3), Y = centreTop + 5 * Math.Sin(2 * Math.PI / 3) }
                        //    },
                        //    Name = "poly",
                        //    Fill = Brushes.Aquamarine
                        //};

                        poly = new Ellipse();
                        poly.Name = "poly";
                        poly.Height = 10;
                        poly.Width = 10;
                        poly.Fill = Brushes.Aquamarine;

                        canvas.Children.Add(poly);
                    }
                    Canvas.SetLeft(poly, centreLeft);
                    Canvas.SetTop(poly, centreTop);
                }
            });
        }
        public void Handle(UpdatePositionMessage message)
        {
            centreLeft = message.CentreLeft;
            centreTop = message.CentreTop;
            if (currentWaypoint != null)
            {
                if (Math.Sqrt(Math.Pow(centreLeft - currentWaypoint.centreLeft, 2) + Math.Pow(centreTop - currentWaypoint.centreTop, 2)) < 5)
                {
                    waypointQueue.Enqueue(waypointQueue.Dequeue());
                    currentWaypoint = waypointQueue.Peek();
                }
            }
        }
    }
}