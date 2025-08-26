namespace Rftim3LeetCode.Temp
{
    public class _02220_MinimumBitFlipsToConvertNumber
    {
        /// <summary>
        /// A bit flip of a number x is choosing a bit in the binary representation of x and flipping it from either 0 to 1 or 1 to 0.
        /// For example, for x = 7, the binary representation is 111 and we may choose any bit(including any leading zeros not shown) and flip it.
        /// We can flip the first bit from the right to get 110, flip the second bit from the right to get 101, flip the fifth bit from the right(a leading zero) to get 10111, etc.
        /// Given two integers start and goal, return the minimum number of bit flips to convert start to goal.
        /// </summary>
        public _02220_MinimumBitFlipsToConvertNumber()
        {
            Console.WriteLine(MinBitFlips(10, 7));
            Console.WriteLine(MinBitFlips(3, 4));
        }

        private static int MinBitFlips(int start, int goal)
        {
            string l = string.Concat(Convert.ToString(start, 2).Reverse());
            int l0 = l.Length;
            string r = string.Concat(Convert.ToString(goal, 2).Reverse());
            int r0 = r.Length;

            int c = 0;
            if (l0 < r0)
            {
                for (int i = 0; i < r0; i++)
                {
                    if (i < l0)
                    {
                        if (l[i] != r[i]) c++;
                    }
                    else
                    {
                        if (r[i] != '0') c++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < l0; i++)
                {
                    if (i < r0)
                    {
                        if (l[i] != r[i]) c++;
                    }
                    else
                    {
                        if (l[i] != '0') c++;
                    }
                }
            }

            return c;
        }

        private static int MinBitFlips0(int start, int goal)
        {
            int diff = start ^ goal;
            int count = 0;

            while (diff > 0)
            {
                count++;
                diff &= diff - 1;
            }

            return count;
        }
    }
}
