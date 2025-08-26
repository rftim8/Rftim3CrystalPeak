namespace Rftim3LeetCode.Temp
{
    public class _00052_NQueensII
    {
        /// <summary>
        /// The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
        /// Given an integer n, return the number of distinct solutions to the n-queens puzzle.
        /// </summary>
        public _00052_NQueensII()
        {
            Console.WriteLine(NQueensII0(4));
            Console.WriteLine(NQueensII0(1));
        }

        public static int NQueensII0(int a0) => RftNQueensII0(a0);

        private static int RftNQueensII0(int n)
        {
            List<IList<string>> r = [];

            DFS(new int[n], 0, r);

            return r.Count;
        }

        private static void DFS(int[] board, int n, List<IList<string>> r)
        {
            int m = board.Length;
            if (n == m)
            {
                r.Add(PrintBoard(board));

                return;
            }

            for (int i = 0; i < m; i++)
            {
                if (IsValid(board, n, i))
                {
                    board[n] = i;
                    DFS(board, n + 1, r);
                }
            }
        }

        private static bool IsValid(int[] board, int n, int x)
        {
            for (int i = 0; i < n; i++)
            {
                if (i + board[i] == x + n || i - board[i] == n - x || board[i] == x) return false;
            }

            return true;
        }

        private static List<string> PrintBoard(int[] board)
        {
            List<string> r = [];
            for (int i = 0; i < board.Length; i++)
            {
                char[] t = Enumerable.Repeat('.', board.Length).ToArray();
                t[board[i]] = 'Q';
                r.Add(new string(t));
            }

            return r;
        }
    }
}
