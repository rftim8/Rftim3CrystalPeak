namespace Rftim3LeetCode.Temp
{
    public class _01154_DayOfTheYear
    {
        /// <summary>
        /// Given a string date representing a Gregorian calendar date formatted as YYYY-MM-DD, return the day number of the year.
        /// </summary>
        public _01154_DayOfTheYear()
        {
            Console.WriteLine(DayOfYear("2019-01-09"));
            Console.WriteLine(DayOfYear("2019-02-10"));
        }

        private static int DayOfYear(string date)
        {
            return DateTime.Parse(date).DayOfYear;
        }

        private static int DayOfYear0(string date)
        {
            int year = int.Parse(date[..4]);
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));

            int result = 0;

            bool isLeapYear = year % 4 == 0 && year % 100 != 0 || year % 400 == 0;

            int[] daysInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

            for (int i = 0; i < month - 1; i++)
            {
                result += daysInMonth[i];
            }

            result += day;

            if (isLeapYear && month > 2) result++;

            return result;
        }
    }
}
