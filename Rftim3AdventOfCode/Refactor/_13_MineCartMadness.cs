using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _13_MineCartMadness : I_13_MineCartMadness
    {
        #region Static
        private readonly List<string>? data;

        public _13_MineCartMadness()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_13_MineCartMadness));
        }

        /// <summary>
        /// A crop of this size requires significant logistics to transport produce, soil, fertilizer, and so on. 
        /// The Elves are very busy pushing things around in carts on some kind of rudimentary system of tracks they've come up with.
        /// 
        /// Seeing as how cart-and-track systems don't appear in recorded history for another 1000 years, the Elves seem to be making this up as they go along. 
        /// They haven't even figured out how to avoid collisions yet.
        /// 
        /// You map out the tracks(your puzzle input) and see where you can help.
        /// 
        /// Tracks consist of straight paths (| and -), curves(/ and \), and intersections(+). Curves connect exactly two perpendicular pieces of track; 
        /// for example, this is a closed loop:
        /// 
        /// /----\
        /// |    |
        /// |    |
        /// \----/
        /// Intersections occur when two perpendicular paths cross.At an intersection, a cart is capable of turning left, turning right, or continuing straight.
        /// Here are two loops connected by two intersections:
        /// 
        /// /-----\
        /// |     |
        /// |  /--+--\
        /// |  |  |  |
        /// \--+--/  |
        ///    |     |
        ///    \-----/
        /// Several carts are also on the tracks.Carts always face either up(^), down(v), left(<), or right(>). 
        /// (On your initial map, the track under each cart is a straight path matching the direction the cart is facing.)
        /// 
        /// Each time a cart has the option to turn(by arriving at any intersection), it turns left the first time, goes straight the second time,
        /// turns right the third time, and then repeats those directions starting again with left the fourth time, straight the fifth time, and so on.
        /// This process is independent of the particular intersection at which the cart has arrived - that is, the cart has no per-intersection memory.
        /// 
        /// Carts all move at the same speed; they take turns moving a single step at a time.
        /// They do this based on their current location: carts on the top row move first (acting from left to right), 
        /// then carts on the second row move(again from left to right), then carts on the third row, and so on.Once each cart has moved one step, the process repeats; 
        /// each of these loops is called a tick.
        /// For example, suppose there are two carts on a straight track:
        /// 
        /// |  |  |  |  |
        /// v  |  |  |  |
        /// |  v v  |  |
        /// |  |  |  v X
        /// |  |  ^  ^  |
        /// ^  ^  |  |  |
        /// |  |  |  |  |
        /// First, the top cart moves.It is facing down (v), so it moves down one square. Second, the bottom cart moves. It is facing up (^), so it moves up one square.
        /// Because all carts have moved, the first tick ends. Then, the process repeats, starting with the first cart.
        /// The first cart moves down, then the second cart moves up - right into the first cart, colliding with it! (The location of the crash is marked with an X.)
        /// This ends the second and last tick.
        /// 
        /// Here is a longer example:
        /// 
        /// /->-\        
        /// |   |  /----\
        /// | /-+--+-\  |
        /// | | |  | v  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /-->\        
        /// |   |  /----\
        /// | /-+--+-\  |
        /// | | |  | |  |
        /// \-+-/  \->--/
        ///   \------/   
        /// 
        /// /---v        
        /// |   |  /----\
        /// | /-+--+-\  |
        /// | | |  | |  |
        /// \-+-/  \-+>-/
        ///   \------/   
        /// 
        /// /---\        
        /// |   v  /----\
        /// | /-+--+-\  |
        /// | | |  | |  |
        /// \-+-/  \-+->/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /----\
        /// | /->--+-\  |
        /// | | |  | |  |
        /// \-+-/  \-+--^
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /----\
        /// | /-+>-+-\  |
        /// | | |  | |  ^
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /----\
        /// | /-+->+-\  ^
        /// | | |  | |  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /----<
        /// | /-+-->-\  |
        /// | | |  | |  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /---<\
        /// | /-+--+>\  |
        /// | | |  | |  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /--<-\
        /// | /-+--+-v  |
        /// | | |  | |  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /-<--\
        /// | /-+--+-\  |
        /// | | |  | v  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /<---\
        /// | /-+--+-\  |
        /// | | |  | |  |
        /// \-+-/  \-<--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  v----\
        /// | /-+--+-\  |
        /// | | |  | |  |
        /// \-+-/  \<+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /----\
        /// | /-+--v-\  |
        /// | | |  | |  |
        /// \-+-/  ^-+--/
        ///   \------/   
        /// 
        /// /---\        
        /// |   |  /----\
        /// | /-+--+-\  |
        /// | | |  X |  |
        /// \-+-/  \-+--/
        ///   \------/   
        /// After following their respective paths for a while, the carts eventually crash.
        /// To help prevent crashes, you'd like to know the location of the first crash.
        /// Locations are given in X,Y coordinates, where the furthest left column is X=0 and the furthest top row is Y=0:
        /// 
        ///            111
        ///  0123456789012
        /// 0/---\        
        /// 1|   |  /----\
        /// 2| /-+--+-\  |
        /// 3| | |  X |  |
        /// 4\-+-/  \-+--/
        /// 5  \------/   
        /// In this example, the location of the first crash is 7,3.
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            string r = string.Empty;

            int maxLine = input.Max(x => x.Length);
            char[,] grid = new char[input.Count, maxLine];
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    grid[i, j] = input[i][j];
                }
            }
            char[] cartSymbols = ['^', 'v', '>', '<'];
            List<(int x, int y, char dir, char turn, bool crashed)> carts = [];
            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (!cartSymbols.Contains(grid[y, x])) continue;

                    carts.Add((x, y, grid[y, x], 'l', false));
                    if (grid[y, x] == '^' || grid[y, x] == 'v') grid[y, x] = '|';
                    else grid[y, x] = '-';
                }
            }

            Dictionary<(char dir, char gridSymbol), char> turns = new()
            {
                { ('<', '/'), 'v' },
                { ('^', '/'), '>' },
                { ('>', '/'), '^' },
                { ('v', '/'), '<' },
                { ('<', '\\'), '^' },
                { ('^', '\\'), '<' },
                { ('>', '\\'), 'v' },
                { ('v', '\\'), '>' },
            };
            Dictionary<(char dir, char turn), (char dir, char turn)> intersections = new()
            {
                { ('<', 'l'), ('v', 's') },
                { ('<', 's'), ('<', 'r') },
                { ('<', 'r'), ('^', 'l') },
                { ('^', 'l'), ('<', 's') },
                { ('^', 's'), ('^', 'r') },
                { ('^', 'r'), ('>', 'l') },
                { ('>', 'l'), ('^', 's') },
                { ('>', 's'), ('>', 'r') },
                { ('>', 'r'), ('v', 'l') },
                { ('v', 'l'), ('>', 's') },
                { ('v', 's'), ('v', 'r') },
                { ('v', 'r'), ('<', 'l') },
            };

            bool done = false;
            while (!done)
            {
                if (carts.Count(x => !x.crashed) == 1)
                {
                    Console.WriteLine(carts.First(x => !x.crashed));
                    done = true;
                    continue;
                }
                List<(int x, int y, char dir, char turn, bool crashed)> orderedCarts = [.. carts.OrderBy(x => x.y).ThenBy(x => x.x)];
                for (int i = 0; i < orderedCarts.Count; i++)
                {
                    (int x, int y, char dir, char turn, bool crashed) cart = orderedCarts[i];
                    if (cart.crashed) continue;

                    (int x, int y) = GetNextPoint(cart.x, cart.y, cart.dir);
                    if (orderedCarts.Any(c => c.x == x && c.y == y))
                    {
                        r = $"{x},{y}";
                        done = true;
                    }

                    int crashedCartIndex = orderedCarts.FindIndex(c => !c.crashed && c.x == x && c.y == y);
                    if (crashedCartIndex >= 0)
                    {
                        orderedCarts[i] = (x, y, cart.dir, cart.turn, true);
                        orderedCarts[crashedCartIndex] = (x, y, cart.dir, cart.turn, true);
                        continue;
                    }

                    char gridSymbol = grid[y, x];
                    if (gridSymbol == '\\' || gridSymbol == '/') orderedCarts[i] = (x, y, turns[(cart.dir, gridSymbol)], cart.turn, cart.crashed);
                    else if (gridSymbol == '+')
                    {
                        (char dir, char turn) = intersections[(cart.dir, cart.turn)];
                        orderedCarts[i] = (x, y, dir, turn, cart.crashed);
                    }
                    else orderedCarts[i] = (x, y, cart.dir, cart.turn, cart.crashed);
                }

                carts = orderedCarts;
            }

            return r;
        }

        /// <summary>
        /// There isn't much you can do to prevent crashes in this ridiculous system. 
        /// However, by predicting the crashes, the Elves know where to be in advance and instantly remove the two crashing carts the moment any crash occurs.
        /// 
        /// They can proceed like this for a while, but eventually, they're going to run out of carts. 
        /// It could be useful to figure out where the last cart that hasn't crashed will end up.
        /// 
        /// For example:
        /// 
        /// />-<\  
        /// |   |  
        /// | /<+-\
        /// | | | v
        /// \>+</ |
        ///   |   ^
        ///   \<->/
        /// 
        /// /---\  
        /// |   |  
        /// | v-+-\
        /// | | | |
        /// \-+-/ |
        ///   |   |
        ///   ^---^
        /// 
        /// /---\  
        /// |   |  
        /// | /-+-\
        /// | v | |
        /// \-+-/ |
        ///   ^   ^
        ///   \---/
        /// 
        /// /---\  
        /// |   |  
        /// | /-+-\
        /// | | | |
        /// \-+-/ ^
        ///   |   |
        ///   \---/
        /// After four very expensive crashes, a tick ends with only one cart remaining; its final location is 6,4.
        /// 
        /// What is the location of the last cart at the end of the first tick where it is the only cart left?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string r = string.Empty;
            int maxLine = input.Max(x => x.Length);
            char[,] grid = new char[input.Count, maxLine];
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    grid[i, j] = input[i][j];
                }
            }
            char[] cartSymbols = ['^', 'v', '>', '<'];
            List<(int x, int y, char dir, char turn, bool crashed)> carts = [];
            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (!cartSymbols.Contains(grid[y, x])) continue;

                    carts.Add((x, y, grid[y, x], 'l', false));
                    if (grid[y, x] == '^' || grid[y, x] == 'v') grid[y, x] = '|';
                    else grid[y, x] = '-';
                }
            }

            Dictionary<(char dir, char gridSymbol), char> turns = new()
            {
                { ('<', '/'), 'v' },
                { ('^', '/'), '>' },
                { ('>', '/'), '^' },
                { ('v', '/'), '<' },
                { ('<', '\\'), '^' },
                { ('^', '\\'), '<' },
                { ('>', '\\'), 'v' },
                { ('v', '\\'), '>' },
            };
            Dictionary<(char dir, char turn), (char dir, char turn)> intersections = new()
            {
                { ('<', 'l'), ('v', 's') },
                { ('<', 's'), ('<', 'r') },
                { ('<', 'r'), ('^', 'l') },
                { ('^', 'l'), ('<', 's') },
                { ('^', 's'), ('^', 'r') },
                { ('^', 'r'), ('>', 'l') },
                { ('>', 'l'), ('^', 's') },
                { ('>', 's'), ('>', 'r') },
                { ('>', 'r'), ('v', 'l') },
                { ('v', 'l'), ('>', 's') },
                { ('v', 's'), ('v', 'r') },
                { ('v', 'r'), ('<', 'l') },
            };

            bool done = false;
            while (!done)
            {
                if (carts.Count(x => !x.crashed) == 1)
                {
                    (int x, int y, char dir, char turn, bool crashed) t = carts.First(x => !x.crashed);
                    r = $"{t.x},{t.y}";
                    done = true;
                    continue;
                }
                List<(int x, int y, char dir, char turn, bool crashed)> orderedCarts = [.. carts.OrderBy(x => x.y).ThenBy(x => x.x)];
                for (int i = 0; i < orderedCarts.Count; i++)
                {
                    (int x, int y, char dir, char turn, bool crashed) cart = orderedCarts[i];
                    if (cart.crashed) continue;

                    (int x, int y) = GetNextPoint(cart.x, cart.y, cart.dir);
                    int crashedCartIndex = orderedCarts.FindIndex(c => !c.crashed && c.x == x && c.y == y);
                    if (crashedCartIndex >= 0)
                    {
                        orderedCarts[i] = (x, y, cart.dir, cart.turn, true);
                        orderedCarts[crashedCartIndex] = (x, y, cart.dir, cart.turn, true);
                        continue;
                    }

                    char gridSymbol = grid[y, x];
                    if (gridSymbol == '\\' || gridSymbol == '/') orderedCarts[i] = (x, y, turns[(cart.dir, gridSymbol)], cart.turn, cart.crashed);
                    else if (gridSymbol == '+')
                    {
                        (char dir, char turn) = intersections[(cart.dir, cart.turn)];
                        orderedCarts[i] = (x, y, dir, turn, cart.crashed);
                    }
                    else orderedCarts[i] = (x, y, cart.dir, cart.turn, cart.crashed);
                }

                carts = orderedCarts;
            }

            return r;
        }

        private static (int x, int y) GetNextPoint(int x, int y, char dir)
        {
            switch (dir)
            {
                case '^':
                    return (x, y - 1);
                case 'v':
                    return (x, y + 1);
                case '>':
                    return (x + 1, y);
                case '<':
                    return (x - 1, y);
                default:
                    break;
            }

            return new();
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _13_MineCartMadness(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_13_MineCartMadness));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}