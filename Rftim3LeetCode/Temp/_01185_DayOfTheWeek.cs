namespace Rftim3LeetCode.Temp
{
    public class _01185_DayOfTheWeek
    {
        /// <summary>
        /// Given a date, return the corresponding day of the week for that date.
        /// The input is given as three integers representing the day, month and year respectively.
        /// Return the answer as one of the following values { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}.
        /// </summary>
        public _01185_DayOfTheWeek()
        {
            Console.WriteLine(DayOfTheWeek(31, 8, 2019));
            Console.WriteLine(DayOfTheWeek(18, 7, 1999));
            Console.WriteLine(DayOfTheWeek(15, 8, 1993));
        }

        private static string DayOfTheWeek(int day, int month, int year)
        {
            return DateTime.Parse($"{year}-{month}-{day}").DayOfWeek.ToString();
        }
    }
}
