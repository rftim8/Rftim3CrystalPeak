namespace Rftim3LeetCode.Temp
{
    public class _00042_TrappingRainWater
    {
        /// <summary>
        /// Given n non-negative integers representing an elevation map where the width of each bar is 1, 
        /// compute how much water it can trap after raining.
        /// </summary>
        public _00042_TrappingRainWater()
        {
            Console.WriteLine(TrappingRainWater0([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]));
            Console.WriteLine(TrappingRainWater0([4, 2, 0, 3, 2, 5]));
        }

        public static int TrappingRainWater0(int[] a0) => RftTrappingRainWater0(a0);

        private static int RftTrappingRainWater0(int[] height)
        {
            int n = height.Length;
            int x = 0;
            int l = 0, r = n - 1;
            int l0 = 0, r0 = 0;

            while (l < r)
            {
                if (height[l] < height[r])
                {
                    if (height[l] >= l0) l0 = height[l];
                    else x += l0 - height[l];
                    l++;
                }
                else
                {
                    if (height[r] >= r0) r0 = height[r];
                    else x += r0 - height[r];
                    r--;
                }
            }

            return x;
        }

        private static int RftTrappingRainWater1(int[] height)
        {
            if (height == null || height.Length < 2) return 0;

            int n = height.Length;
            int[] leftMax = new int[n];
            int[] rightMax = new int[n];

            leftMax[0] = height[0];
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            }

            rightMax[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }

            int totalWater = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int min = Math.Min(leftMax[i], rightMax[i]);
                totalWater += min - height[i];
            }

            return totalWater;
        }
    }
}
