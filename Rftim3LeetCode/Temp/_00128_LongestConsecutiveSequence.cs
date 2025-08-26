namespace Rftim3LeetCode.Temp
{
    public class _00128_LongestConsecutiveSequence
    {
        /// <summary>
        /// Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
        /// You must write an algorithm that runs in O(n) time.
        /// </summary>
        public _00128_LongestConsecutiveSequence()
        {
            Console.WriteLine(LongestConsecutive([100, 4, 200, 1, 3, 2]));
            Console.WriteLine(LongestConsecutive([0, 3, 7, 2, 5, 8, 4, 6, 0, 1]));
        }

        private static int LongestConsecutive(int[] nums)
        {
            HashSet<int> h = new(nums);

            int r = 0;
            foreach (int item in nums)
            {
                if (!h.Contains(item - 1))
                {
                    int l = item;
                    int n = 1;
                    while (h.Contains(++l))
                    {
                        n++;
                    }

                    r = Math.Max(r, n);
                }
            }

            return r;
        }
    }
}
