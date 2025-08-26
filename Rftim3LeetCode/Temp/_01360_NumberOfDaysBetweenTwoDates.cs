namespace Rftim3LeetCode.Temp
{
    public class _01360_NumberOfDaysBetweenTwoDates
    {
        /// <summary>
        /// Write a program to count the number of days between two dates.
        /// The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.
        /// </summary>
        public _01360_NumberOfDaysBetweenTwoDates()
        {
            Console.WriteLine(DaysBetweenDates("2019-06-29", "2019-06-30"));
            Console.WriteLine(DaysBetweenDates("2020-01-15", "2019-12-31"));
        }

        private static int DaysBetweenDates(string date1, string date2)
        {
            DateTime l = DateTime.Parse(date1);
            DateTime r = DateTime.Parse(date2);

            return l < r ? (r - l).Days : (l - r).Days;
        }

        private static int DaysBetweenDates0(string date1, string date2)
        {
            DateTime D1 = DateTime.Parse(date1);
            DateTime D2 = DateTime.Parse(date2);

            TimeSpan Res = D1 - D2;

            return Math.Abs(Res.Days);
        }

        private static int DaysBetweenDates1(string date1, string date2)
        {
            DateTime date1Obj = DateTime.ParseExact(date1, "yyyy-MM-dd", null);
            DateTime date2Obj = DateTime.ParseExact(date2, "yyyy-MM-dd", null);

            TimeSpan delta1 = date2Obj - date1Obj;
            TimeSpan delta2 = date1Obj - date2Obj;

            return Math.Min(Math.Abs(delta1.Days), Math.Abs(delta2.Days));
        }

        private static int DaysBetweenDates2(string date1, string date2)
        {
            int[] months = [0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30];
            long d1 = GetDays(date1, months);
            long d2 = GetDays(date2, months);

            return (int)Math.Abs(d1 - d2);
        }

        private static long GetDays(string date, int[] months)
        {
            string[] parts = date.Split("-");
            int year = Convert.ToInt32(parts[0]);
            int month = Convert.ToInt32(parts[1]);
            int day = Convert.ToInt32(parts[2]);
            int total = 0;
            // count years first
            total += (year - 1971) * 365;
            for (int i = 1972; i < year; i += 4)
            {
                if (IsLeapYear(i)) total++;
            }

            months[2] = IsLeapYear(year) ? 29 : 28;
            for (int i = 2; i <= month; i++)
            {
                total += months[i - 1];
            }
            total += day;

            return total;
        }

        private static bool IsLeapYear(int i)
        {
            return i % 4 == 0 && (i % 100 == 0 && i % 400 == 0 || i % 100 != 0);
        }
    }
}
