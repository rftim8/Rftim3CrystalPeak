namespace Rftim3LeetCode.Temp
{
    public class _02437_NumberOfValidClockTimes
    {
        /// <summary>
        /// You are given a string of length 5 called time, representing the current time on a digital clock in the format "hh:mm". 
        /// The earliest possible time is "00:00" and the latest possible time is "23:59".
        /// In the string time, the digits represented by the ? symbol are unknown, and must be replaced with a digit from 0 to 9.
        /// Return an integer answer, the number of valid clock times that can be created by replacing every ? with a digit from 0 to 9.
        /// </summary>
        public _02437_NumberOfValidClockTimes()
        {
            Console.WriteLine(CountTime("?5:00"));
            Console.WriteLine(CountTime("0?:0?"));
            Console.WriteLine(CountTime("??:??"));
            Console.WriteLine(CountTime("2?:??"));
        }

        private static int CountTime(string time)
        {
            int l = 1;
            int r = 1;

            if (time[0] == '?' && time[1] == '?') l = 24;
            else if (time[0] == '?' && time[1] != '?')
            {
                if (time[1] < '4') l = 3;
                else l = 2;
            }
            else if (time[0] != '?' && time[1] == '?')
            {
                if (time[0] < '2') l = 10;
                else l = 4;
            }

            if (time[4] == '?') r *= 10;
            if (time[3] == '?') r *= 6;

            return l * r;
        }
    }
}
