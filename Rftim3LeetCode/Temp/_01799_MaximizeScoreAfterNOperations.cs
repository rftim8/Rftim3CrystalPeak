namespace Rftim3LeetCode.Temp
{
    public class _01799_MaximizeScoreAfterNOperations
    {
        /// <summary>
        /// You are given nums, an array of positive integers of size 2 * n. You must perform n operations on this array.
        /// In the ith operation(1-indexed), you will:
        /// Choose two elements, x and y.
        ///         Receive a score of i* gcd(x, y).
        /// Remove x and y from nums.
        /// Return the maximum score you can receive after performing n operations.
        /// The function gcd(x, y) is the greatest common divisor of x and y.
        /// </summary>
        public _01799_MaximizeScoreAfterNOperations()
        {
            Console.WriteLine(MaxScore([1, 2]));
            Console.WriteLine(MaxScore([3, 4, 6, 8]));
            Console.WriteLine(MaxScore([1, 2, 3, 4, 5, 6]));
        }

        private static int MaxScore(int[] nums)
        {
            int n = nums.Length;
            int maxStates = 1 << n;
            int finalMask = maxStates - 1;

            int[] dp = new int[maxStates];

            for (int state = finalMask; state >= 0; state--)
            {
                if (state == finalMask)
                {
                    dp[state] = 0;
                    continue;
                }

                int numbersTaken = BitCount(state);
                int pairsFormed = numbersTaken / 2;

                if (numbersTaken % 2 != 0) continue;

                for (int firstIndex = 0; firstIndex < n; firstIndex++)
                {
                    for (int secondIndex = firstIndex + 1; secondIndex < n; secondIndex++)
                    {
                        if ((state >> firstIndex & 1) == 1 || (state >> secondIndex & 1) == 1) continue;

                        int currentScore = (pairsFormed + 1) * GCD(nums[firstIndex], nums[secondIndex]);
                        int stateAfterPickingCurrPair = state | 1 << firstIndex | 1 << secondIndex;
                        int remainingScore = dp[stateAfterPickingCurrPair];

                        dp[state] = Math.Max(dp[state], currentScore + remainingScore);
                    }
                }
            }

            return dp[0];
        }

        private static int BitCount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= n - 1;
            }

            return count;
        }

        private static int GCD(int a, int b)
        {
            if (b == 0) return a;

            return GCD(b, a % b);
        }

        private static int BitCount0(int i)
        {
            i -= (i >>> 1) & 0x55555555;
            i = (i & 0x33333333) + ((i >>> 2) & 0x33333333);
            i = i + (i >>> 4) & 0x0f0f0f0f;
            i += (i >>> 8);
            i += (i >>> 16);

            return i & 0x3f;
        }

        private static int MaxScore0(int[] nums)
        {
            int n = nums.Length;

            Dictionary<int, int> map = [];
            Dictionary<int, int> index = [];

            List<int> list = [];
            for (int mask = 3; mask < 1 << n; mask++)
            {
                for (int i = 0; i < n; i++)
                {
                    if ((mask >> i & 1) > 0) list.Add(nums[i]);
                }

                if (list.Count == 2)
                {
                    map.Add(mask, GCD(list[0], list[1]));
                    index.Add(mask, index.Count);
                }

                list.Clear();
            }

            int m = n / 2;
            Dictionary<int, int> current = [];

            foreach (int mask in map.Keys)
            {
                current.Add(mask, map[mask]);
            }

            int key;
            for (int i = 2; i <= m; i++)
            {
                Dictionary<int, int> next = [];

                foreach (int mask1 in map.Keys)
                {
                    foreach (int mask2 in current.Keys)
                    {
                        if ((mask1 & mask2) == 0)
                        {
                            key = mask1 | mask2;
                            next.TryAdd(key, 0);
                            next[key] = Math.Max(next[key], current[mask2] + i * map[mask1]);
                        }
                    }
                }

                current = next;
            }

            int max = 0;

            foreach (int mask in current.Keys)
            {
                max = Math.Max(max, current[mask]);
            }

            return max;
        }
    }
}
