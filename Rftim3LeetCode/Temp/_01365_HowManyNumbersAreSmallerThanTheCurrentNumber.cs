using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01365_HowManyNumbersAreSmallerThanTheCurrentNumber
    {
        /// <summary>
        /// Given the array nums, for each nums[i] find out how many numbers in the array are smaller than it. 
        /// That is, for each nums[i] you have to count the number of valid j's such that j != i and nums[j] < nums[i].
        /// Return the answer in an array.
        /// </summary>
        public _01365_HowManyNumbersAreSmallerThanTheCurrentNumber()
        {
            int[] x = HowManyNumbersAreSmallerThanTheCurrentNumber0([8, 1, 2, 2, 3]);
            RftTerminal.RftReadResult(x);

            int[] x0 = HowManyNumbersAreSmallerThanTheCurrentNumber0([6, 5, 4, 8]);
            RftTerminal.RftReadResult(x0);

            int[] x1 = HowManyNumbersAreSmallerThanTheCurrentNumber0([7, 7, 7, 7]);
            RftTerminal.RftReadResult(x1);
        }

        public static int[] HowManyNumbersAreSmallerThanTheCurrentNumber0(int[] a0) => RftHowManyNumbersAreSmallerThanTheCurrentNumber0(a0);

        private static int[] RftHowManyNumbersAreSmallerThanTheCurrentNumber0(int[] nums)
        {
            int n = nums.Length;
            List<int> t = [.. nums];
            t.Sort();

            int[] x = new int[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = t.IndexOf(nums[i]);
            }

            return x;
        }
    }
}