using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _11_SeatingSystem : I_11_SeatingSystem
    {
        #region Static
        private readonly List<string>? data;
        private static readonly string[] input = [];

        public _11_SeatingSystem()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_11_SeatingSystem));
        }

        /// <summary>
        /// Your plane lands with plenty of time to spare. The final leg of your journey is a ferry that goes directly to the tropical island
        /// where you can finally start your vacation. As you reach the waiting area to board the ferry, you realize you're so early, nobody else has even arrived yet!
        /// 
        /// By modeling the process people use to choose(or abandon) their seat in the waiting area, you're pretty sure you can predict the best place to sit. 
        /// You make a quick map of the seat layout (your puzzle input).
        /// 
        /// The seat layout fits neatly on a grid.Each position is either floor (.), an empty seat(L), or an occupied seat(#). 
        /// For example, the initial seat layout might look like this:
        /// 
        /// L.LL.LL.LL
        /// LLLLLLL.LL
        /// L.L.L..L..
        /// LLLL.LL.LL
        /// L.LL.LL.LL
        /// L.LLLLL.LL
        /// ..L.L.....
        /// LLLLLLLLLL
        /// L.LLLLLL.L
        /// L.LLLLL.LL
        /// Now, you just need to model the people who will be arriving shortly. Fortunately, people are entirely predictable and always follow a simple set of rules. 
        /// All decisions are based on the number of occupied seats adjacent to a given seat (one of the eight positions immediately up, down, left, right, or diagonal from the seat).
        /// The following rules are applied to every seat simultaneously:
        /// 
        /// If a seat is empty(L) and there are no occupied seats adjacent to it, the seat becomes occupied.
        /// If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
        /// Otherwise, the seat's state does not change.
        /// Floor (.) never changes; seats don't move, and nobody sits on the floor.
        /// 
        /// After one round of these rules, every seat in the example layout becomes occupied:
        /// 
        /// #.##.##.##
        /// #######.##
        /// #.#.#..#..
        /// ####.##.##
        /// #.##.##.##
        /// #.#####.##
        /// ..#.#.....
        /// ##########
        /// #.######.#
        /// #.#####.##
        /// After a second round, the seats with four or more occupied adjacent seats become empty again:
        /// 
        /// #.LL.L#.##
        /// #LLLLLL.L#
        /// L.L.L..L..
        /// #LLL.LL.L#
        /// #.LL.LL.LL
        /// #.LLLL#.##
        /// ..L.L.....
        /// #LLLLLLLL#
        /// #.LLLLLL.L
        /// #.#LLLL.##
        /// This process continues for three more rounds:
        /// 
        /// #.##.L#.##
        /// #L###LL.L#
        /// L.#.#..#..
        /// #L##.##.L#
        /// #.##.LL.LL
        /// #.###L#.##
        /// ..#.#.....
        /// #L######L#
        /// #.LL###L.L
        /// #.#L###.##
        /// #.#L.L#.##
        /// #LLL#LL.L#
        /// L.L.L..#..
        /// #LLL.##.L#
        /// #.LL.LL.LL
        /// #.LL#L#.##
        /// ..L.L.....
        /// #L#LLLL#L#
        /// #.LLLLLL.L
        /// #.#L#L#.##
        /// #.#L.L#.##
        /// #LLL#LL.L#
        /// L.#.L..#..
        /// #L##.##.L#
        /// #.#L.LL.LL
        /// #.#L#L#.##
        /// ..L.L.....
        /// #L#L##L#L#
        /// #.LLLLLL.L
        /// #.#L#L#.##
        /// At this point, something interesting happens: the chaos stabilizes and further applications of these rules cause no seats to change state!
        /// Once people stop moving around, you count 37 occupied seats.
        /// 
        /// Simulate your seating area by applying the seating rules repeatedly until no seats change state.How many seats end up occupied?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            height = input.Count;
            width = input[0].Length;
            map = new char[width, height];
            tempMap = new char[width, height];
            doPart2 = false;
            peopleNearThreshold = 4;
            GenerateMap();
            int count = 0;
            int part1 = 0;
            bool isNotStable = true;

            while (isNotStable)
            {
                int temp = UpdateSeats();
                CopyMap();
                if (temp == count)
                {
                    if (doPart2) isNotStable = false;
                    else
                    {
                        part1 = count;
                        doPart2 = true;
                        peopleNearThreshold = 5;
                        GenerateMap();
                        count = 0;
                    }
                }
                else count = temp;
            }

            return part1;
        }

        /// <summary>
        /// As soon as people start to arrive, you realize your mistake. 
        /// People don't just care about adjacent seats - they care about the first seat they can see in each of those eight directions!
        /// 
        /// Now, instead of considering just the eight immediately adjacent seats, consider the first seat in each of those eight directions.
        /// For example, the empty seat below would see eight occupied seats:
        /// 
        /// .......#.
        /// ...#.....
        /// .#.......
        /// .........
        /// ..#L....#
        /// ....#....
        /// .........
        /// #........
        /// ...#.....
        /// The leftmost empty seat below would only see one empty seat, but cannot see any of the occupied ones:
        /// 
        /// .............
        /// .L.L.#.#.#.#.
        /// .............
        /// The empty seat below would see no occupied seats:
        /// 
        /// .##.##.
        /// #.#.#.#
        /// ##...##
        /// ...L...
        /// ##...##
        /// #.#.#.#
        /// .##.##.
        /// Also, people seem to be more tolerant than you expected: 
        /// it now takes five or more visible occupied seats for an occupied seat to become empty(rather than four or more from the previous rules). 
        /// The other rules still apply: empty seats that see no occupied seats become occupied, seats matching no rule don't change, and floor never changes.
        /// 
        /// Given the same starting layout as above, these new rules cause the seating area to shift around as follows:
        /// 
        /// L.LL.LL.LL
        /// LLLLLLL.LL
        /// L.L.L..L..
        /// LLLL.LL.LL
        /// L.LL.LL.LL
        /// L.LLLLL.LL
        /// ..L.L.....
        /// LLLLLLLLLL
        /// L.LLLLLL.L
        /// L.LLLLL.LL
        /// #.##.##.##
        /// #######.##
        /// #.#.#..#..
        /// ####.##.##
        /// #.##.##.##
        /// #.#####.##
        /// ..#.#.....
        /// ##########
        /// #.######.#
        /// #.#####.##
        /// #.LL.LL.L#
        /// #LLLLLL.LL
        /// L.L.L..L..
        /// LLLL.LL.LL
        /// L.LL.LL.LL
        /// L.LLLLL.LL
        /// ..L.L.....
        /// LLLLLLLLL#
        /// #.LLLLLL.L
        /// #.LLLLL.L#
        /// #.L#.##.L#
        /// #L#####.LL
        /// L.#.#..#..
        /// ##L#.##.##
        /// #.##.#L.##
        /// #.#####.#L
        /// ..#.#.....
        /// LLL####LL#
        /// #.L#####.L
        /// #.L####.L#
        /// #.L#.L#.L#
        /// #LLLLLL.LL
        /// L.L.L..#..
        /// ##LL.LL.L#
        /// L.LL.LL.L#
        /// #.LLLLL.LL
        /// ..L.L.....
        /// LLLLLLLLL#
        /// #.LLLLL#.L
        /// #.L#LL#.L#
        /// #.L#.L#.L#
        /// #LLLLLL.LL
        /// L.L.L..#..
        /// ##L#.#L.L#
        /// L.L#.#L.L#
        /// #.L####.LL
        /// ..#.#.....
        /// LLL###LLL#
        /// #.LLLLL#.L
        /// #.L#LL#.L#
        /// #.L#.L#.L#
        /// #LLLLLL.LL
        /// L.L.L..#..
        /// ##L#.#L.L#
        /// L.L#.LL.L#
        /// #.LLLL#.LL
        /// ..#.L.....
        /// LLL###LLL#
        /// #.LLLLL#.L
        /// #.L#LL#.L#
        /// Again, at this point, people stop shifting around and the seating area reaches equilibrium. Once this occurs, you count 26 occupied seats.
        /// 
        /// Given the new visibility method and the rule change for occupied seats becoming empty, once equilibrium is reached, how many seats end up occupied?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            height = input.Count;
            width = input[0].Length;
            map = new char[width, height];
            tempMap = new char[width, height];
            GenerateMap();
            int count = 0;
            int part2 = 0;
            bool isNotStable = true;

            while (isNotStable)
            {
                int temp = UpdateSeats();
                CopyMap();
                if (temp == count)
                {
                    if (doPart2)
                    {
                        isNotStable = false;
                        part2 = count;
                    }
                    else
                    {
                        doPart2 = true;
                        peopleNearThreshold = 5;
                        GenerateMap();
                        count = 0;
                    }
                }
                else count = temp;
            }

            return part2;
        }

        private static int height;
        private static int width;
        private static char[,] map = new char[width, height];
        private static char[,] tempMap = new char[width, height];
        private static bool doPart2;
        private static int peopleNearThreshold = 4;
        private static readonly int[,] slopes = { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };

        private static void GenerateMap()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = input[y][x];
                }
            }
        }

        private static int CheckOtherSeats(int i, int x, int y, bool part2)
        {
            int adjacentSeatsOccupied = 0;
            int slopeX = slopes[i, 0] + x;
            int slopeY = slopes[i, 1] + y;
            bool onGridOrNotFoundSeat = true;
            do
            {
                if (slopeX >= 0 && slopeX < width && slopeY >= 0 && slopeY < height)
                {
                    if (map[slopeX, slopeY] == 'L') onGridOrNotFoundSeat = false;
                    else if (map[slopeX, slopeY] == '#')
                    {
                        adjacentSeatsOccupied++;
                        onGridOrNotFoundSeat = false;
                    }
                    slopeX += slopes[i, 0];
                    slopeY += slopes[i, 1];
                }
                else onGridOrNotFoundSeat = false;
            } while (part2 && onGridOrNotFoundSeat);

            return adjacentSeatsOccupied;
        }

        private static int UpdateSeats()
        {
            int totalSeatsOccupied = 0;
            int adjacentSeatsOccupied;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    adjacentSeatsOccupied = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        adjacentSeatsOccupied += CheckOtherSeats(i, x, y, doPart2);
                    }

                    if (map[x, y] == 'L' && adjacentSeatsOccupied == 0)
                    {
                        tempMap[x, y] = '#';
                        totalSeatsOccupied++;
                    }
                    else if (map[x, y] == '#' && adjacentSeatsOccupied >= peopleNearThreshold) tempMap[x, y] = 'L';
                    else if (map[x, y] == '#' && adjacentSeatsOccupied < peopleNearThreshold) totalSeatsOccupied++;
                }
            }

            return totalSeatsOccupied;
        }

        private static void CopyMap() => map = (char[,])tempMap.Clone();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _11_SeatingSystem(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_11_SeatingSystem));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}