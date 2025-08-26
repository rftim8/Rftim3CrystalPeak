namespace Rftim3LeetCode.Temp
{
    public class _02009_MinimumNumberOfOperationsToMakeArrayContinuous
    {
        /// <summary>
        /// You are given an integer array nums. In one operation, you can replace any element in nums with any integer.
        /// nums is considered continuous if both of the following conditions are fulfilled:
        /// All elements in nums are unique.
        /// The difference between the maximum element and the minimum element in nums equals nums.length - 1.
        /// For example, nums = [4, 2, 5, 3] is continuous, but nums = [1, 2, 3, 5, 6] is not continuous.
        /// Return the minimum number of operations to make nums continuous.
        /// </summary>
        public _02009_MinimumNumberOfOperationsToMakeArrayContinuous()
        {
            Console.WriteLine(MinOperations([4, 2, 5, 3]));
            Console.WriteLine(MinOperations([1, 2, 3, 5, 6]));
            Console.WriteLine(MinOperations([1, 10, 100, 1000]));
        }

        // Sliding Window
        private static int MinOperations(int[] nums)
        {
            int n = nums.Length;
            int r = n;

            HashSet<int> hs = [.. nums];

            int[] x = [.. hs];
            int m = x.Length;
            Array.Sort(x);

            int j = 0;
            for (int i = 0; i < m; i++)
            {
                while (j < m && x[j] < x[i] + n)
                {
                    j++;
                }

                int count = j - i;
                r = Math.Min(r, n - count);
            }

            return r;
        }

        // BS
        private static int MinOperations0(int[] nums)
        {
            int n = nums.Length;
            int ans = n;

            HashSet<int> unique = [.. nums];

            int[] newNums = new int[unique.Count];
            int index = 0;

            foreach (int num in unique)
            {
                newNums[index++] = num;
            }

            Array.Sort(newNums);

            for (int i = 0; i < newNums.Length; i++)
            {
                int left = newNums[i];
                int right = left + n - 1;
                int j = BinarySearch(newNums, right);
                int count = j - i;
                ans = Math.Min(ans, n - count);
            }

            return ans;
        }

        private static int BinarySearch(int[] newNums, int target)
        {
            int left = 0;
            int right = newNums.Length;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (target < newNums[mid]) right = mid;
                else left = mid + 1;
            }

            return left;
        }
    }
}
