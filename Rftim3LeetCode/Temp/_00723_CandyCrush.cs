using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00723_CandyCrush
    {
        /// <summary>
        /// This question is about implementing a basic elimination algorithm for Candy Crush.
        /// 
        /// Given an m x n integer array board representing the grid of candy where board[i][j] represents the type of candy.
        /// A value of board[i][j] == 0 represents that the cell is empty.
        /// 
        /// The given board represents the state of the game following the player's move. 
        /// Now, you need to restore the board to a stable state by crushing candies according to the following rules:
        /// 
        /// If three or more candies of the same type are adjacent vertically or horizontally, crush them all at the same time - these positions become empty.
        /// After crushing all candies simultaneously, if an empty space on the board has candies on top of itself, 
        /// then these candies will drop until they hit a candy or bottom at the same time. 
        /// No new candies will drop outside the top boundary.
        /// After the above steps, there may exist more candies that can be crushed.
        /// If so, you need to repeat the above steps.
        /// If there does not exist more candies that can be crushed (i.e., the board is stable), then return the current board.
        /// You need to perform the above rules until the board becomes stable, then return the stable board.
        /// </summary>
        public _00723_CandyCrush()
        {
            int[][] a0 = CandyCrush0(
                [
                    [110, 5, 112, 113, 114],
                    [210, 211, 5, 213, 214],
                    [310, 311, 3, 313, 314],
                    [410, 411, 412, 5, 414],
                    [5, 1, 512, 3, 3],
                    [610, 4, 1, 613, 614],
                    [710, 1, 2, 713, 714],
                    [810, 1, 2, 1, 1],
                    [1, 1, 2, 2, 2],
                    [4, 1, 4, 4, 1014]
                ]);
            RftTerminal.RftReadResult<int>(a0);

            int[][] b0 = CandyCrush0(
                [
                    [1, 3, 5, 5, 2],
                    [3, 4, 3, 3, 1],
                    [3, 2, 4, 5, 2],
                    [2, 4, 4, 5, 5],
                    [1, 4, 4, 1, 1]
                ]);
            RftTerminal.RftReadResult<int>(b0);
        }

        public static int[][] CandyCrush0(int[][] a0) => RftCandyCrush0(a0);

        public static int[][] CandyCrush1(int[][] a0) => RftCandyCrush1(a0);

        public static int[][] CandyCrush2(int[][] a0) => RftCandyCrush2(a0);

        private static int m, n;

        // Separate Steps: find, crush, drop
        private static int[][] RftCandyCrush0(int[][] board)
        {
            m = board.Length;
            n = board[0].Length;
            HashSet<(int, int)> crushedSet = Find(board);
            while (crushedSet.Count != 0)
            {
                Crush(board, crushedSet);
                Drop(board);
                crushedSet = Find(board);
            }

            return board;
        }

        private static HashSet<(int, int)> Find(int[][] board)
        {
            HashSet<(int, int)> crushedSet = [];

            for (int r = 1; r < m - 1; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (board[r][c] == 0) continue;
                    if (board[r][c] == board[r - 1][c] && board[r][c] == board[r + 1][c])
                    {
                        crushedSet.Add((r, c));
                        crushedSet.Add((r - 1, c));
                        crushedSet.Add((r + 1, c));
                    }
                }
            }

            for (int r = 0; r < m; r++)
            {
                for (int c = 1; c < n - 1; c++)
                {
                    if (board[r][c] == 0) continue;
                    if (board[r][c] == board[r][c - 1] && board[r][c] == board[r][c + 1])
                    {
                        crushedSet.Add((r, c));
                        crushedSet.Add((r, c - 1));
                        crushedSet.Add((r, c + 1));
                    }
                }
            }

            return crushedSet;
        }

        private static void Crush(int[][] board, HashSet<(int, int)> crushedSet)
        {
            foreach ((int, int) pair in crushedSet)
            {
                int r = pair.Item1;
                int c = pair.Item2;
                board[r][c] = 0;
            }
        }

        private static void Drop(int[][] board)
        {
            for (int c = 0; c < n; c++)
            {
                int lowestZero = -1;

                for (int r = m - 1; r >= 0; r--)
                {
                    if (board[r][c] == 0) lowestZero = Math.Max(lowestZero, r);
                    else if (lowestZero >= 0)
                    {
                        (board[lowestZero][c], board[r][c]) = (board[r][c], board[lowestZero][c]);
                        lowestZero--;
                    }
                }
            }
        }

        // In-Place Modification
        private static int[][] RftCandyCrush1(int[][] board)
        {
            m = board.Length;
            n = board[0].Length;

            while (!FindAndCrush(board))
            {
                Drop0(board);
            }

            return board;
        }

        private static bool FindAndCrush(int[][] board)
        {
            bool complete = true;

            for (int r = 1; r < m - 1; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (board[r][c] == 0) continue;
                    if (Math.Abs(board[r][c]) == Math.Abs(board[r - 1][c]) && Math.Abs(board[r][c]) == Math.Abs(board[r + 1][c]))
                    {
                        board[r][c] = -Math.Abs(board[r][c]);
                        board[r - 1][c] = -Math.Abs(board[r - 1][c]);
                        board[r + 1][c] = -Math.Abs(board[r + 1][c]);
                        complete = false;
                    }
                }
            }

            for (int r = 0; r < m; r++)
            {
                for (int c = 1; c < n - 1; c++)
                {
                    if (board[r][c] == 0) continue;
                    if (Math.Abs(board[r][c]) == Math.Abs(board[r][c - 1]) && Math.Abs(board[r][c]) == Math.Abs(board[r][c + 1]))
                    {
                        board[r][c] = -Math.Abs(board[r][c]);
                        board[r][c - 1] = -Math.Abs(board[r][c - 1]);
                        board[r][c + 1] = -Math.Abs(board[r][c + 1]);
                        complete = false;
                    }
                }
            }

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (board[r][c] < 0) board[r][c] = 0;
                }
            }

            return complete;
        }

        private static void Drop0(int[][] board)
        {
            for (int c = 0; c < n; c++)
            {
                int lowestZero = -1;

                for (int r = m - 1; r >= 0; r--)
                {
                    if (board[r][c] == 0) lowestZero = Math.Max(lowestZero, r);
                    else if (lowestZero >= 0)
                    {
                        (board[lowestZero][c], board[r][c]) = (board[r][c], board[lowestZero][c]);
                        lowestZero--;
                    }
                }
            }
        }

        private static int[][] RftCandyCrush2(int[][] board)
        {
            int R = board.Length, C = board[0].Length;
            bool toDo = false;

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c + 2 < C; c++)
                {
                    int v = Math.Abs(board[r][c]);
                    if (v != 0 && v == Math.Abs(board[r][c + 1]) && v == Math.Abs(board[r][c + 2]))
                    {
                        board[r][c] = board[r][c + 1] = board[r][c + 2] = -v;
                        toDo = true;
                    }
                }
            }

            for (int r = 0; r + 2 < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    int v = Math.Abs(board[r][c]);
                    if (v != 0 && v == Math.Abs(board[r + 1][c]) && v == Math.Abs(board[r + 2][c]))
                    {
                        board[r][c] = board[r + 1][c] = board[r + 2][c] = -v;
                        toDo = true;
                    }
                }
            }

            for (int c = 0; c < C; c++)
            {
                int wr = R - 1;
                for (int r = R - 1; r >= 0; r--)
                {
                    if (board[r][c] > 0)
                    {
                        board[wr--][c] = board[r][c];
                    }
                }

                while (wr >= 0)
                {
                    board[wr--][c] = 0;
                }
            }

            return toDo ? RftCandyCrush2(board) : board;
        }
    }
}