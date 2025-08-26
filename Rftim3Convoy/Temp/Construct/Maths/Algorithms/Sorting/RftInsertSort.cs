namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftInsertSort
    {
        public RftInsertSort()
        {
            InsertionSort([7, 3, 2, 5, 6, 10, 9, 8, 1]);
        }

        private static void InsertionSort(int[] arr)
        {
            // Mutates elements in arr by inserting out of place elements into appropriate
            // index repeatedly until arr is sorted
            for (int i = 1; i < arr.Length; i++)
            {
                int c = i;
                while (c > 0 && arr[c - 1] > arr[c])
                {
                    // Swap elements that are out of order
                    (arr[c - 1], arr[c]) = (arr[c], arr[c - 1]);
                    c -= 1;
                }
            }

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
