namespace Rftim3LeetCode.Temp
{
    public class _01481_LeastNumberOfUniqueIntegersAfterKRemovals
    {
        /// <summary>
        /// Given an array of integers arr and an integer k. 
        /// Find the least number of unique integers after removing exactly k elements.
        /// </summary>
        public _01481_LeastNumberOfUniqueIntegersAfterKRemovals()
        {
            Console.WriteLine(LeastNumberOfUniqueIntegersAfterKRemovals0([5, 5, 4], 1));
            Console.WriteLine(LeastNumberOfUniqueIntegersAfterKRemovals0([4, 3, 1, 1, 3, 3, 2], 3));
        }

        public static int LeastNumberOfUniqueIntegersAfterKRemovals0(int[] a0, int a1) => RftLeastNumberOfUniqueIntegersAfterKRemovals0(a0, a1);

        public static int LeastNumberOfUniqueIntegersAfterKRemovals1(int[] a0, int a1) => RftLeastNumberOfUniqueIntegersAfterKRemovals1(a0, a1);

        private static int RftLeastNumberOfUniqueIntegersAfterKRemovals0(int[] arr, int k)
        {
            int n = arr.Length;
            int res = 0;

            Dictionary<int, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (kvp.TryGetValue(arr[i], out int value)) kvp[arr[i]] = ++value;
                else kvp[arr[i]] = 1;
            }

            foreach (KeyValuePair<int, int> item in kvp.OrderBy(o => o.Value))
            {
                if (k - item.Value > -1) k -= item.Value;
                else res++;
            }

            return res;
        }

        private static int RftLeastNumberOfUniqueIntegersAfterKRemovals1(int[] arr, int k)
        {

            Dictionary<int, int> numbers = [];

            for (int i = 0; i < arr.Length; i++)
            {

                numbers.TryAdd(arr[i], 0);
                numbers[arr[i]]++;

            }

            PriorityQueue<int, int> pq = new();

            foreach (KeyValuePair<int, int> item in numbers)
            {
                pq.Enqueue(item.Value, item.Value);
            }

            while (k > 0 && pq.Count > 0)
            {

                int number = pq.Peek();

                if (k >= number)
                {
                    k -= number;
                    pq.Dequeue();
                }
                else k = 0;
            }

            return pq.Count;
        }
    }
}
