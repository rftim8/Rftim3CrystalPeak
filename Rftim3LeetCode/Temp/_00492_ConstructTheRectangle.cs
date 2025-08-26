using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00492_ConstructTheRectangle
    {
        /// <summary>
        /// A web developer needs to know how to design a web page's size. 
        /// So, given a specific rectangular web page’s area, your job by now is to design a rectangular web page, whose length L and width W satisfy the following requirements:
        /// The area of the rectangular web page you designed must equal to the given target area.
        /// The width W should not be larger than the length L, which means L >= W.
        /// The difference between length L and width W should be as small as possible.
        /// Return an array[L, W] where L and W are the length and width of the web page you designed in sequence.
        /// </summary>
        public _00492_ConstructTheRectangle()
        {
            int[] x = ConstructRectangle0(4);
            RftTerminal.RftReadResult(x);

            int[] x0 = ConstructRectangle0(37);
            RftTerminal.RftReadResult(x0);

            int[] x1 = ConstructRectangle0(122122);
            RftTerminal.RftReadResult(x1);
        }

        public static int[] ConstructRectangle0(int a0) => RftConstructRectangle0(a0);

        public static int[] ConstructRectangle1(int a0) => RftConstructRectangle1(a0);

        private static int[] RftConstructRectangle0(int area)
        {
            double q = Math.Sqrt(area);
            if (q % 1 == 0) return [(int)q, (int)q];

            for (int i = 1; i <= area; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (i * j > area) break;
                    if (i * j == area) return [i, j];
                }
            }

            return new int[2];
        }

        private static int[] RftConstructRectangle1(int area)
        {
            int width = (int)Math.Sqrt(area);
            while (area % width > 0)
            {
                width--;
            }

            return [area / width, width];
        }
    }
}
