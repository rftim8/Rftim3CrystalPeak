using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class FloodFillExample
    {
        /// <summary>
        /// The Resistance have made a map of Alderaan, the planet they are currently settled in. 
        /// They have put defence towers with heavy armaments on specific places in their base. 
        /// Princess Leia has asked for a map showing which defence tower is to operate when an enemy lands.
        /// 
        /// This map works on the following principle: whichever defence tower is closest to the spot where the enemy have landed, will operate.
        /// C3PO and R2D2 have been assigned the job of drafting this map.You must help them...
        /// 
        /// Of course, to make your job simpler, the map provided has been highly simplified to spots where enemy can land, and those where they can't.
        /// 
        /// -------------------------------------------------- xxx --------------------------------------------------
        /// 
        ///         The Problem:
        /// 
        ///         Given a grid consisting of ‘.’ (visitable points) and ‘#’ (un-visitable points), and other entities for the defence towers, 
        ///         output a map showing the area coverage of each tower, based on distance.
        /// 
        /// -------------------------------------------------- xxx --------------------------------------------------
        /// 
        ///         Rules:
        /// 
        /// 1. Each tower has an I.D., which is not '#', '.' or '+'. Note that 2 towers may have the same I.D..
        ///         
        /// 2. If 2 towers can reach a spot at the exact same time, mark that spot '+', even if both towers share the same I.D..
        ///         
        /// 3. Towers can't send troops through un-visitable spots ('#').
        /// 
        /// 4. If a tower can get to a spot first, mark the spot by its I.D..
        ///         
        /// 5. This is the legend:
        /// (i) '.' = reachable nodes
        ///         (ii) '#' = unreachable nodes
        ///         (iii) any other character = a tower's I.D.
        /// 
        /// 6. Troops sent out by the towers at a particular spot can immediately move by distance 1 in the cardinal directions, i.e.UP, DOWN, LEFT, RIGHT (diagonals not possible).
        /// 
        /// 7. If a spot on the map cannot be accessed(regardless of whether it is visitable or not) assign that spot with the character it had in the original map.
        /// 
        /// -------------------------------------------------- xxx --------------------------------------------------
        /// 
        /// Example:
        /// 
        /// Consider the following grid:
        /// ...#.
        /// A#...
        /// #..B.
        /// .....
        /// 
        /// At time = 1, they will reach…
        /// A..#.
        /// A#.B.
        /// #.BBB
        /// ...B.
        /// 
        /// At time = 2, they will reach…
        /// AA.#.
        /// A#BBB
        /// #BBBB
        /// ..BBB
        /// 
        /// At time = 3, they will reach…
        /// AA+#B
        /// A#BBB
        /// #BBBB
        /// .BBBB
        /// (Note that, both A and B can reach spot(2,0) at time = 3, so that spot is made into ‘+’)
        /// 
        /// At time = 4, they will reach…
        /// AA+#B
        /// A#BBB
        /// #BBBB
        /// BBBBB
        /// 
        /// This is what your program must output.
        /// </summary>
        public FloodFillExample()
        {
            string[] a0 = FloodFillExample0(
                [
                    "..#.#...##",
                    "#..#.#....",
                    ".........#",
                    "..#..#..#.",
                    ".......#..",
                    "..#.JEDI.#",
                    "..#.....#.",
                    ".....#..#.",
                    "..........",
                    ".........."
                ],
                10,
                10);
            RftTerminal.RftReadResult(a0);
        }

        public static string[] FloodFillExample0(string[] a0, int a1, int a2) => RftFloodFillExample0(a0, a1, a2);

        private static string[] RftFloodFillExample0(string[] map0, int W, int H)
        {
            #region Map Setup
            string[][] map = new string[H + 2][];
            map[0] = Enumerable.Repeat("-", W + 2).ToArray();
            for (int i = 1; i <= H; i++)
            {
                string line = map0[i - 1];
                string[] t = new string[W + 2];
                t[0] = "-";
                for (int j = 1; j <= W; j++)
                {
                    t[j] = line[j - 1].ToString();
                }
                t[W + 1] = "-";
                map[i] = t;
            }
            map[H + 1] = Enumerable.Repeat("-", W + 2).ToArray();
            #endregion

            #region Differentiate Troops With Similar Names
            int c = 0;
            HashSet<string> troops = [];
            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    if (map[i][j] != "."
                    && map[i][j] != "#"
                    && map[i][j] != "-")
                    {
                        if (troops.Contains(map[i][j]))
                        {
                            troops.Add($"{map[i][j]}{c}");
                            map[i][j] = $"{map[i][j]}{c}";
                            c++;
                        }
                        else troops.Add(map[i][j]);
                    }
                }
            }
            #endregion

            #region Flood Fill
            bool f = true;
            while (f)
            {
                f = false;
                Dictionary<(int, int), string> kvp = [];
                for (int i = 1; i <= H; i++)
                {
                    for (int j = 1; j <= W; j++)
                    {
                        if (map[i][j] != "."
                            && map[i][j] != "#"
                            && map[i][j] != "-")
                        {
                            // North
                            if (map[i - 1][j] == ".")
                            {
                                f = true;
                                if (kvp.ContainsKey((i - 1, j)))
                                {
                                    if (kvp[(i - 1, j)] != map[i][j]) kvp[(i - 1, j)] = "+";
                                }
                                else kvp[(i - 1, j)] = map[i][j];
                            }
                            // South
                            if (map[i + 1][j] == ".")
                            {
                                f = true;
                                if (kvp.ContainsKey((i + 1, j)))
                                {
                                    if (kvp[(i + 1, j)] != map[i][j]) kvp[(i + 1, j)] = "+";
                                }
                                else kvp[(i + 1, j)] = map[i][j];
                            }
                            // West
                            if (map[i][j - 1] == ".")
                            {
                                f = true;
                                if (kvp.ContainsKey((i, j - 1)))
                                {
                                    if (kvp[(i, j - 1)] != map[i][j]) kvp[(i, j - 1)] = "+";
                                }
                                else kvp[(i, j - 1)] = map[i][j];
                            }
                            // East
                            if (map[i][j + 1] == ".")
                            {
                                f = true;
                                if (kvp.ContainsKey((i, j + 1)))
                                {
                                    if (kvp[(i, j + 1)] != map[i][j]) kvp[(i, j + 1)] = "+";
                                }
                                else kvp[(i, j + 1)] = map[i][j];
                            }
                        }
                    }
                }
                foreach (KeyValuePair<(int, int), string> item in kvp)
                {
                    map[item.Key.Item1][item.Key.Item2] = item.Value;
                }

            }
            #endregion

            //#region Print Result
            //for (int i = 1; i <= H; i++)
            //{
            //    for (int j = 1; j <= W; j++)
            //    {
            //        if (map[i][j].Length > 1) Console.Write(map[i][j][0]);
            //        else Console.Write(map[i][j]);
            //    }
            //    Console.WriteLine();
            //}
            //#endregion

            #region Print Result
            string[] res = new string[H];
            for (int i = 1; i <= H; i++)
            {
                string res0 = string.Empty;
                for (int j = 1; j <= W; j++)
                {
                    if (map[i][j].Length > 1) res0 += map[i][j][0].ToString();
                    else res0 += map[i][j];
                }
                res[i - 1] = res0;
            }
            #endregion

            return res;
        }
    }
}
