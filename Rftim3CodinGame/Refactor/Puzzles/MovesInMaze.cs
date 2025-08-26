namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class MovesInMaze
    {
        private static char c = '0';

        /// <summary>
        /// You are in a maze. 
        /// You have to find the minimum number of moves to reach each cell from the starting point, and output those numbers in the initial maze.
        /// 
        /// The number of moves is represented using a character: 0-9 then A-Z(A= 10, B= 11, ... Z= 35).
        /// 
        /// You may move from a cell to a neighbouring cell which is not a wall in any one of the four directions: left, right, up or down.
        /// The maze is periodic: if you go left you appear on the right if there is no wall, and vice versa, similarly with up/down.
        /// There may be unreachable points.
        /// 
        /// The input maze is made of # for walls, . for free spaces and S for the starting position.
        /// The output must be made of # for walls, . for unreachable points, and numbers 0-9, A-Z.
        /// </summary>
        public MovesInMaze()
        {
            char[][] map = [
                ['#', '#', '#', '#', '#', '#', '#', '#', '#', '#'],
                ['#', 'S', '.', '.', '.', '.', '.', '.', '.', '#'],
                ['#', '#', '.', '#', '#', '#', '#', '#', '.', '#'],
                ['#', '#', '.', '#', '.', '.', '.', '.', '.', '#'],
                ['#', '#', '#', '#', '#', '#', '#', '#', '#', '#']
            ];

            RftSolve(map);
        }

        public static char[][] RftSolve(char[][] map)
        {
            // Find starting point
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'S') map[i][j] = c;
                }
            }

            // Map area by current char
            for (int i = 0; i < map.Length * map[0].Length; i++) map = RftMap(map);

            // Print final map
            //for (int i = 0; i < map.Length; i++)
            //{
            //    for (int j = 0; j < map[i].Length; j++)
            //    {
            //        Console.Write(map[i][j]);
            //    }
            //    Console.WriteLine();
            //}
            return map;
        }

        private static char[][] RftMap(char[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == c)
                    {
                        if (i < map.Length - 1)
                        {
                            if (map[i + 1][j] == '.') map[i + 1][j] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }
                        else
                        {
                            if (map[0][j] == '.') map[0][j] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }

                        if (i > 0)
                        {
                            if (map[i - 1][j] == '.') map[i - 1][j] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }
                        else
                        {
                            if (map[^1][j] == '.') map[^1][j] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }

                        if (j < map[0].Length - 1)
                        {
                            if (map[i][j + 1] == '.') map[i][j + 1] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }
                        else
                        {
                            if (map[i][0] == '.') map[i][0] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }

                        if (j > 0)
                        {
                            if (map[i][j - 1] == '.') map[i][j - 1] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }
                        else
                        {
                            if (map[i][map[0].Length - 1] == '.') map[i][map[0].Length - 1] = map[i][j] + 1 == 58 ? (char)(map[i][j] + 8) : (char)(map[i][j] + 1);
                        }
                    }
                }
            }

            c = (char)(c + 1);

            return map;
        }
    }
}
