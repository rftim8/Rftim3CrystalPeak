namespace Rftim3LeetCode.Temp
{
    public class _01335_MinimumDifficultyOfAJobSchedule
    {
        /// <summary>
        /// You want to schedule a list of jobs in d days. 
        /// Jobs are dependent (i.e To work on the ith job, you have to finish all the jobs j where 0 <= j < i).
        /// 
        /// You have to finish at least one task every day.
        /// The difficulty of a job schedule is the sum of difficulties of each day of the d days.
        /// The difficulty of a day is the maximum difficulty of a job done on that day.
        /// 
        /// You are given an integer array jobDifficulty and an integer d.
        /// The difficulty of the ith job is jobDifficulty[i].
        /// 
        /// Return the minimum difficulty of a job schedule. 
        /// If you cannot find a schedule for the jobs return -1.
        /// </summary>
        public _01335_MinimumDifficultyOfAJobSchedule()
        {
            Console.WriteLine(MinDifficulty0([6, 5, 4, 3, 2, 1], 2));
            Console.WriteLine(MinDifficulty0([9, 9, 9], 4));
            Console.WriteLine(MinDifficulty0([1, 1, 1], 3));
        }

        public static int MinDifficulty0(int[] a0, int a1) => RftMinDifficulty0(a0, a1);

        public static int MinDifficulty1(int[] a0, int a1) => RftMinDifficulty1(a0, a1);

        public static int MinDifficulty2(int[] a0, int a1) => RftMinDifficulty2(a0, a1);

        // DP
        private static int RftMinDifficulty0(int[] jobDifficulty, int d)
        {
            int[,] dp = new int[d + 1, jobDifficulty.Length + 1];
            for (int i = 0; i <= d; i++)
            {
                for (int j = 0; j < jobDifficulty.Length; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            for (int days = 1; days <= d; days++)
            {
                for (int i = 0; i < jobDifficulty.Length - days + 1; i++)
                {
                    int difficult = 0;
                    for (int j = i + 1; j < jobDifficulty.Length - days + 2; j++)
                    {
                        difficult = Math.Max(difficult, jobDifficulty[j - 1]);
                        if (dp[days - 1, j] != int.MaxValue)
                        {
                            int current = difficult + dp[days - 1, j];
                            dp[days, i] = Math.Min(dp[days, i], current);
                        }
                    }
                }
            }

            return dp[d, 0] < int.MaxValue ? dp[d, 0] : -1;
        }

        private static int RftMinDifficulty1(int[] jobDifficulty, int d)
        {
            int n = jobDifficulty.Length;
            int[][] dp = new int[n][];

            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[d + 1];
            }

            dp[n - 1][1] = jobDifficulty[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                dp[i][1] = Math.Max(dp[i + 1][1], jobDifficulty[i]);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 2; j <= d; j++)
                {
                    int maxJobSeen = 0;
                    int min = int.MaxValue;
                    for (int k = 1; k <= 1 + n - j - i; k++)
                    {
                        maxJobSeen = Math.Max(maxJobSeen, jobDifficulty[i + k - 1]);
                        min = Math.Min(min, dp[i + k][j - 1] + maxJobSeen);
                    }
                    dp[i][j] = min;
                }
            }

            int result = dp[0][d];

            if (result == int.MaxValue) return -1;

            return result;
        }

        // Recursive
        private static int RftMinDifficulty2(int[] jobDifficulty, int d)
        {
            return Helper(jobDifficulty, d, 0);
        }

        private static int Helper(int[] arr, int d, int left)
        {
            Dictionary<(int, int), int> memo = [];

            if (memo.ContainsKey((left, d))) return memo[(left, d)];
            int len = arr.Length;

            int res;
            if (left == len - 1) res = d == 1 ? arr[left] : -1;
            else if (d > len - left) res = -1;
            else if (d == 1)
            {
                res = arr[left];
                for (int i = left + 1; i < len; i++)
                {
                    if (arr[i] > res) res = arr[i];
                }
            }
            else
            {
                int max_left = arr[left];
                int min = int.MaxValue;
                for (int i = left; i < len - 1; i++)
                {
                    if (arr[i] > max_left) max_left = arr[i];

                    int temp = Helper(arr, d - 1, i + 1);

                    if (temp != -1) min = Math.Min(min, max_left + temp);
                }
                res = min == int.MaxValue ? -1 : min;
            }

            memo.Add((left, d), res);

            return res;
        }
    }
}
