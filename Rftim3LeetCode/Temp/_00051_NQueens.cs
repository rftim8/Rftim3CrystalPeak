using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00051_NQueens
    {
        /// <summary>
        /// The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
        /// Given an integer n, return all distinct solutions to the n-queens puzzle.You may return the answer in any order.
        /// Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.
        /// </summary>
        public _00051_NQueens()
        {
            IList<IList<string>> x = NQueens0(4);
            RftTerminal.RftReadResult(x);

            IList<IList<string>> x0 = NQueens0(1);
            RftTerminal.RftReadResult(x0);
        }

        public static List<IList<string>> NQueens0(int a0) => RftNQueens0(a0);

        private static List<IList<string>> RftNQueens0(int n)
        {
            List<IList<string>> r = [];

            DFS(new int[n], 0, r);

            return r;
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
