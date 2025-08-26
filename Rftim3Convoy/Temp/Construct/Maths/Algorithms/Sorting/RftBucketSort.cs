namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftBucketSort
    {
        public RftBucketSort()
        {
            BucketSort([23, 25, 21, 12, 19, 17, 5, 7], 5);
        }

        private static void BucketSort(int[] arr, int K)
        {
            List<List<int>> buckets = [];

            for (int i = 0; i < K; i++)
            {
                buckets.Add([]);
            }

            int shift = arr.Min();
            int maxValue = arr.Max() - shift;
            // place elements into buckets
            double bucketSize = (double)maxValue / K;

            if (bucketSize < 1) bucketSize = 1.0;

            for (int i = 0; i < arr.Length; i++)
            {
                // same as K * arr[i] / max(lst)
                int index = (int)((arr[i] - shift) / bucketSize);
                if (index == K) buckets[K - 1].Add(arr[i]);
                else buckets[index].Add(arr[i]);
            }

            // sort individual buckets
            for (int i = 0; i < buckets.Count; i++)
            {
                buckets[i].Sort();
            }

            // convert sorted buckets into final output
            List<int> sortedList = [];

            for (int i = 0; i < buckets.Count; i++)
            {
                sortedList.AddRange(buckets[i]);
            }

            // perfectly fine to just return sortedList here
            // but common practice is to mutate original array with sorted elements
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedList[i];
            }

            foreach (int item in sortedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
