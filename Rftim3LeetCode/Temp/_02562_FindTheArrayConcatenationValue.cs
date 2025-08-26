namespace Rftim3LeetCode.Temp
{
    public class _02562_FindTheArrayConcatenationValue
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums.
        /// The concatenation of two numbers is the number formed by concatenating their numerals.
        /// For example, the concatenation of 15, 49 is 1549.
        /// The concatenation value of nums is initially equal to 0. Perform this operation until nums becomes empty:
        /// If there exists more than one number in nums, pick the first element and last element in nums respectively and 
        /// add the value of their concatenation to the concatenation value of nums, then delete the first and last element from nums.
        /// If one element exists, add its value to the concatenation value of nums, then delete it.
        /// Return the concatenation value of the nums.
        /// </summary>
        public _02562_FindTheArrayConcatenationValue()
        {
            Console.WriteLine(FindTheArrayConcVal([7, 52, 2, 4]));
            Console.WriteLine(FindTheArrayConcVal([5, 14, 13, 8, 12]));
        }

        private static long FindTheArrayConcVal(int[] nums)
        {
            int n = nums.Length;

            long c = 0;
            int l = 0, r = n - 1;
            while (l <= r)
            {
                if (l == r) c += nums[l];
                else c += int.Parse($"{nums[l]}{nums[r]}");
                l++;
                r--;
            }

            return c;
        }
    }
}
