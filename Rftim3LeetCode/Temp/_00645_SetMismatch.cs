using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00645_SetMismatch
    {
        /// <summary>
        /// You have a set of integers s, which originally contains all the numbers from 1 to n. 
        /// Unfortunately, due to some error, one of the numbers in s got duplicated to another number in the set, which results in repetition of one number and loss of another number.
        /// You are given an integer array nums representing the data status of this set after the error.
        /// Find the number that occurs twice and the number that is missing and return them in the form of an array.
        /// </summary>
        public _00645_SetMismatch()
        {
            int[] x = FindErrorNums([1, 2, 2, 4]);
            int[] x0 = FindErrorNums([1, 1]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] FindErrorNums(int[] nums)
        {
            Array.Sort(nums);
            int dup = -1, missing = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) dup = nums[i];
                else if (nums[i] > nums[i - 1] + 1) missing = nums[i - 1] + 1;
            }

            return [dup, nums[^1] != nums.Length ? nums.Length : missing];
        }
    }
}
