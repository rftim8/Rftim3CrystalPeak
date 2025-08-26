using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01389_CreateTargetArrayInTheGivenOrder
    {
        /// <summary>
        /// Given two arrays of integers nums and index. 
        /// Your task is to create target array under the following rules:
        /// Initially target array is empty.
        /// From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
        /// Repeat the previous step until there are no elements to read in nums and index.
        /// Return the target array.
        /// It is guaranteed that the insertion operations will be valid.
        /// </summary>
        public _01389_CreateTargetArrayInTheGivenOrder()
        {
            int[] x = CreateTargetArray(
                [0, 1, 2, 3, 4],
                [0, 1, 2, 2, 1]
            );
            int[] x0 = CreateTargetArray(
                [1, 2, 3, 4, 0],
                [0, 1, 2, 3, 0]
            );
            int[] x1 = CreateTargetArray(
                [1],
                [0]
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            List<int> r = [];

            for (int i = 0; i < nums.Length; i++)
            {
                r.Insert(index[i], nums[i]);
            }

            return [.. r];
        }
    }
}
