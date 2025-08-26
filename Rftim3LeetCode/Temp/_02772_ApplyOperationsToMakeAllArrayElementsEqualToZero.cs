namespace Rftim3LeetCode.Temp
{
    public class _02772_ApplyOperationsToMakeAllArrayElementsEqualToZero
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and a positive integer k.
        /// You can apply the following operation on the array any number of times:
        /// Choose any subarray of size k from the array and decrease all its elements by 1.
        /// Return true if you can make all the array elements equal to 0, or false otherwise.
        /// A subarray is a contiguous non-empty part of an array.
        /// </summary>
        public _02772_ApplyOperationsToMakeAllArrayElementsEqualToZero()
        {
            Console.WriteLine(CheckArray([2, 2, 3, 1, 1, 0], 3));
            Console.WriteLine(CheckArray([1, 3, 1, 1], 2));
            Console.WriteLine(CheckArray([60, 72, 87, 89, 63, 52, 64, 62, 31, 37, 57, 83, 98, 94, 92, 77, 94, 91, 87, 100, 91, 91, 50, 26], 4));
            Console.WriteLine(CheckArray([0, 45, 82, 98, 99], 4));
            Console.WriteLine(CheckArray([89, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8], 12));
        }

        // 100% memory, 33% runtime
        private static bool CheckArray0(int[] nums, int k)
        {
            if (k == 1) return true;

            int n = nums.Length;

            int i = 0;
            while (i <= n - k)
            {
                int temp = nums[i];
                Console.WriteLine(temp);

                if (temp < 0) return false;

                if (temp != 0)
                {
                    int l = 0;
                    while (l < k)
                    {
                        nums[i + l] -= temp;
                        l++;
                    }
                }
                i++;
            }
            while (i < n)
            {
                if (nums[i] != 0) return false;
                i++;
            }

            return true;
        }

        private static bool CheckArray1(int[] nums, int k)
        {
            if (k == 1) return true;

            int n = nums.Length;

            Queue<int> x = new();
            int c = 0;

            for (int i = 0; i < n; i++)
            {
                int temp = nums[i];

                if (i >= k) c -= x.Dequeue();
                if (temp < c) return false;

                int diff = temp - c;

                if (i > n - k && diff != 0) return false;

                x.Enqueue(diff);
                c += diff;
            }

            return true;
        }

        private static bool CheckArray(int[] nums, int k)
        {
            int n = nums.Length;
            int[] diff = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                if (i >= k) sum -= diff[i - k];

                int change = nums[i] - sum;

                if (change < 0) return false;

                diff[i] = change;
                sum += change;
            }

            for (int i = n - k + 1; i < n; i++)
            {
                sum -= diff[i - 1];

                if (sum != 0) return false;
            }

            return true;
        }
    }
}
