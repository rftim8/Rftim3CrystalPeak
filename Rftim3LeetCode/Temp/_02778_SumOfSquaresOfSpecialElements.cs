namespace Rftim3LeetCode.Temp
{
    public class _02778_SumOfSquaresOfSpecialElements
    {
        /// <summary>
        /// You are given a 1-indexed integer array nums of length n.
        /// An element nums[i] of nums is called special if i divides n, i.e.n % i == 0.
        /// Return the sum of the squares of all special elements of nums.
        /// </summary>
        public _02778_SumOfSquaresOfSpecialElements()
        {
            Console.WriteLine(SumOfSquares([1, 2, 3, 4]));
            Console.WriteLine(SumOfSquares([2, 7, 1, 19, 18, 3]));
        }

        private static int SumOfSquares(int[] nums)
        {
            int n = nums.Length;
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) c += nums[i - 1] * nums[i - 1];
            }

            return c;
        }
    }
}
