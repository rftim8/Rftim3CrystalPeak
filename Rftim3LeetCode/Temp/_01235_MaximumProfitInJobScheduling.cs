namespace Rftim3LeetCode.Temp
{
    public class _01235_MaximumProfitInJobScheduling
    {
        /// <summary>
        /// We have n jobs, where every job is scheduled to be done from startTime[i] to endTime[i], obtaining a profit of profit[i].
        /// 
        /// You're given the startTime, endTime and profit arrays, return the maximum profit you can take such that there are no two jobs 
        /// in the subset with overlapping time range.
        /// 
        /// If you choose a job that ends at time X you will be able to start another job that starts at time X.
        /// </summary>
        public _01235_MaximumProfitInJobScheduling()
        {
            Console.WriteLine(JobScheduling0([1, 2, 3, 3], [3, 4, 5, 6], [50, 10, 40, 70]));
            Console.WriteLine(JobScheduling0([1, 2, 3, 4, 6], [3, 5, 10, 6, 9], [20, 20, 100, 70, 60]));
            Console.WriteLine(JobScheduling0([1, 1, 1], [2, 3, 4], [5, 6, 4]));
        }

        public static int JobScheduling0(int[] a0, int[] a1, int[] a2) => RftJobScheduling0(a0, a1, a2);

        public static int JobScheduling1(int[] a0, int[] a1, int[] a2) => RftJobScheduling1(a0, a1, a2);

        private static int RftJobScheduling0(int[] startTime, int[] endTime, int[] profit)
        {
            List<int[]> intervals = [];
            for (int i = 0; i < startTime.Length; i++)
            {
                intervals.Add([startTime[i], endTime[i], profit[i]]);
            }

            intervals.Sort((x, y) => x[1].CompareTo(y[1]));
            List<int> dpProfit = [0], dpEndTime = [0];

            foreach (int[] interval in intervals)
            {
                int s = interval[0], e = interval[1], p = interval[2];
                int prevIndex = dpEndTime.BinarySearch(s + 1);

                if (prevIndex < 0) prevIndex = ~prevIndex;

                prevIndex--;
                int currProfit = dpProfit[prevIndex] + p, maxProfit = dpProfit[^1];

                if (currProfit > maxProfit)
                {
                    dpProfit.Add(currProfit);
                    dpEndTime.Add(e);
                }
            }

            return dpProfit[^1];
        }

        private static int RftJobScheduling1(int[] startTime, int[] endTime, int[] profit)
        {
            int n = startTime.Length;
            int[][] jobs = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jobs[i] = [startTime[i], endTime[i], profit[i]];
            }

            Array.Sort(jobs, (a, b) => a[1] - b[1]);

            int[] results = new int[n];

            results[0] = jobs[0][2];

            for (int i = 1; i < n; i++)
            {
                int last = FindLastJob(jobs, 0, i - 1, jobs[i][0]);

                if (jobs[last][1] <= jobs[i][0]) results[i] = Math.Max(results[i - 1], jobs[i][2] + results[last]);
                else results[i] = Math.Max(results[i - 1], jobs[i][2]);
            }

            return results[n - 1];
        }

        private static int FindLastJob(int[][] jobs, int start, int end, int target)
        {
            while (start < end)
            {
                int mid = (start + end + 1) / 2;

                if (jobs[mid][1] <= target) start = mid;
                else end = mid - 1;
            }

            return start;
        }
    }
}
