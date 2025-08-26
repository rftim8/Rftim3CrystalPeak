namespace Rftim3LeetCode.Temp
{
    public class _01796_SecondLargestDigitInAString
    {
        /// <summary>
        /// Given an alphanumeric string s, return the second largest numerical digit that appears in s, or -1 if it does not exist.
        /// An alphanumeric string is a string consisting of lowercase English letters and digits.
        /// </summary>
        public _01796_SecondLargestDigitInAString()
        {
            Console.WriteLine(SecondHighest("dfa12321afd"));
            Console.WriteLine(SecondHighest("abc1111"));
        }

        private static int SecondHighest(string s)
        {
            List<int> r = [];

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    r.Add(int.Parse(s[i].ToString()));
                }
            }
            r = [.. r.Distinct().OrderByDescending(o => o)];

            if (r.Count < 2) return -1;

            return r[1];
        }

        private static int SecondHighest0(string s)
        {
            int max = -1;
            int second = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s.AsSpan(i, 1), out int number))
                {
                    if (number > max)
                    {
                        second = max;
                        max = number;
                    }
                    else if (number == max) continue;
                    else if (number > second) second = number;
                }
            }

            return second;
        }
    }
}
