namespace Rftim3LeetCode.Temp
{
    public class _01095_FindInMountainArray
    {
        /// <summary>
        /// (This problem is an interactive problem.)
        /// You may recall that an array arr is a mountain array if and only if:
        /// arr.length >= 3
        /// There exists some i with 0 < i<arr.length - 1 such that:
        /// arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
        /// arr[i]> arr[i + 1] > ... > arr[arr.length - 1]
        /// Given a mountain array mountainArr, return the minimum index such that mountainArr.get(index) == target.
        /// If such an index does not exist, return -1.
        /// You cannot access the mountain array directly.You may only access the array using a MountainArray interface:
        /// MountainArray.get(k) returns the element of the array at index k (0-indexed).
        /// MountainArray.length() returns the length of the array.
        /// Submissions making more than 100 calls to MountainArray.get will be judged Wrong Answer.
        /// Also, any solutions that attempt to circumvent the judge will result in disqualification.
        /// </summary>
        public _01095_FindInMountainArray()
        {
            MountainArray x = new([1, 2, 3, 4, 5, 3, 1]);
            Console.WriteLine(FindInMountainArray(3, x));
            MountainArray x0 = new([0, 1, 2, 4, 2, 1]);
            Console.WriteLine(FindInMountainArray(3, x0));
        }

        private static int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int length = mountainArr.Length();

            int low = 1;
            int high = length - 2;
            while (low != high)
            {
                int testIndex = (low + high) / 2;
                if (mountainArr.Get(testIndex) < mountainArr.Get(testIndex + 1)) low = testIndex + 1;
                else high = testIndex;
            }
            int peakIndex = low;

            low = 0;
            high = peakIndex;
            while (low != high)
            {
                int testIndex = (low + high) / 2;
                if (mountainArr.Get(testIndex) < target) low = testIndex + 1;
                else high = testIndex;
            }

            if (mountainArr.Get(low) == target) return low;

            low = peakIndex + 1;
            high = length - 1;
            while (low != high)
            {
                int testIndex = (low + high) / 2;
                if (mountainArr.Get(testIndex) > target) low = testIndex + 1;
                else high = testIndex;
            }

            if (mountainArr.Get(low) == target) return low;

            return -1;
        }

        private class MountainArray(IList<int> x)
        {
            public IList<int> x = x;

            public int Get(int index)
            {
                return x[index];
            }

            public int Length()
            {
                return x.Count;
            }
        }
    }
}
