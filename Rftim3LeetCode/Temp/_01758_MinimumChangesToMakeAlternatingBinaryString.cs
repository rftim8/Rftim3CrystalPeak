namespace Rftim3LeetCode.Temp
{
    public class _01758_MinimumChangesToMakeAlternatingBinaryString
    {
        /// <summary>
        /// You are given a string s consisting only of the characters '0' and '1'.
        /// In one operation, you can change any '0' to '1' or vice versa.
        /// The string is called alternating if no two adjacent characters are equal.
        /// For example, the string "010" is alternating, while the string "0100" is not.
        /// Return the minimum number of operations needed to make s alternating.
        /// </summary>
        public _01758_MinimumChangesToMakeAlternatingBinaryString()
        {
            Console.WriteLine(MinOperations("0100"));
            Console.WriteLine(MinOperations("10"));
            Console.WriteLine(MinOperations("1111"));
        }

        private static int MinOperations(string s)
        {
            int n = s.Length;
            if (n == 1) return 0;

            char[] t = s.ToCharArray();

            char[] l = new char[n];
            char[] r = new char[n];

            int l0 = 0, r0 = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    l[i] = '1';
                    r[i] = '0';
                }
                else
                {
                    l[i] = '0';
                    r[i] = '1';
                }

                if (l[i] != t[i]) l0++;
                if (r[i] != t[i]) r0++;
            }

            return Math.Min(l0, r0);
        }

        private static int MinOperations0(string s)
        {
            int expected = 0;
            int operations = 0;

            foreach (char c in s)
            {
                if (expected != c - '0') operations++;

                expected = 1 - expected;
            }

            return Math.Min(operations, s.Length - operations);
        }
    }
}
