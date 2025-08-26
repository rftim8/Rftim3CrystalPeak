namespace Rftim3LeetCode.Temp
{
    public class _02729_CheckIfTheNumberIsFascinating
    {
        /// <summary>
        /// You are given an integer n that consists of exactly 3 digits.
        /// We call the number n fascinating if, after the following modification, the resulting number contains all the digits from 1 to 9 exactly once and does not contain any 0's:
        /// Concatenate n with the numbers 2 * n and 3 * n.
        /// Return true if n is fascinating, or false otherwise.
        /// Concatenating two numbers means joining them together.
        /// For example, the concatenation of 121 and 371 is 121371.
        /// </summary>
        public _02729_CheckIfTheNumberIsFascinating()
        {
            Console.WriteLine(IsFascinating(192));
            Console.WriteLine(IsFascinating(100));
            Console.WriteLine(IsFascinating(783));
        }

        private static bool IsFascinating(int n)
        {
            int[] x = new int[9];

            for (int i = 1; i < 4; i++)
            {
                string t = (n * i).ToString();
                for (int j = 0; j < t.Length; j++)
                {
                    if (t[j] != '0')
                    {
                        x[t[j] - 49]++;
                        if (x[t[j] - 49] == 2) return false;
                    }
                }
            }

            return !x.Any(o => o == 0);
        }
    }
}
