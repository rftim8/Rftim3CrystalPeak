namespace Rftim3LeetCode.Temp
{
    public class _02864_MaximumOddBinaryNumber
    {
        /// <summary>
        /// You are given a binary string s that contains at least one '1'.
        /// 
        /// You have to rearrange the bits in such a way that the resulting binary number is the maximum odd binary number 
        /// that can be created from this combination.
        /// Return a string representing the maximum odd binary number that can be created from the given combination.
        /// Note that the resulting string can have leading zeros.
        /// </summary>
        public _02864_MaximumOddBinaryNumber()
        {
            Console.WriteLine(MaximumOddBinaryNumber0("010"));
            Console.WriteLine(MaximumOddBinaryNumber0("0101"));
        }

        public static string MaximumOddBinaryNumber0(string a0) => RftMaximumOddBinaryNumber0(a0);

        public static string MaximumOddBinaryNumber1(string a0) => RftMaximumOddBinaryNumber1(a0);

        private static string RftMaximumOddBinaryNumber0(string s)
        {
            int n = s.Length;

            char[] r = [.. Enumerable.Repeat('0', n)];

            bool odd = true;
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    if (odd)
                    {
                        r[^1] = '1';
                        odd = false;
                    }
                    else
                    {
                        r[c] = '1';
                        c++;
                    }
                }
            }

            return string.Concat(r);
        }

        private static string RftMaximumOddBinaryNumber1(string s)
        {
            int cx = s.Count(c => c == '1');
            if (cx == 0) return new string('0', s.Length);

            return $"{new string('1', cx - 1)}{new string('0', s.Length - cx)}{new string('1', 1)}";

        }
    }
}
