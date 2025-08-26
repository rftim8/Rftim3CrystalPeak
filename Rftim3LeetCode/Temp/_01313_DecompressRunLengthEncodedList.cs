using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01313_DecompressRunLengthEncodedList
    {
        /// <summary>
        /// We are given a list nums of integers representing a list compressed with run-length encoding.
        /// Consider each adjacent pair of elements[freq, val] = [nums[2 * i], nums[2 * i + 1]](with i >= 0).
        /// For each such pair, there are freq elements with value val concatenated in a sublist.
        /// Concatenate all the sublists from left to right to generate the decompressed list.
        /// Return the decompressed list.
        /// </summary>
        public _01313_DecompressRunLengthEncodedList()
        {
            int[] x = DecompressRLElist([1, 2, 3, 4]);
            int[] x0 = DecompressRLElist([1, 1, 2, 3]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] DecompressRLElist(int[] nums)
        {
            int n = nums.Length;
            List<int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) r.AddRange(Enumerable.Repeat(nums[i + 1], nums[i]));
            }

            return [.. r];
        }
    }
}
