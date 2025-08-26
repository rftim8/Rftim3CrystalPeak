namespace Rftim3Console.System.TimeSpans
{
    public class RftTimeSpan
    {
        public RftTimeSpan()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            TimeSpan timeSpan = new(1, 11, 11);
            timeSpan = timeSpan.Add(new TimeSpan(1, 11, 11));
            Console.WriteLine($"TimeSpan: {timeSpan}");
        }
    }
}
