namespace Rftim3LeetCode.Temp
{
    public class _01326_MinimumNumberOfTapsToOpenToWaterAGarden
    {
        /// <summary>
        /// There is a one-dimensional garden on the x-axis. 
        /// The garden starts at the point 0 and ends at the point n. (i.e The length of the garden is n).
        /// There are n + 1 taps located at points[0, 1, ..., n] in the garden.
        /// Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means
        /// the i-th tap can water the area[i - ranges[i], i + ranges[i]] if it was open.
        /// Return the minimum number of taps that should be open to water the whole garden, If the garden cannot be watered return -1.
        /// </summary>
        public _01326_MinimumNumberOfTapsToOpenToWaterAGarden()
        {
            Console.WriteLine(MinimumNumberOfTapsToOpenToWaterAGarden0(5, [3, 4, 1, 1, 0, 0]));
            Console.WriteLine(MinimumNumberOfTapsToOpenToWaterAGarden0(3, [0, 0, 0, 0]));
            Console.WriteLine(MinimumNumberOfTapsToOpenToWaterAGarden0(5, [3, 0, 3, 2]));
        }

        public static int MinimumNumberOfTapsToOpenToWaterAGarden0(int a0, int[] a1) => RftMinimumNumberOfTapsToOpenToWaterAGarden0(a0, a1);

        public static int MinimumNumberOfTapsToOpenToWaterAGarden1(int a0, int[] a1) => RftMinimumNumberOfTapsToOpenToWaterAGarden1(a0, a1);

        public static int MinimumNumberOfTapsToOpenToWaterAGarden2(int a0, int[] a1) => RftMinimumNumberOfTapsToOpenToWaterAGarden2(a0, a1);

        private static int RftMinimumNumberOfTapsToOpenToWaterAGarden0(int n, int[] ranges)
        {
            int INF = (int)1e9;

            int[] dp = new int[n + 1];
            Array.Fill(dp, INF);

            dp[0] = 0;

            for (int i = 0; i <= n; i++)
            {
                int tapStart = Math.Max(0, i - ranges[i]);
                int tapEnd = Math.Min(n, i + ranges[i]);

                for (int j = tapStart; j <= tapEnd; j++)
                {
                    dp[tapEnd] = Math.Min(dp[tapEnd], dp[j] + 1);
                }
            }

            if (dp[n] == INF) return -1;

            return dp[n];
        }

        private static int RftMinimumNumberOfTapsToOpenToWaterAGarden1(int n, int[] ranges)
        {
            int[] maxReach = new int[n + 1];

            for (int i = 0; i < ranges.Length; i++)
            {
                int start = Math.Max(0, i - ranges[i]);
                int end = Math.Min(n, i + ranges[i]);

                maxReach[start] = Math.Max(maxReach[start], end);
            }

            int taps = 0;
            int currEnd = 0;
            int nextEnd = 0;

            for (int i = 0; i <= n; i++)
            {
                if (i > nextEnd) return -1;

                if (i > currEnd)
                {
                    taps++;
                    currEnd = nextEnd;
                }

                nextEnd = Math.Max(nextEnd, maxReach[i]);
            }

            return taps;
        }

        private static int RftMinimumNumberOfTapsToOpenToWaterAGarden2(int n, int[] ranges)
        {
            int min = 0;
            int max = 0;
            int openTapCount = 0;

            while (max < n)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    if (i - ranges[i] <= min && i + ranges[i] > max) max = ranges[i] + i;
                }

                if (min == max) return -1;

                openTapCount++;
                min = max;
            }

            return openTapCount;
        }
    }
}