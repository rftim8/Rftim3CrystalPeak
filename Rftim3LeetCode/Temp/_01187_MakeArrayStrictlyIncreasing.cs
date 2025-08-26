namespace Rftim3LeetCode.Temp
{
    public class _01187_MakeArrayStrictlyIncreasing
    {
        /// <summary>
        /// Given two integer arrays arr1 and arr2, return the minimum number of operations (possibly zero) needed to make arr1 strictly increasing.
        /// In one operation, you can choose two indices 0 <= i<arr1.length and 0 <= j<arr2.length and do the assignment arr1[i] = arr2[j].
        /// If there is no way to make arr1 strictly increasing, return -1.
        /// </summary>
        public _01187_MakeArrayStrictlyIncreasing()
        {
            Console.WriteLine(MakeArrayIncreasing([1, 5, 3, 6, 7], [1, 3, 2, 4]));
            Console.WriteLine(MakeArrayIncreasing([1, 5, 3, 6, 7], [4, 3, 1]));
            Console.WriteLine(MakeArrayIncreasing([1, 5, 3, 6, 7], [1, 6, 3, 3]));
        }

        private static int MakeArrayIncreasing(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> dp = [];
            Array.Sort(arr2);
            int n = arr2.Length;
            dp.Add(-1, 0);

            foreach (int j in arr1)
            {
                Dictionary<int, int> newDp = [];
                foreach (int prev in dp.Keys)
                {
                    if (j > prev)
                    {
                        if (!newDp.TryGetValue(j, out int value)) newDp.Add(j, dp[prev]);
                        else newDp[j] = Math.Min(value, dp[prev]);
                    }

                    int idx = BisectRight(arr2, prev);

                    if (idx < n)
                    {
                        if (!newDp.TryGetValue(arr2[idx], out int value)) newDp.Add(arr2[idx], 1 + dp[prev]);
                        else newDp[arr2[idx]] = Math.Min(value, 1 + dp[prev]);
                    }
                }
                dp = newDp;
            }

            int answer = int.MaxValue;
            foreach (int value in dp.Values)
            {
                answer = Math.Min(answer, value);
            }

            return answer == int.MaxValue ? -1 : answer;
        }

        private static int BisectRight(int[] arr, int value)
        {
            int left = 0, right = arr.Length;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] <= value) left = mid + 1;
                else right = mid;
            }

            return left;
        }
    }
}
