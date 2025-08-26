using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00661_ImageSmoother
    {
        /// <summary>
        /// An image smoother is a filter of the size 3 x 3 that can be applied to each cell of an image by rounding down the average of the cell 
        /// and the eight surrounding cells (i.e., the average of the nine cells in the blue smoother). 
        /// If one or more of the surrounding cells of a cell is not present, we do not consider it in the average (i.e., the average of the four cells in the red smoother).
        /// Given an m x n integer matrix img representing the grayscale of an image, return the image after applying the smoother on each cell of it.
        /// </summary>
        public _00661_ImageSmoother()
        {
            int[][] x = ImageSmoother(
            [
                [1, 1, 1],
                [1, 0, 1],
                [1, 1, 1]
            ]);

            int[][] x0 = ImageSmoother(
            [
                [100, 200, 100],
                [200, 50, 200],
                [100, 200, 100]
            ]);

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] ImageSmoother(int[][] img)
        {
            int r = img.Length, c = img[0].Length;
            int[][] ans = new int[r][];

            for (int i = 0; i < r; ++i)
            {
                ans[i] = new int[c];
                for (int j = 0; j < c; ++j)
                {
                    int count = 0;
                    for (int nr = i - 1; nr <= i + 1; ++nr)
                    {
                        for (int nc = j - 1; nc <= j + 1; ++nc)
                        {
                            if (0 <= nr && nr < r && 0 <= nc && nc < c)
                            {
                                ans[i][j] += img[nr][nc];
                                count++;
                            }
                        }
                    }

                    ans[i][j] /= count;
                }
            }

            return ans;
        }
    }
}
