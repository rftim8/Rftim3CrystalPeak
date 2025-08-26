namespace Rftim3LeetCode.Temp
{
    public class _02455_AverageValueOfEvenNumbersThatAreDivisibleByThree
    {
        /// <summary>
        /// Given an integer array nums of positive integers, return the average value of all even integers that are divisible by 3.
        /// Note that the average of n elements is the sum of the n elements divided by n and rounded down to the nearest integer.
        /// </summary>
        public _02455_AverageValueOfEvenNumbersThatAreDivisibleByThree()
        {
            Console.WriteLine(AverageValueOfEvenNumbersThatAreDivisibleByThree0([1, 3, 6, 10, 12, 15]));
            Console.WriteLine(AverageValueOfEvenNumbersThatAreDivisibleByThree0([1, 2, 4, 7, 10]));
            Console.WriteLine(AverageValueOfEvenNumbersThatAreDivisibleByThree0([4, 4, 9, 10]));
            Console.WriteLine(AverageValueOfEvenNumbersThatAreDivisibleByThree0([9, 3, 8, 4, 2, 5, 3, 8, 6, 1]));
        }

        public static int AverageValueOfEvenNumbersThatAreDivisibleByThree0(int[] a0) => RftAverageValueOfEvenNumbersThatAreDivisibleByThree0(a0);

        private static int RftAverageValueOfEvenNumbersThatAreDivisibleByThree0(int[] nums)
        {
            int n = nums.Length;
            List<int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (nums[i] % 2 == 0) if (nums[i] % 3 == 0) r.Add(nums[i]);
            }

            return r.Count == 0 ? 0 : r.Sum() / r.Count;
        }
    }
}