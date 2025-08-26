namespace Rftim3LeetCode.Temp
{
    public class _01736_LatestTimeByReplacingHiddenDigits
    {
        /// <summary>
        /// You are given a string time in the form of  hh:mm, where some of the digits in the string are hidden (represented by ?).
        /// The valid times are those inclusively between 00:00 and 23:59.
        /// Return the latest valid time you can get from time by replacing the hidden digits.
        /// </summary>
        public _01736_LatestTimeByReplacingHiddenDigits()
        {
            Console.WriteLine(MaximumTime("2?:?0"));
            Console.WriteLine(MaximumTime("0?:3?"));
            Console.WriteLine(MaximumTime("1?:22"));
        }

        private static string MaximumTime(string time)
        {
            char[] l = time.Split(':')[0].ToCharArray();
            char[] r = time.Split(':')[1].ToCharArray();

            if (l[0] == '?')
            {
                if (l[1] < '4' || l[1] == '?') l[0] = '2';
                else l[0] = '1';
            }

            if (r[0] == '?') r[0] = '5';
            if (r[1] == '?') r[1] = '9';

            if (l[1] == '?')
            {
                if (l[0] is '0' or '1') l[1] = '9';
                else l[1] = '3';
            }

            return $"{string.Concat(l)}:{string.Concat(r)}";
        }
    }
}
