using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00912_SortAnArray
    {
        /// <summary>
        /// Given an array of integers nums, sort the array in ascending order and return it.
        /// You must solve the problem without using any built-in functions in O(nlog(n)) 
        /// time complexity and with the smallest space complexity possible.
        /// </summary>
        public _00912_SortAnArray()
        {
            int[] x = SortAnArray0([5, 2, 3, 1]);

            RftTerminal.RftReadResult(x);
        }

        public static int[] SortAnArray0(int[] a0) => RftSortAnArray0(a0);

        private static int[] RftSortAnArray0(int[] nums)
        {
            for (int i = nums.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(nums, nums.Length, i);
            }

            for (int i = nums.Length - 1; i > 0; i--)
            {
                (nums[0], nums[i]) = (nums[i], nums[0]);
                MaxHeapify(nums, i, 0);
            }

            return nums;
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