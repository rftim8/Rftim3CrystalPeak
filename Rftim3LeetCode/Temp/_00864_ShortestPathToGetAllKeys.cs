namespace Rftim3LeetCode.Temp
{
    public class _00864_ShortestPathToGetAllKeys
    {
        /// <summary>
        /// You are given an m x n grid grid where:
        ///'.' is an empty cell.
        ///'#' is a wall.
        ///'@' is the starting point.
        ///Lowercase letters represent keys.
        ///Uppercase letters represent locks.
        ///You start at the starting point and one move consists of walking one space in one of the four cardinal directions. 
        ///You cannot walk outside the grid, or walk into a wall.
        ///If you walk over a key, you can pick it up and you cannot walk over a lock unless you have its corresponding key.
        ///For some 1 <= k <= 6, there is exactly one lowercase and one uppercase letter of the first k letters of the English alphabet in the grid. 
        ///This means that there is exactly one key for each lock, and one lock for each key; 
        ///and also that the letters used to represent the keys and locks were chosen in the same order as the English alphabet.
        ///Return the lowest number of moves to acquire all keys.
        ///If it is impossible, return -1.
        /// </summary>
        public _00864_ShortestPathToGetAllKeys()
        {
            Console.WriteLine(ShortestPathToGetAllKeys0(["@.a..", "###.#", "b.A.B"]));
            Console.WriteLine(ShortestPathToGetAllKeys0(["@..aA", "..B#.", "....b"]));
            Console.WriteLine(ShortestPathToGetAllKeys0(["@Aa"]));
        }

        public static int ShortestPathToGetAllKeys0(string[] a0) => RftShortestPathToGetAllKeys0(a0);

        private static int RftShortestPathToGetAllKeys0(string[] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            Queue<int[]> queue = new();
            int[][] moves = [
                [0, 1],
                [1, 0],
                [-1, 0],
                [0, -1]
            ];

            Dictionary<int, HashSet<(int, int)>> seen = [];

            HashSet<char> keySet = [];
            HashSet<char> lockSet = [];
            int allKeys = 0;
            int startR = -1, startC = -1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char cell = grid[i][j];
                    if (cell >= 'a' && cell <= 'f')
                    {
                        allKeys += 1 << cell - 'a';
                        keySet.Add(cell);
                    }
                    if (cell >= 'A' && cell <= 'F') lockSet.Add(cell);
                    if (cell == '@')
                    {
                        startR = i;
                        startC = j;
                    }
                }
            }

            queue.Enqueue([startR, startC, 0, 0]);
            seen.Add(0, []);
            seen[0].Add((startR, startC));

            while (queue.Count != 0)
            {
                int[] cur = queue.Dequeue();
                int curR = cur[0], curC = cur[1], keys = cur[2], dist = cur[3];
                foreach (int[] move in moves)
                {
                    int newR = curR + move[0], newC = curC + move[1];

                    if (newR >= 0 && newR < m && newC >= 0 && newC < n && grid[newR][newC] != '#')
                    {
                        char cell = grid[newR][newC];

                        if (keySet.Contains(cell))
                        {
                            if ((1 << cell - 'a' & keys) != 0) continue;

                            int newKeys = keys | 1 << cell - 'a';

                            if (newKeys == allKeys) return dist + 1;

                            if (!seen.ContainsKey(newKeys)) seen.Add(newKeys, []);
                            seen[newKeys].Add((newR, newC));
                            queue.Enqueue([newR, newC, newKeys, dist + 1]);
                        }

                        if (lockSet.Contains(cell) && (keys & 1 << cell - 'A') == 0) continue;

                        else if (!seen[keys].Contains((newR, newC)))
                        {
                            seen[keys].Add((newR, newC));
                            queue.Enqueue([newR, newC, keys, dist + 1]);
                        }
                    }
                }
            }

            return -1;
        }
    }
}