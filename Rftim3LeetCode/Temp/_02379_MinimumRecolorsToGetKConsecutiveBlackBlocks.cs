namespace Rftim3LeetCode.Temp
{
    public class _02379_MinimumRecolorsToGetKConsecutiveBlackBlocks
    {
        /// <summary>
        /// You are given a 0-indexed string blocks of length n, where blocks[i] is either 'W' or 'B', representing the color of the ith block. 
        /// The characters 'W' and 'B' denote the colors white and black, respectively.
        /// You are also given an integer k, which is the desired number of consecutive black blocks.
        /// In one operation, you can recolor a white block such that it becomes a black block.
        /// Return the minimum number of operations needed such that there is at least one occurrence of k consecutive black blocks.
        /// </summary>
        public _02379_MinimumRecolorsToGetKConsecutiveBlackBlocks()
        {
            Console.WriteLine(MinimumRecolors("WBBWWBBWBW", 7));
            Console.WriteLine(MinimumRecolors("WBWBBBW", 2));
            Console.WriteLine(MinimumRecolors("BWWWBB", 6));
            Console.WriteLine(MinimumRecolors("WWBBBWBBBBBWWBWWWB", 16));
        }

        private static int MinimumRecolors(string blocks, int k)
        {
            int n = blocks.Length;
            int r = int.MaxValue;
            if (k >= n) return blocks.Count(o => o == 'W');

            for (int i = 0; i <= n - k; i++)
            {
                Console.WriteLine(blocks[i..(i + k)]);
                r = Math.Min(r, blocks[i..(i + k)].Count(o => o == 'W'));
            }

            return r;
        }
    }
}
