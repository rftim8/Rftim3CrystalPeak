using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00167_TwoSum2InputArrayIsSorted
    {
        /// <summary>
        /// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. 
        /// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
        /// Return the indices of the two numbers, index1 and index2, added by one as an integer array[index1, index2] of length 2.
        /// The tests are generated such that there is exactly one solution.You may not use the same element twice.
        /// Your solution must use only constant extra space.
        /// </summary>
        public _00167_TwoSum2InputArrayIsSorted()
        {
            int[] x = TwoSum0([2, 7, 11, 15], 9);
            int[] x0 = TwoSum0([5, 25, 75], 100);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] TwoSum(int[] numbers, int target)
        {
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                int j = i + 1;
                while (j < n && numbers[i] + numbers[j] <= target)
                {
                    if (numbers[i] + numbers[j] == target) return [i + 1, j + 1];
                    j++;
                }
            }

            return numbers;
        }

        private static int[] TwoSum0(int[] numbers, int target)
        {
            int m = 0, n = numbers.Length - 1;

            do
            {
                int sum = numbers[m] + numbers[n];
                if (sum == target) return [m + 1, n + 1];
                else if (sum > target) n--;
                else m++;

            } while (m < n);

            return numbers;
        }
    }
}
