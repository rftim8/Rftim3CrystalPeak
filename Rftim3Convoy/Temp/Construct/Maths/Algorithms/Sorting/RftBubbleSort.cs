namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftBubbleSort
    {
        public RftBubbleSort()
        {
            BubbleSort([7, 3, 2, 1, 5, 6, 10, 9, 8]);
        }

        private static void BubbleSort(int[] arr)
        {
            // Mutates arr so that it is sorted via swapping adjacent elements until
            // the arr is sorted.
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // Swap adjacent elements
                        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                        swapped = true;
                    }
                }
            }

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
