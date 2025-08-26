using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00832_FlippingAnImage
    {
        /// <summary>
        /// Given an n x n binary matrix image, flip the image horizontally, then invert it, and return the resulting image.
        /// To flip an image horizontally means that each row of the image is reversed.
        /// For example, flipping[1, 1, 0] horizontally results in [0,1,1].
        /// To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0.
        /// For example, inverting[0, 1, 1] results in [1,0,0].
        /// </summary>
        public _00832_FlippingAnImage()
        {
            int[][] x = FlipAndInvertImage(
            [
                [1,1,0],
                [1,0,1],
                [0,0,0]
            ]);

            int[][] x0 = FlipAndInvertImage(
            [
                [1,1,0,0],
                [1,0,0,1],
                [0,1,1,1],
                [1,0,1,0]
            ]);

            RftTerminal.RftReadResult<int>(x);
            RftTerminal.RftReadResult<int>(x0);
        }

        private static int[][] FlipAndInvertImage(int[][] image)
        {
            int n = image.Length;
            int m = image[0].Length;

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(image[i]);
                for (int j = 0; j < m; j++)
                {
                    image[i][j] = image[i][j] == 0 ? 1 : 0;
                }
            }

            return image;
        }
    }
}
