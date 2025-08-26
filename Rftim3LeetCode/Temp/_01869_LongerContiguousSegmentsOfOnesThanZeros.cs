namespace Rftim3LeetCode.Temp
{
    public class _01869_LongerContiguousSegmentsOfOnesThanZeros
    {
        /// <summary>
        /// Given a binary string s, return true if the longest contiguous segment of 1's is strictly longer than the longest contiguous segment of 0's in s, or return false otherwise.
        /// For example, in s = "110100010" the longest continuous segment of 1s has length 2, and the longest continuous segment of 0s has length 3.
        /// Note that if there are no 0's, then the longest continuous segment of 0's is considered to have a length 0. 
        /// The same applies if there is no 1's.
        /// </summary>
        public _01869_LongerContiguousSegmentsOfOnesThanZeros()
        {
            Console.WriteLine(CheckZeroOnes("1101"));
            Console.WriteLine(CheckZeroOnes("111000"));
            Console.WriteLine(CheckZeroOnes("110100010"));
        }

        private static bool CheckZeroOnes(string s)
        {
            int n = s.Length;

            int l = 0, r = 0;
            int l0 = 0, r0 = 0;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    l0++;
                    r = Math.Max(r, r0);
                    r0 = 0;
                }
                else
                {
                    r0++;
                    l = Math.Max(l, l0);
                    l0 = 0;
                }
            }
            r = Math.Max(r, r0);
            l = Math.Max(l, l0);

            return l > r;
        }
    }
}
