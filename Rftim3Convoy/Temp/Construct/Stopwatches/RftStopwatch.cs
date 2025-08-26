using System.Diagnostics;

namespace Rftim3Convoy.Temp.Construct.Stopwatches
{
    public class RftStopwatch
    {
        private DateTime timestamp;

        public DateTime Timestamp
        {
            get => timestamp;
            set => timestamp = value;
        }

        private Stopwatch timer = new();

        public Stopwatch Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public RftStopwatch()
        {
            Timestamp = DateTime.Now;
            Console.WriteLine($"Process started at: {Timestamp}");
            Timer.Start();
        }

        public void RftStopwatchStop()
        {
            Timer.Stop();
            Console.WriteLine($"Process ended at: {DateTime.Now}\nElapsed: {Timer.ElapsedMilliseconds} ms");
        }
    }
}
