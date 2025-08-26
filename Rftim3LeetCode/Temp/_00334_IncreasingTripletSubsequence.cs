namespace Rftim3LeetCode.Temp
{
    public class _00334_IncreasingTripletSubsequence
    {
        /// <summary>
        /// Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. 
        /// If no such indices exists, return false.
        /// </summary>
        public _00334_IncreasingTripletSubsequence()
        {
            Console.WriteLine(IncreasingTriplet(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(IncreasingTriplet(new int[] { 5, 4, 3, 2, 1 }));
            Console.WriteLine(IncreasingTriplet(new int[] { 2, 1, 5, 0, 4, 6 }));
            Console.WriteLine(IncreasingTriplet(new int[] { 20, 100, 10, 12, 5, 13 }));
            Console.WriteLine(IncreasingTriplet(new int[] { 1, 2, 1, 3 }));
            Console.WriteLine(IncreasingTriplet(new int[] { 2, 1, 2, 3 }));
        }

        private static bool IncreasingTriplet(int[] nums)
        {
            int n = nums.Length;
            if (n < 3) return false;

            int l = int.MinValue;
            int mid = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (mid != int.MinValue && nums[i] > nums[mid]) return true;
                if (l == int.MinValue || nums[i] < nums[l]) l = i;
                if (nums[i] > nums[l]) mid = i;
            }

            return false;
        }

        private static bool IncreasingTriplet0(int[] nums)
        {
            int l = int.MaxValue;
            int r = int.MaxValue;

            foreach (int item in nums)
            {
                if (item == l || item == r) continue;

                if (item < l) l = item;
                else if (item < r) r = item;
                else return true;
            }

            return false;
        }
    }
}
