namespace Rftim3LeetCode.Temp
{
    public class _01207_UniqueNumberOfOccurrences
    {
        /// <summary>
        /// Given an array of integers arr, return true if the number of occurrences of each value in the array is unique or false otherwise.
        /// </summary>
        public _01207_UniqueNumberOfOccurrences()
        {
            Console.WriteLine(UniqueOccurrences([1, 2, 2, 1, 1, 3]));
            Console.WriteLine(UniqueOccurrences([1, 2]));
            Console.WriteLine(UniqueOccurrences([-3, 0, 1, -3, 1, 1, 1, -3, 10, 0]));
        }

        private static bool UniqueOccurrences(int[] arr)
        {
            int n = arr.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(arr[i], out int value)) r[arr[i]] = ++value;
                else r[arr[i]] = 1;
            }

            return r.Select(o => o.Value).Distinct().Count() == r.Count;
        }
    }
}
