namespace Rftim3LeetCode.Temp
{
    public class _02224_MinimumNumberOfOperationsToConvertTime
    {
        /// <summary>
        /// You are given two strings current and correct representing two 24-hour times.
        /// 24-hour times are formatted as "HH:MM", where HH is between 00 and 23, and MM is between 00 and 59. 
        /// The earliest 24-hour time is 00:00, and the latest is 23:59.
        /// In one operation you can increase the time current by 1, 5, 15, or 60 minutes.
        /// You can perform this operation any number of times.
        /// Return the minimum number of operations needed to convert current to correct.
        /// </summary>
        public _02224_MinimumNumberOfOperationsToConvertTime()
        {
            Console.WriteLine(ConvertTime("02:30", "04:35"));
            Console.WriteLine(ConvertTime("11:00", "11:01"));
            Console.WriteLine(ConvertTime("00:00", "23:59"));
        }

        private static int ConvertTime(string current, string correct)
        {
            int diff = DateTime.Parse(correct).Hour * 60 + DateTime.Parse(correct).Minute - (DateTime.Parse(current).Hour * 60 + DateTime.Parse(current).Minute);

            int count = 0;
            while (diff >= 60)
            {
                diff -= 60;
                count++;
            }

            while (diff >= 15)
            {
                diff -= 15;
                count++;
            }

            while (diff >= 5)
            {
                diff -= 5;
                count++;
            }

            return count + diff;
        }

        private static int ConvertTime0(string current, string correct)
        {
            int currentInMinutes = (int)TimeSpan.Parse(current).TotalMinutes;
            int correctInMinutes = (int)TimeSpan.Parse(correct).TotalMinutes;

            int diff = correctInMinutes - currentInMinutes;

            int result = 0;

            int hoursDiff = diff / 60;
            result += hoursDiff;
            diff -= 60 * hoursDiff;

            int min15Diff = diff / 15;
            result += min15Diff;
            diff -= 15 * min15Diff;

            int min5Diff = diff / 5;
            result += min5Diff;
            diff -= 5 * min5Diff;

            result += diff;

            return result;
        }
    }
}
