namespace Rftim3LeetCode.Temp
{
    public class _02269_FindTheKBeautyOfANumber
    {
        /// <summary>
        /// The k-beauty of an integer num is defined as the number of substrings of num when it is read as a string that meet the following conditions:
        /// It has a length of k.
        /// It is a divisor of num.
        /// Given integers num and k, return the k-beauty of num.
        /// Note:
        /// Leading zeros are allowed.
        /// 0 is not a divisor of any value.
        /// A substring is a contiguous sequence of characters in a string.
        /// </summary>
        public _02269_FindTheKBeautyOfANumber()
        {
            Console.WriteLine(DivisorSubstrings(240, 2));
            Console.WriteLine(DivisorSubstrings(430043, 2));
        }

        private static int DivisorSubstrings(int num, int k)
        {
            string r = num.ToString();

            int c = 0, x = 0;
            while (c + k <= r.Length)
            {
                int t = int.Parse(r.Substring(c, k));
                if (t != 0)
                {
                    if (num % t == 0) x++;
                }

                c++;
            }

            return x;
        }
    }
}
