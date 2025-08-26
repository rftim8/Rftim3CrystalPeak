namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Sorting
{
    public class RftHeapSort
    {
        public RftHeapSort()
        {
            HeapSort([7, 3, 2, 5, 6, 10, 9, 8, 1]);
        }

        public static void HeapSort(int[] arr)
        {
            // Mutates elements in lst by utilizing the heap data structure
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, arr.Length, i);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                // swap last element with first element
                (arr[0], arr[i]) = (arr[i], arr[0]);
                // note that we reduce the heap size by 1 every iteration
                MaxHeapify(arr, i, 0);
            }

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void MaxHeapify(int[] arr, int heapSize, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

            if (left < heapSize && arr[left] > arr[largest]) largest = left;
            if (right < heapSize && arr[right] > arr[largest]) largest = right;
            if (largest != index)
            {
                (arr[largest], arr[index]) = (arr[index], arr[largest]);
                MaxHeapify(arr, heapSize, largest);
            }
        }
    }
}
