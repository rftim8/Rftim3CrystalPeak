namespace Rftim3LeetCode.Temp
{
    public class _01863_SumOfAllSubsetXORTotals
    {
        /// <summary>
        /// The XOR total of an array is defined as the bitwise XOR of all its elements, or 0 if the array is empty.
        /// For example, the XOR total of the array[2, 5, 6] is 2 XOR 5 XOR 6 = 1.
        /// Given an array nums, return the sum of all XOR totals for every subset of nums.
        /// Note: Subsets with the same elements should be counted multiple times.
        /// An array a is a subset of an array b if a can be obtained from b by deleting some (possibly zero) elements of b.
        /// </summary>
        public _01863_SumOfAllSubsetXORTotals()
        {
            Console.WriteLine(SubsetXORSum([1, 3]));
            Console.WriteLine(SubsetXORSum([5, 1, 6]));
            Console.WriteLine(SubsetXORSum([3, 4, 5, 6, 7, 8]));
        }

        private static int SubsetXORSum(int[] nums)
        {
            return XORSubsets(nums, 0, 0);
        }

        private static int XORSubsets(int[] nums, int index, int res)
        {
            if (index == nums.Length) return res;

            return XORSubsets(nums, index + 1, res) + XORSubsets(nums, index + 1, res ^ nums[index]);
        }

        private static int SubsetXORSum2(int[] nums)
        {
            int xorSum = 0;
            Backtracking(nums, ref xorSum, 0, 0);

            return xorSum;
        }

        private static void Backtracking(int[] nums, ref int xorSum, int xor, int index)
        {
            for (int i = index; i < nums.Length; i++)
            {
                xor ^= nums[i];
                xorSum += xor;
                Backtracking(nums, ref xorSum, xor, i + 1);
                xor ^= nums[i];
            }
        }

        private static int SubsetXORSum0(int[] nums)
        {
            int n = nums.Length;
            int answer = 0;

            for (int i = 1; i < 1 << n; i++)
            {
                int xor = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((i & 1 << j) != 0) xor ^= nums[j];
                }
                answer += xor;
            }

            return answer;
        }

        private static int SubsetXORSum1(int[] nums)
        {
            int n = nums.Length;
            int subsets = (int)Math.Pow(2, n);

            int result = 0;
            for (int i = 1; i < subsets; ++i)
            {
                int counter = i;
                int index = 0;
                int temp = 0;
                while (counter > 0)
                {
                    if (counter % 2 == 1)
                    {
                        temp ^= nums[index];
                        counter--;
                    }
                    counter /= 2;
                    ++index;
                }
                result += temp;
            }

            return result;
        }
    }
}
