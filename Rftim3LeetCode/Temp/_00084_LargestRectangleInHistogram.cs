namespace Rftim3LeetCode.Temp
{
    public class _00084_LargestRectangleInHistogram
    {
        /// <summary>
        /// Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.
        /// </summary>
        public _00084_LargestRectangleInHistogram()
        {
            Console.WriteLine(LargestRectangleArea([2, 1, 5, 6, 2, 3]));
            Console.WriteLine(LargestRectangleArea([2, 4]));
        }

        private static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            int r = 0;
            Stack<int> s = new();

            for (int i = 0; i <= n; i++)
            {
                int c = i == n ? 0 : heights[i];

                while (s.Count > 0 && heights[s.Peek()] > c)
                {
                    int h = heights[s.Pop()];
                    int w = i - 1 - (s.Count == 0 ? -1 : s.Peek());

                    r = Math.Max(r, h * w);
                }

                s.Push(i);
            }

            return r;
        }
    }
}
