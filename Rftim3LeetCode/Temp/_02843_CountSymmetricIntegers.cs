namespace Rftim3LeetCode.Temp
{
    public class _02843_CountSymmetricIntegers
    {
        /// <summary>
        /// You are given two positive integers low and high.
        /// An integer x consisting of 2 * n digits is symmetric if the sum of the first n digits of x is equal to the sum of the last n digits of x.
        /// Numbers with an odd number of digits are never symmetric.
        /// Return the number of symmetric integers in the range [low, high].
        /// </summary>
        public _02843_CountSymmetricIntegers()
        {
            Console.WriteLine(CountSymmetricIntegers(1, 100));
            Console.WriteLine(CountSymmetricIntegers(1200, 1230));
        }

        private static int CountSymmetricIntegers(int low, int high)
        {
            int c = 0;
            for (int i = low; i <= high; i++)
            {
                string s = i.ToString();
                if (s.Length % 2 == 1) continue;

                char[] x = s.ToCharArray();
                int n = x.Length;
                int l = 0;

                for (int j = 0; j < n; j++)
                {
                    if (j < n / 2) l += x[j] - '0';
                    else l -= x[j] - '0';
                }
                if (l == 0) c++;
            }

            return c;
        }
    }
}
