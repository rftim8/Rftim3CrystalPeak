namespace Rftim3LeetCode.Temp
{
    public class _01751_MaximumNumberOfEventsThatCanBeAttended2
    {
        /// <summary>
        /// You are given an array of events where events[i] = [startDayi, endDayi, valuei]. 
        /// The ith event starts at startDayi and ends at endDayi, and if you attend this event, you will receive a value of valuei. 
        /// You are also given an integer k which represents the maximum number of events you can attend.
        /// You can only attend one event at a time.
        /// If you choose to attend an event, you must attend the entire event. 
        /// Note that the end day is inclusive: that is, you cannot attend two events where one of them starts and the other ends on the same day.
        /// Return the maximum sum of values that you can receive by attending events.
        /// </summary>
        public _01751_MaximumNumberOfEventsThatCanBeAttended2()
        {
            Console.WriteLine(MaxValue(
            [
                [1,2,4],
                [3,4,3],
                [2,3,1]
            ],
            2
            ));

            Console.WriteLine(MaxValue(
            [
                [1,2,4],
                [3,4,3],
                [2,3,10]
            ],
            2
            ));

            Console.WriteLine(MaxValue(
            [
                [1,1,1],
                [2,2,2],
                [3,3,3],
                [4,4,4]
            ],
            3
            ));

            Console.WriteLine(MaxValue(
            [
                [1,3,4],
                [2,4,1],
                [1,1,4],
                [3,5,1],
                [2,5,5]
            ],
            3
            ));

            Console.WriteLine(MaxValue(
            [
                [31,57,53],
                [5,63,29],
                [54,57,32],
                [55,83,28],
                [25,64,5],
                [5,33,33],
                [32,68,27],
                [30,99,54]
            ],
            4
            ));
        }

        private static int[][]? dp;
        private static int[]? nextIndices;

        // Top-down DP + BS
        private static int MaxValue0(int[][] events, int k)
        {
            Array.Sort(events, (a, b) => a[0] - b[0]);
            int n = events.Length;

            dp = new int[k + 1][];

            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], -1);
            }

            return Dfs0(0, k, events);
        }

        private static int Dfs0(int curIndex, int count, int[][] events)
        {
            if (count == 0 || curIndex == events.Length) return 0;

            if (dp![count][curIndex] != -1) return dp[count][curIndex];

            int nextIndex = BisectRight0(events, events[curIndex][1]);
            dp[count][curIndex] = Math.Max(Dfs0(curIndex + 1, count, events), events[curIndex][2] + Dfs0(nextIndex, count - 1, events));
            return dp[count][curIndex];
        }

        private static int BisectRight0(int[][] events, int target)
        {
            int left = 0, right = events.Length;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (events[mid][0] <= target) left = mid + 1;
                else right = mid;
            }

            return left;
        }

        // Bottom-Up DP + BS
        private static int MaxValue1(int[][] events, int k)
        {
            int n = events.Length;
            int[][] dp = new int[k + 1][];

            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[n + 1];
            }

            Array.Sort(events, (a, b) => a[0] - b[0]);

            for (int curIndex = n - 1; curIndex >= 0; --curIndex)
            {
                for (int count = 1; count <= k; count++)
                {
                    int nextIndex = BisectRight1(events, events[curIndex][1]);
                    dp[count][curIndex] = Math.Max(dp[count][curIndex + 1], events[curIndex][2] + dp[count - 1][nextIndex]);
                }
            }

            return dp[k][0];
        }

        private static int BisectRight1(int[][] events, int target)
        {
            int left = 0, right = events.Length;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (events[mid][0] <= target) left = mid + 1;
                else right = mid;
            }

            return left;
        }

        // Top-down DP + Cached Binary Search
        private static int MaxValue2(int[][] events, int k)
        {
            Array.Sort(events, (a, b) => a[0] - b[0]);
            int n = events.Length;
            nextIndices = new int[n];
            for (int curIndex = 0; curIndex < n; ++curIndex)
            {
                nextIndices[curIndex] = BisectRight2(events, events[curIndex][1]);
            }

            dp = new int[k + 1][];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], -1);
            }

            return Dfs2(0, k, events);
        }

        private static int Dfs2(int curIndex, int count, int[][] events)
        {
            if (count == 0 || curIndex == events.Length) return 0;

            if (dp![count][curIndex] != -1) return dp[count][curIndex];

            int nextIndex = nextIndices![curIndex];
            dp[count][curIndex] = Math.Max(Dfs2(curIndex + 1, count, events), events[curIndex][2] + Dfs2(nextIndex, count - 1, events));

            return dp[count][curIndex];
        }

        private static int BisectRight2(int[][] events, int target)
        {
            int left = 0, right = events.Length;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (events[mid][0] <= target) left = mid + 1;
                else right = mid;
            }

            return left;
        }

        // Bottom-up DP + Optimized BS
        private static int BisectRight3(int[][] events, int target)
        {
            int left = 0, right = events.Length;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (events[mid][0] <= target) left = mid + 1;
                else right = mid;
            }

            return left;
        }

        private static int MaxValue3(int[][] events, int k)
        {
            int n = events.Length;
            int[][] dp = new int[k + 1][];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[n + 1];
            }

            Array.Sort(events, (a, b) => a[0] - b[0]);

            for (int curIndex = n - 1; curIndex >= 0; --curIndex)
            {
                int nextIndex = BisectRight3(events, events[curIndex][1]);
                for (int count = 1; count <= k; count++)
                {
                    dp[count][curIndex] = Math.Max(dp[count][curIndex + 1], events[curIndex][2] + dp[count - 1][nextIndex]);
                }
            }

            return dp[k][0];
        }

        // Top-down DP without BS
        private static int MaxValue(int[][] events, int k)
        {
            Array.Sort(events, (a, b) => a[0] - b[0]);
            int n = events.Length;
            dp = new int[k + 1][];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i] = new int[n];
                Array.Fill(dp[i], -1);
            }

            return Dfs(0, 0, -1, events, k);
        }

        private static int Dfs(int curIndex, int count, int prevEndingTime, int[][] events, int k)
        {
            if (curIndex == events.Length || count == k) return 0;

            if (prevEndingTime >= events[curIndex][0]) return Dfs(curIndex + 1, count, prevEndingTime, events, k);

            if (dp![count][curIndex] != -1) return dp[count][curIndex];

            int ans = Math.Max(Dfs(curIndex + 1, count, prevEndingTime, events, k), Dfs(curIndex + 1, count + 1, events[curIndex][1], events, k) + events[curIndex][2]);
            dp[count][curIndex] = ans;

            return ans;
        }
    }
}
