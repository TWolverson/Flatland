using Messaging;
using System.Timers;

namespace Flatland
{
    internal class TimeManager
    {
        private readonly IBus bus;
        public TimeManager(IBus bus)
        {
            this.bus = bus;
            var timer = new Timer();
            timer.Interval = 20;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            bus.Publish(new TickMessage { TimeSinceLastTick = 20 });
        }
    }
}