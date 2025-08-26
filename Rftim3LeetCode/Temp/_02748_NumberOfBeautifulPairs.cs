namespace Rftim3LeetCode.Temp
{
    public class _02748_NumberOfBeautifulPairs
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. A pair of indices i, j where 0 <= i < j < nums.length 
        /// is called beautiful if the first digit of nums[i] and the last digit of nums[j] are coprime.
        /// Return the total number of beautiful pairs in nums.
        /// Two integers x and y are coprime if there is no integer greater than 1 that divides both of them.
        /// In other words, x and y are coprime if gcd(x, y) == 1, where gcd(x, y) is the greatest common divisor of x and y.
        /// </summary>
        public _02748_NumberOfBeautifulPairs()
        {
            Console.WriteLine(CountBeautifulPairs([2, 5, 1, 4]));
            Console.WriteLine(CountBeautifulPairs([11, 21, 12]));
            Console.WriteLine(CountBeautifulPairs([31, 25, 72, 79, 74]));
        }

        private static int CountBeautifulPairs(int[] nums)
        {
            int n = nums.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int gcd = GCD(nums[i].ToString()[0] - 48, nums[j] % 10);
                    if (gcd == 1) c++;
                }
            }

            return c;
        }

        private static int GCD(int x, int y)
        {
            if (y == 0) return x;

            return GCD(y, x % y);
        }
    }
}
