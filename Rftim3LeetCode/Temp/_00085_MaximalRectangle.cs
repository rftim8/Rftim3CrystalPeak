namespace Rftim3LeetCode.Temp
{
    public class _00085_MaximalRectangle
    {
        /// <summary>
        /// Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
        /// </summary>
        public _00085_MaximalRectangle()
        {
            Console.WriteLine(MaximalRectangle(
            [
                ['1', '0', '1', '0', '0'],
                ['1', '0', '1', '1', '1'],
                ['1', '1', '1', '1', '1'],
                ['1', '0', '0', '1', '0']
            ]));
            Console.WriteLine(MaximalRectangle(
            [
                ['0']
            ]));
            Console.WriteLine(MaximalRectangle(
            [
                ['1']
            ]));
        }

        private static int MaximalRectangle(char[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int r = 0;
            int[] h = new int[m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '1') h[j] += 1;
                    else h[j] = 0;
                }

                Stack<int> s = new();

                for (int j = 0; j <= m; j++)
                {
                    int c = j == m ? 0 : h[j];

                    while (s.Count > 0 && h[s.Peek()] > c)
                    {
                        int l = h[s.Pop()];
                        int w = j - 1 - (s.Count == 0 ? -1 : s.Peek());

                        r = Math.Max(r, l * w);
                    }

                    s.Push(j);
                }
            }

            return r;
        }
    }
}
