namespace Rftim3LeetCode.Temp
{
    public class _01646_GetMaximumInGeneratedArray
    {
        /// <summary>
        /// You are given an integer n. A 0-indexed integer array nums of length n + 1 is generated in the following way:
        /// nums[0] = 0
        /// nums[1] = 1
        /// nums[2 * i] = nums[i] when 2 <= 2 * i <= n
        /// nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        /// Return the maximum integer in the array nums​​​.
        /// </summary>
        public _01646_GetMaximumInGeneratedArray()
        {
            Console.WriteLine(GetMaximumInGeneratedArray0(7));
            Console.WriteLine(GetMaximumInGeneratedArray0(2));
            Console.WriteLine(GetMaximumInGeneratedArray0(3));
            Console.WriteLine(GetMaximumInGeneratedArray0(1));
        }

        public static int GetMaximumInGeneratedArray0(int a0) => RftGetMaximumInGeneratedArray0(a0);

        public static int GetMaximumInGeneratedArray1(int a0) => RftGetMaximumInGeneratedArray1(a0);

        private static int RftGetMaximumInGeneratedArray0(int n)
        {
            if (n == 0) return 0;
            int[] r = new int[n + 1];
            r[0] = 0;
            r[1] = 1;
            int j = 1, k = 1;
            for (int i = 2; i < n + 1; i++)
            {
                if (i % 2 == 0)
                {
                    r[i] = r[j];
                    j++;
                }
                else
                {
                    r[i] = r[k] + r[k + 1];
                    k++;
                }
            }

            return r.Max();
        }

        private static int RftGetMaximumInGeneratedArray1(int n)
        {
            if (n == 0) return 0;

            Dictionary<int, int> a = new() { { 0, 0 }, { 1, 1 } };
            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0) a.Add(i, a[i / 2]);
                else a.Add(i, a[i / 2] + a[i / 2 + 1]);
            }

            return a.Values.Max();
        }
    }
}