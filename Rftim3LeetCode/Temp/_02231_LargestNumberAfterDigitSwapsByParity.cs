namespace Rftim3LeetCode.Temp
{
    public class _02231_LargestNumberAfterDigitSwapsByParity
    {
        /// <summary>
        /// You are given a positive integer num. You may swap any two digits of num that have the same parity (i.e. both odd digits or both even digits).
        /// Return the largest possible value of num after any number of swaps.
        /// </summary>
        public _02231_LargestNumberAfterDigitSwapsByParity()
        {
            Console.WriteLine(LargestInteger(1234));
            Console.WriteLine(LargestInteger(65875));
        }

        private static int LargestInteger(int num)
        {
            string x = num.ToString();
            int n = x.Length;

            int[] r = new int[n];
            for (int i = 0; i < n; i++)
            {
                r[i] = int.Parse(x[i].ToString());
            }

            for (int i = 0; i < n; i++)
            {
                bool even = r[i] % 2 == 0;

                if (even)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (r[j] % 2 == 0)
                        {
                            if (r[i] < r[j]) (r[i], r[j]) = (r[j], r[i]);
                        }
                    }
                }
                else
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (r[j] % 2 != 0)
                        {
                            if (r[i] < r[j]) (r[i], r[j]) = (r[j], r[i]);
                        }
                    }
                }
            }

            string q = "";
            for (int i = 0; i < n; i++)
            {
                q += r[i];
            }

            return int.Parse(q);
        }
    }
}
