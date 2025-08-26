namespace Rftim3LeetCode.Temp
{
    public class _01909_RemoveOneElementToMakeTheArrayStrictlyIncreasing
    {
        /// <summary>
        /// Given a 0-indexed integer array nums, return true if it can be made strictly increasing after removing exactly one element, or false otherwise. 
        /// If the array is already strictly increasing, return true.
        /// The array nums is strictly increasing if nums[i - 1] < nums[i] for each index(1 <= i<nums.length).
        /// </summary>
        public _01909_RemoveOneElementToMakeTheArrayStrictlyIncreasing()
        {
            Console.WriteLine(RemoveOneElementToMakeTheArrayStrictlyIncreasing0([1, 2, 10, 5, 7]));
            Console.WriteLine(RemoveOneElementToMakeTheArrayStrictlyIncreasing0([2, 3, 1, 2]));
            Console.WriteLine(RemoveOneElementToMakeTheArrayStrictlyIncreasing0([1, 1, 1]));
            Console.WriteLine(RemoveOneElementToMakeTheArrayStrictlyIncreasing0([105, 924, 32, 968]));
            Console.WriteLine(RemoveOneElementToMakeTheArrayStrictlyIncreasing0([1, 1]));
            Console.WriteLine(RemoveOneElementToMakeTheArrayStrictlyIncreasing0([23, 297, 427, 949, 945]));
        }

        public static bool RemoveOneElementToMakeTheArrayStrictlyIncreasing0(int[] a0) => RftRemoveOneElementToMakeTheArrayStrictlyIncreasing0(a0);

        public static bool RemoveOneElementToMakeTheArrayStrictlyIncreasing1(int[] a0) => RftRemoveOneElementToMakeTheArrayStrictlyIncreasing1(a0);

        private static bool RftRemoveOneElementToMakeTheArrayStrictlyIncreasing0(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                List<int> r = [.. nums];
                r.RemoveAt(i);
                int c = 1;
                for (int j = 0; j < r.Count - 1; j++)
                {
                    if (r[j] >= r[j + 1]) break;
                    c++;
                }
                if (c == r.Count) return true;
            }

            return false;
        }

        private static bool RftRemoveOneElementToMakeTheArrayStrictlyIncreasing1(int[] nums)
        {
            int dropsCnt = 0;
            bool prevDrop = false;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= nums[i - 1])
                {
                    if (++dropsCnt > 1) return false;
                    if (i > 1 && nums[i - 2] >= nums[i]) prevDrop = true;
                }
                else if (prevDrop && nums[i] <= nums[i - 2]) return false;
            }

            return true;
        }
    }
}