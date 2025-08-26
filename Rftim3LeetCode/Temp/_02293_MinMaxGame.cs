namespace Rftim3LeetCode.Temp
{
    public class _02293_MinMaxGame
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums whose length is a power of 2.
        /// Apply the following algorithm on nums:
        /// Let n be the length of nums.If n == 1, end the process.
        /// Otherwise, create a new 0-indexed integer array newNums of length n / 2.
        /// For every even index i where 0 <= i<n / 2, assign the value of newNums[i] as min(nums[2 * i], nums[2 * i + 1]).
        /// For every odd index i where 0 <= i<n / 2, assign the value of newNums[i] as max(nums[2 * i], nums[2 * i + 1]).
        /// Replace the array nums with newNums.
        /// Repeat the entire process starting from step 1.
        /// Return the last number that remains in nums after applying the algorithm.
        /// </summary>
        public _02293_MinMaxGame()
        {
            Console.WriteLine(MinMaxGame([1, 3, 5, 2, 4, 8, 2, 2]));
            Console.WriteLine(MinMaxGame([3]));
        }

        private static int MinMaxGame(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];

            List<int> l = [.. nums];
            List<int> r = [];

            while (l.Count != 1)
            {
                bool mm = true;
                for (int i = 0; i < l.Count; i += 2)
                {
                    if (mm)
                    {
                        r.Add(Math.Min(l[i], l[i + 1]));
                        mm = false;
                    }
                    else
                    {
                        r.Add(Math.Max(l[i], l[i + 1]));
                        mm = true;
                    }
                }
                l = [.. r];
                r = [];
            }

            return l[0];
        }
    }
}
