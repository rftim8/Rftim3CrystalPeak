namespace Rftim3LeetCode.Temp
{
    public class _00796_RotateString
    {
        /// <summary>
        /// Given two strings s and goal, return true if and only if s can become goal after some number of shifts on s.
        /// A shift on s consists of moving the leftmost character of s to the rightmost position.
        /// For example, if s = "abcde", then it will be "bcdea" after one shift.
        /// </summary>
        public _00796_RotateString()
        {
            Console.WriteLine(RotateString("abcde", "cdeab"));
            Console.WriteLine(RotateString("abcde", "abced"));
        }

        private static bool RotateString(string s, string goal)
        {
            int n = s.Length;
            int m = goal.Length;

            if (n != m) return false;

            List<char> x = [.. s];

            for (int i = 0; i < n; i++)
            {
                x.Add(x[0]);
                x.RemoveAt(0);

                if (string.Concat(x) == goal) return true;
            }

            return false;
        }

        private static bool RotateString0(string s, string goal)
        {
            if (s == goal) return true;
            if (s.Length != goal.Length) return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == goal[^1])
                {
                    if (string.Concat(s.AsSpan(i + 1), s.AsSpan(0, i + 1)) == goal) return true;
                }
            }

            return false;
        }
    }
}
