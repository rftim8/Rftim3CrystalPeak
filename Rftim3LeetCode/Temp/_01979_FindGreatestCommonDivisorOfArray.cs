namespace Rftim3LeetCode.Temp
{
    public class _01979_FindGreatestCommonDivisorOfArray
    {
        /// <summary>
        /// Given an integer array nums, return the greatest common divisor of the smallest number and largest number in nums.
        /// The greatest common divisor of two numbers is the largest positive integer that evenly divides both numbers.
        /// </summary>
        public _01979_FindGreatestCommonDivisorOfArray()
        {
            Console.WriteLine(FindGCD([2, 5, 6, 9, 10]));
            Console.WriteLine(FindGCD([7, 5, 6, 8, 3]));
            Console.WriteLine(FindGCD([3, 3]));
        }

        private static int FindGCD(int[] nums)
        {
            return GCD(nums.Min(), nums.Max());
        }

        private static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
