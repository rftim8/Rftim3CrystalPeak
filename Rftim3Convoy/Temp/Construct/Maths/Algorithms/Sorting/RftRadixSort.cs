namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftRadixSort
    {
        private const int NUM_DIGITS = 10;

        // LSD - least significant digit
        public RftRadixSort()
        {
            RadixSort([256, 336, 736, 443, 831, 907]);
        }

        private static void RadixSort(int[] arr)
        {
            int maxElem = arr.Max();

            int placeVal = 1;
            while (maxElem / placeVal > 0)
            {
                CountingSort(arr, placeVal);
                placeVal *= 10;
            }
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void CountingSort(int[] arr, int placeVal)
        {
            int n = arr.Length;
            int K = arr.Max();
            // Sorts an array of integers where minimum value is 0 and maximum value is K
            int[] counts = new int[K];

            for (int i = 0; i < n; i++)
            {
                int current = arr[i] / placeVal;
                counts[current % NUM_DIGITS] += 1;
            }

            // we now overwrite our original counts with the starting index
            // of each digit in our group of digits
            int startingIndex = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                int current = arr[i] / placeVal;
                sortedArray[counts[current % NUM_DIGITS]] = arr[i];
                // since we have placed an item in index mCounts[current % NUM_DIGITS],
                // we need to increment mCounts[current % NUM_DIGITS] index by 1 so the
                // next duplicate digit is placed in appropriate index
                counts[current % NUM_DIGITS] += 1;
            }

            // common practice to copy over sorted list into original arr
            // it's fine to just return the sortedArray at this point as well
            for (int i = 0; i < n; i++)
            {
                arr[i] = sortedArray[i];
            }
        }
    }
}
