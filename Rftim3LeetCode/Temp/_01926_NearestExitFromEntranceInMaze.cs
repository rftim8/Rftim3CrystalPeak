namespace Rftim3LeetCode.Temp
{
    public class _01926_NearestExitFromEntranceInMaze
    {
        /// <summary>
        /// You are given an m x n matrix maze (0-indexed) with empty cells (represented as '.') and walls (represented as '+'). 
        /// You are also given the entrance of the maze, where entrance = [entrancerow, entrancecol] denotes the row and column of the cell you are initially standing at.
        /// In one step, you can move one cell up, down, left, or right.You cannot step into a cell with a wall, and you cannot step outside the maze.
        /// Your goal is to find the nearest exit from the entrance.An exit is defined as an empty cell that is at the border of the maze.
        /// The entrance does not count as an exit.
        /// Return the number of steps in the shortest path from the entrance to the nearest exit, or -1 if no such path exists.
        /// </summary>
        public _01926_NearestExitFromEntranceInMaze()
        {
            Console.WriteLine(NearestExit([
                ['+','+','.','+'],
                ['.','.','.','+'],
                ['+','+','+','.']
            ],
            [1, 2]));

            Console.WriteLine(NearestExit([
                ['+','+','+'],
                ['.','.','.'],
                ['+','+','+']
            ],
            [1, 0]));

            Console.WriteLine(NearestExit([
                ['.','.','+']
            ],
            [0, 0]));
        }

        private static int NearestExit(char[][] maze, int[] entrance)
        {
            int n = maze.Length;
            int m = maze[0].Length;

            int[][] dirs = [
                [1, 0],
                [-1, 0],
                [0, 1],
                [0, -1]
            ];

            int startRow = entrance[0], startCol = entrance[1];
            maze[startRow][startCol] = '+';

            Queue<int[]> q = new();
            q.Enqueue([startRow, startCol, 0]);

            while (q.Count != 0)
            {
                int[] crtState = q.Dequeue();
                int crtRow = crtState[0], currCol = crtState[1], currDistance = crtState[2];

                foreach (int[] dir in dirs)
                {
                    int nextRow = crtRow + dir[0], nextCol = currCol + dir[1];

                    if (0 <= nextRow && nextRow < n && 0 <= nextCol && nextCol < m && maze[nextRow][nextCol] == '.')
                    {
                        if (nextRow == 0 || nextRow == n - 1 || nextCol == 0 || nextCol == m - 1) return currDistance + 1;

                        maze[nextRow][nextCol] = '+';
                        q.Enqueue([nextRow, nextCol, currDistance + 1]);
                    }
                }
            }

            return -1;
        }
    }
}
