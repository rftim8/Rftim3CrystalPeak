namespace Rftim3LeetCode.Temp
{
    public class _00852_PeakIndexInAMountainArray
    {
        /// <summary>
        /// An array arr a mountain if the following properties hold:
        /// arr.length >= 3
        /// There exists some i with 0 < i<arr.length - 1 such that:
        /// arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
        /// arr[i]> arr[i + 1] > ... > arr[arr.length - 1]
        /// Given a mountain array arr, return the index i such that arr[0] < arr[1] < ... < arr[i - 1] < arr[i] > arr[i + 1] > ... > arr[arr.length - 1].
        /// You must solve it in O(log(arr.length)) time complexity.
        /// </summary>
        public _00852_PeakIndexInAMountainArray()
        {
            Console.WriteLine(PeakIndexInMountainArray([0, 1, 0]));
            Console.WriteLine(PeakIndexInMountainArray([0, 2, 1, 0]));
            Console.WriteLine(PeakIndexInMountainArray([0, 10, 5, 2]));
        }

        private static int PeakIndexInMountainArray(int[] arr)
        {
            int n = arr.Length;

            int x = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < x) return i - 1;
                x = arr[i];
            }

            return -1;
        }

        private static int PeakIndexInMountainArray0(int[] arr)
        {
            int l = 0;
            int r = arr.Length;
            int mid = (l + r) / 2;
            while (l < r)
            {
                if (arr[mid] < arr[mid + 1]) l = mid + 1;
                else r = mid;
                mid = (l + r) / 2;
            }

            return mid;
        }
    }
}
