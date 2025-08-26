using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01470_ShuffleTheArray
    {
        /// <summary>
        /// Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Return the array in the form[x1, y1, x2, y2, ..., xn, yn].
        /// </summary>
        public _01470_ShuffleTheArray()
        {
            int[] x = Shuffle([2, 5, 1, 3, 4, 7], 3);

            RftTerminal.RftReadResult(x);
        }

        private static int[] Shuffle(int[] nums, int n)
        {
            int m = n * 2;
            int[] x = new int[m];
            for (int i = 0; i < n; i++)
            {
                x[i * 2] = nums[i];
                x[i * 2 + 1] = nums[i + n];
            }

            return x;
        }
    }
}
