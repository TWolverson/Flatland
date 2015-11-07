using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flatland
{
    public class World
    {
        private readonly IBus bus;
        public World(IBus bus, Canvas canvas)
        {
            this.bus = bus;
            var centreTop = canvas.ActualHeight / 2;
            var centreLeft = canvas.ActualWidth / 2;
            var bot = new Bot(bus);
            for (int i = 1; i <= 6; i++)
            {
                var angle = ((double)i / 6) * Math.PI * 2;
                var waypoint = new Waypoint(bus, centreLeft + 100 * Math.Sin(angle), centreTop + 100 * Math.Cos(angle));
                bot.AddWaypoint(waypoint);
            }
            var manager = new TimeManager(bus);
            var physics = new PhysicsManager(bus);
        }
    }
}
