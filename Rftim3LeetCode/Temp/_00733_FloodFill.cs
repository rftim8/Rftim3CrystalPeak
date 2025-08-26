using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00733_FloodFill
    {
        /// <summary>
        /// An image is represented by an m x n integer grid image where image[i][j] represents the pixel value of the image.
        /// You are also given three integers sr, sc, and color.You should perform a flood fill on the image starting from the pixel image[sr][sc].
        /// To perform a flood fill, consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, 
        /// plus any pixels connected 4-directionally to those pixels (also with the same color), and so on.Replace the color of all of the aforementioned pixels with color.
        /// Return the modified image after performing the flood fill.
        /// </summary>
        public _00733_FloodFill()
        {
            int[][] x = FloodFill([
                [1, 1, 1],
                [1, 1, 0],
                [1, 0, 1]
            ], 1, 1, 2);

            RftTerminal.RftReadResult<int>(x);
        }
        private static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int old = image[sr][sc];
            Stack<(int y, int x)> st = new();
            st.Push((sr, sc));

            while (st.Count > 0)
            {
                (int y, int x) = st.Pop();

                if (y < 0 || x < 0 || y >= image.Length || x >= image[0].Length) continue;
                if (image[y][x] != old || image[y][x] == color) continue;

                image[y][x] = color;

                st.Push((y - 1, x));
                st.Push((y + 1, x));
                st.Push((y, x - 1));
                st.Push((y, x + 1));
            }

            return image;
        }

        private static int[][] FloodFill0(int[][] image, int sr, int sc, int newColor)
        {
            int color = image[sr][sc];
            if (color != newColor) Dfs(image, sr, sc, color, newColor);
            return image;
        }

        private static void Dfs(int[][] image, int y, int x, int color, int newColor)
        {
            if (image[y][x] == color)
            {
                image[y][x] = newColor;

                if (y >= 1) Dfs(image, y - 1, x, color, newColor);
                if (x >= 1) Dfs(image, y, x - 1, color, newColor);
                if (y + 1 < image.Length) Dfs(image, y + 1, x, color, newColor);
                if (x + 1 < image[0].Length) Dfs(image, y, x + 1, color, newColor);
            }
        }
    }
}
