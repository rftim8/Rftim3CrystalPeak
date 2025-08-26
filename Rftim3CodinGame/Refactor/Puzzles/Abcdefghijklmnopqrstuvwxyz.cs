using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Abcdefghijklmnopqrstuvwxyz
    {
        /// <summary>
        /// This program problem find out the consecutive string from a to z in alphabetical order in a multi-line string m of n lines of length n.
        /// You can move up, right, left or down.First, you find the a.
        ///  - if there is a b either up, down, left or right from the position of a, you can move there. 
        ///  - if there is a c either up, down, left or right from the position of b, you can move there. continues below to z.
        /// Rewrites all nonconsecutive strings of letters a through z to -.
        /// In other words, this problem only displays the consecutive string from a to z in a multi-line string m of n lines of length n.
        /// Answer to output , as follows.
        /// 
        /// Example:
        /// 
        /// 10
        /// qadnhwbnyw
        /// iiopcygydk
        /// bahlfiojdc
        /// cfijtdmkgf
        /// dzhkliplzg
        /// efgrmpqryx
        /// loehnovstw
        /// jrsacymeuv
        /// fpnocpdkrs
        /// jlmsvwvuih
        /// 
        /// 
        /// 
        /// The answer to this is...
        /// 
        /// ----------
        /// ----------
        /// ba--------
        /// c-ij------
        /// d-hkl---z-
        /// efg-mpqryx
        /// ----no-stw
        /// --------uv
        /// ----------
        /// ----------
        /// </summary>
        public Abcdefghijklmnopqrstuvwxyz()
        {
            char[][] r = RftSolve([
                ['q', 'a', 'd', 'n', 'h', 'w', 'b', 'n', 'y', 'w'],
                ['i', 'i', 'o', 'p', 'c', 'y', 'g', 'y', 'd', 'k'],
                ['b', 'a', 'h', 'l', 'f', 'i', 'o', 'j', 'd', 'c'],
                ['c', 'f', 'i', 'j', 't', 'd', 'm', 'k', 'g', 'f'],
                ['d', 'z', 'h', 'k', 'l', 'i', 'p', 'l', 'z', 'g'],
                ['e', 'f', 'g', 'r', 'm', 'p', 'q', 'r', 'y', 'x'],
                ['l', 'o', 'e', 'h', 'n', 'o', 'v', 's', 't', 'w'],
                ['j', 'r', 's', 'a', 'c', 'y', 'm', 'e', 'u', 'v'],
                ['f', 'p', 'n', 'o', 'c', 'p', 'd', 'k', 'r', 's'],
                ['j', 'l', 'm', 's', 'v', 'w', 'v', 'u', 'i', 'h']
            ]);

            RftTerminal.RftReadResult<char>(r);
        }

        public static char[][] RftSolve(char[][] map)
        {
            // Map result
            char[][] mapr = NewMap(map);
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'a')
                    {
                        // Find a origin
                        int x = j;
                        int y = i;
                        mapr[y][x] = 'a';
                        char c = 'b';

                        while (c != '{')
                        {
                            char t = c;
                            if (y - 1 >= 0 && map[y - 1][x] == c)
                            {
                                y--;
                                mapr[y][x] = c;
                                c = (char)(c + 1);
                            }
                            else if (x - 1 >= 0 && map[y][x - 1] == c)
                            {
                                x--;
                                mapr[y][x] = c;
                                c = (char)(c + 1);
                            }
                            else if (y + 1 < map[i].Length && map[y + 1][x] == c)
                            {
                                y++;
                                mapr[y][x] = c;
                                c = (char)(c + 1);
                            }
                            else if (x + 1 < map.Length && map[y][x + 1] == c)
                            {
                                x++;
                                mapr[y][x] = c;
                                c = (char)(c + 1);
                            }

                            if (t == c)
                            {
                                mapr = NewMap(map);
                                break;
                            }

                            if (c == '{') return mapr;
                        }
                    }
                }
            }

            return mapr;
        }

        // Create map
        private static char[][] NewMap(char[][] map)
        {
            char[][] mapr = new char[map.Length][];
            for (int i = 0; i < map.Length; i++)
            {
                mapr[i] = Enumerable.Repeat('-', map[i].Length).ToArray();
            }

            return mapr;
        }
    }
}
