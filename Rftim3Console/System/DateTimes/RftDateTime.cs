namespace Rftim3Console.System.DateTimes
{
    public class RftDateTime
    {
        public RftDateTime()
        {
            RftProperties();
            RftDaysInMonth();
        }

        private static void RftProperties()
        {
            DateTime date = new(1990, 07, 28);
            Console.WriteLine($"Date: {date.Date}");
            Console.WriteLine($"Day: {date.Day}");
            Console.WriteLine($"DayOfWeek: {date.DayOfWeek}");
            Console.WriteLine($"DayOfYear: {date.DayOfYear}");
            Console.WriteLine($"Hour: {date.Hour}");
            Console.WriteLine($"Kind: {date.Kind}");
            Console.WriteLine($"Milliseconds: {date.Millisecond}");
            Console.WriteLine($"Minute: {date.Minute}");
            Console.WriteLine($"Month: {date.Month}");
            Console.WriteLine($"Second: {date.Second}");
            Console.WriteLine($"Ticks: {date.Ticks}");
            Console.WriteLine($"TimeOfDay: {date.TimeOfDay}");
            Console.WriteLine($"Year: {date.Year}");
        }

        private static void RftDaysInMonth()
        {
            Console.WriteLine("Days in month:");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(DateTime.DaysInMonth(DateTime.Now.Year, i + 1));
            }
        }
    }
}
