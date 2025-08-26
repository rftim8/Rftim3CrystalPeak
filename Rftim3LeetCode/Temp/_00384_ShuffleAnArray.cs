using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00384_ShuffleAnArray
    {
        /// <summary>
        /// Given an integer array nums, design an algorithm to randomly shuffle the array. 
        /// All permutations of the array should be equally likely as a result of the shuffling.
        /// Implement the Solution class:
        /// Solution(int[] nums) Initializes the object with the integer array nums.
        /// int[] reset() Resets the array to its original configuration and returns it.
        /// int[] shuffle() Returns a random shuffling of the array.
        /// </summary>
        public _00384_ShuffleAnArray()
        {
            Solution obj = new([1, 2, 3]);
            int[] param_1 = obj.Shuffle();
            RftTerminal.RftReadResult(param_1);
            int[] param_2 = obj.Reset();
            RftTerminal.RftReadResult(param_2);
            int[] param_3 = obj.Shuffle();
            RftTerminal.RftReadResult(param_3);
        }

        private class Solution
        {
            public int[] nums;
            public int[] nums0;
            private readonly Random random = new();

            public Solution(int[] nums)
            {
                int n = nums.Length;
                this.nums = nums;
                nums0 = new int[n];
                Array.Copy(nums, nums0, n);
            }

            public int[] Reset()
            {
                Array.Copy(nums, nums0, nums.Length);
                return nums;
            }

            public int[] Shuffle()
            {
                List<int> x = [.. nums0];

                for (int i = 0; i < nums0.Length; i++)
                {
                    int index = random.Next(x.Count);
                    nums0[i] = x[index];
                    x.RemoveAt(index);
                }

                return nums0;
            }
        }
    }
}
