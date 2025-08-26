namespace Rftim3LeetCode.Temp
{
    public class _02251_NumberOfFlowersInFullBloom
    {
        private readonly int[][] a =
        [
            [1,6],
            [3,7],
            [9,12],
            [4,13]
        ];
        private readonly int[] a0 = [2, 3, 7, 11];
        private readonly int[][] b =
        [
                [1,10],
                [3,3]
        ];
        private readonly int[] b0 = [3, 3, 2];

        /// <summary>
        /// You are given a 0-indexed 2D integer array flowers, where flowers[i] = [starti, endi] means the ith flower will be in full bloom from starti to endi (inclusive). 
        /// You are also given a 0-indexed integer array people of size n, where people[i] is the time that the ith person will arrive to see the flowers.
        /// Return an integer array answer of size n, where answer[i] is the number of flowers that are in full bloom when the ith person arrives.
        /// </summary>

        private static int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
            int n = flowers.Length;
            int m = people.Length;
            int[] r = new int[m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (flowers[j][0] <= people[i] && flowers[j][1] >= people[i]) r[i]++;
                }
            }

            return r;
        }

        // Heap / Priority Queue
        private static int[] FullBloomFlowers0(int[][] flowers, int[] people)
        {
            int n = people.Length;
            int[] sortedPeople = new int[n];
            Array.Copy(people, sortedPeople, n);
            Array.Sort(sortedPeople);

            Array.Sort(flowers, (a, b) => { return a[0] - b[0]; });
            Dictionary<int, int> dic = [];
            PriorityQueue<int, int> heap = new();

            int i = 0;
            foreach (int person in sortedPeople)
            {
                while (i < flowers.Length && flowers[i][0] <= person)
                {
                    heap.Enqueue(flowers[i][1], flowers[i][1]);
                    i++;
                }

                while (heap.Count > 0 && heap.Peek() < person)
                {
                    heap.Dequeue();
                }

                if (dic.ContainsKey(person)) dic[person] = heap.Count;
                else dic.Add(person, heap.Count);
            }

            int[] ans = new int[people.Length];
            for (int j = 0; j < people.Length; j++)
            {
                ans[j] = dic[people[j]];
            }

            return ans;
        }

        // Difference Array / BS
        private static int[] FullBloomFlowers1(int[][] flowers, int[] people)
        {
            Dictionary<int, int> difference = new()
            {
                { 0, 0 }
            };

            foreach (int[] flower in flowers)
            {
                int start = flower[0];
                int end = flower[1] + 1;

                difference.Add(start, difference.GetValueOrDefault(start, 0) + 1);
                difference.Add(end, difference.GetValueOrDefault(end, 0) - 1);
            }

            difference = difference.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);

            List<int> positions = [];
            List<int> prefix = [];
            int curr = 0;

            foreach (int key in difference.Keys)
            {
                positions.Add(key);
                curr += difference[key];
                prefix.Add(curr);
            }

            int[] ans = new int[people.Length];
            for (int j = 0; j < people.Length; j++)
            {
                int i = BinarySearch(positions, people[j]) - 1;
                ans[j] = prefix[i];
            }

            return ans;
        }

        private static int BinarySearch(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (target < arr[mid]) right = mid;
                else left = mid + 1;
            }

            return left;
        }

        // BS
        private static int[] FullBloomFlowers2(int[][] flowers, int[] people)
        {
            List<int> starts = [];
            List<int> ends = [];

            foreach (int[] flower in flowers)
            {
                starts.Add(flower[0]);
                ends.Add(flower[1] + 1);
            }

            starts.Sort();
            ends.Sort();
            int[] ans = new int[people.Length];

            for (int index = 0; index < people.Length; index++)
            {
                int person = people[index];
                int i = BinarySearch(starts, person);
                int j = BinarySearch(ends, person);
                ans[index] = i - j;
            }

            return ans;
        }
    }
}
