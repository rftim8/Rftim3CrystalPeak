namespace Rftim3LeetCode.Temp
{
    public class _00189_RotateArray
    {
        /// <summary>
        /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
        /// </summary>
        public _00189_RotateArray()
        {
            Rotate(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);
            Rotate(new int[] { -1, -100, 3, 99 }, 2);
            Rotate(new int[] { 1, 2 }, 3);
            Rotate(new int[] { 1, 2, 3 }, 2);
        }

        private static void Rotate(int[] nums, int k)
        {
            int m = nums.Length;
            if (k == m) return;
            if (k > m) k %= m;
            int[] x = new int[m];
            int n = k;

            for (int i = m - 1; i > m - 1 - k; i--)
            {
                if (n - 1 > -1) x[n - 1] = nums[i];
                n--;
            }

            n = k;
            for (int i = 0; i < m - k; i++)
            {
                x[n++] = nums[i];
            }

            Array.Clear(nums);
            Array.Copy(x, nums, m);

            foreach (int item in x)
            {
                Console.WriteLine(item);
            }
        }
    }
}
