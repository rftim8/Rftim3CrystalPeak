namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftCountingSort
    {
        public RftCountingSort()
        {
            CountingSort([5, 4, 5, 5, 1, 1, 3]);
            //CountingSortShift([5, 4, 5, 5, 1, 1, 3]);
        }

        private static void CountingSort(int[] arr)
        {
            // Sorts an array of integers where minimum value is 0 and maximum value is K
            int n = arr.Length;
            int K = arr.Max();
            int[] counts = new int[K + 1];

            for (int i = 0; i < n; i++)
            {
                counts[arr[i]] += 1;
            }
            // we now overwrite our original counts with the starting index
            // of each element in the final sorted array
            int startingIndex = 0;
            for (int i = 0; i < K + 1; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                sortedArray[counts[arr[i]]] = arr[i];
                // since we have placed an item in index counts[elem], we need to
                // increment counts[elem] index by 1 so the next duplicate element
                // is placed in appropriate index
                counts[arr[i]] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < n; i++)
            {
                arr[i] = sortedArray[i];
                Console.WriteLine(arr[i]);
            }
        }

        private static void CountingSortShift(int[] arr)
        {
            // Sorts an array of integers (handles shifting of integers to range 0 to K)
            int n = arr.Length;
            int shift = arr.Min();
            int K = arr.Max() - shift;
            int[] counts = new int[K + 1];

            for (int i = 0; i < n; i++)
            {
                counts[arr[i] - shift] += 1;
            }
            // we now overwrite our original counts with the starting index
            // of each element in the final sorted array
            int startingIndex = 0;
            for (int i = 0; i < K + 1; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                sortedArray[counts[arr[i] - shift]] = arr[i];
                // since we have placed an item in index counts[elem], we need to
                // increment counts[elem] index by 1 so the next duplicate element
                // is placed in appropriate index
                counts[arr[i] - shift] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < n; i++)
            {
                arr[i] = sortedArray[i];
                Console.WriteLine(arr[i]);
            }
        }
    }
}
