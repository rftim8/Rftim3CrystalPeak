namespace Rftim3LeetCode.Temp
{
    public class _00011_ContainerWithMostWater
    {
        /// <summary>
        /// You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        /// Find two lines that together with the x-axis form a container, such that the container contains the most water.
        /// Return the maximum amount of water a container can store.
        /// Notice that you may not slant the container.
        /// </summary>
        public _00011_ContainerWithMostWater()
        {
            Console.WriteLine(ContainerWithMostWater0([1, 8, 6, 2, 5, 4, 8, 3, 7]));
            Console.WriteLine(ContainerWithMostWater0([1, 1]));
        }

        public static int ContainerWithMostWater0(int[] a0) => RftContainerWithMostWater0(a0);

        private static int RftContainerWithMostWater0(int[] height)
        {
            int n = height.Length;

            int c = 0, l = 0, r = n - 1;
            while (l < r)
            {
                int h = Math.Min(height[l], height[r]);
                int w = r - l;
                c = Math.Max(c, h * w);

                if (height[l] < height[r]) l++;
                else r--;
            }

            return c;
        }
    }
}
