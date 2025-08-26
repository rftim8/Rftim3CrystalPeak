using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _18_SettlersOfTheNorthPole : I_18_SettlersOfTheNorthPole
    {
        #region Static
        private readonly List<string>? data;

        public _18_SettlersOfTheNorthPole()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_18_SettlersOfTheNorthPole));
        }

        /// <summary>
        /// On the outskirts of the North Pole base construction project, many Elves are collecting lumber.
        /// 
        /// The lumber collection area is 50 acres by 50 acres; each acre can be either open ground(.), trees(|), or a lumberyard(#). 
        /// You take a scan of the area (your puzzle input).
        /// 
        /// Strange magic is at work here: each minute, the landscape looks entirely different.
        /// In exactly one minute, an open acre can fill with trees, a wooded acre can be converted to a lumberyard, 
        /// or a lumberyard can be cleared to open ground (the lumber having been sent to other projects).
        /// 
        /// The change to each acre is based entirely on the contents of that acre as well as the number of open, wooded, 
        /// or lumberyard acres adjacent to it at the start of each minute.Here, "adjacent" means any of the eight acres surrounding that acre. 
        /// (Acres on the edges of the lumber collection area might have fewer than eight adjacent acres; the missing acres aren't counted.)
        /// 
        /// In particular:
        /// 
        /// An open acre will become filled with trees if three or more adjacent acres contained trees.Otherwise, nothing happens.
        /// An acre filled with trees will become a lumberyard if three or more adjacent acres were lumberyards.Otherwise, nothing happens.
        /// An acre containing a lumberyard will remain a lumberyard if it was adjacent to at least one other lumberyard and at least one acre containing trees.
        /// Otherwise, it becomes open.
        /// These changes happen across all acres simultaneously, each of them using the state of all acres at the beginning 
        /// of the minute and changing to their new form by the end of that same minute.Changes that happen during the minute don't affect each other.
        /// 
        /// For example, suppose the lumber collection area is instead only 10 by 10 acres with this initial configuration:
        /// 
        /// Initial state:
        /// .#.#...|#.
        /// .....#|##|
        /// .|..|...#.
        /// ..|#.....#
        /// #.#|||#|#|
        /// ...#.||...
        /// .|....|...
        /// ||...#|.#|
        /// |.||||..|.
        /// ...#.|..|.
        /// 
        /// After 1 minute:
        /// .......##.
        /// ......|###
        /// .|..|...#.
        /// ..|#||...#
        /// ..##||.|#|
        /// ...#||||..
        /// ||...|||..
        /// |||||.||.|
        /// ||||||||||
        /// ....||..|.
        /// 
        /// After 2 minutes:
        /// .......#..
        /// ......|#..
        /// .|.|||....
        /// ..##|||..#
        /// ..###|||#|
        /// ...#|||||.
        /// |||||||||.
        /// ||||||||||
        /// ||||||||||
        /// .|||||||||
        /// 
        /// After 3 minutes:
        /// .......#..
        /// ....|||#..
        /// .|.||||...
        /// ..###|||.#
        /// ...##|||#|
        /// .||##|||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 4 minutes:
        /// .....|.#..
        /// ...||||#..
        /// .|.#||||..
        /// ..###||||#
        /// ...###||#|
        /// |||##|||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 5 minutes:
        /// ....|||#..
        /// ...||||#..
        /// .|.##||||.
        /// ..####|||#
        /// .|.###||#|
        /// |||###||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 6 minutes:
        /// ...||||#..
        /// ...||||#..
        /// .|.###|||.
        /// ..#.##|||#
        /// |||#.##|#|
        /// |||###||||
        /// ||||#|||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 7 minutes:
        /// ...||||#..
        /// ..||#|##..
        /// .|.####||.
        /// ||#..##||#
        /// ||##.##|#|
        /// |||####|||
        /// |||###||||
        /// ||||||||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 8 minutes:
        /// ..||||##..
        /// ..|#####..
        /// |||#####|.
        /// ||#...##|#
        /// ||##..###|
        /// ||##.###||
        /// |||####|||
        /// ||||#|||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 9 minutes:
        /// ..||###...
        /// .||#####..
        /// ||##...##.
        /// ||#....###
        /// |##....##|
        /// ||##..###|
        /// ||######||
        /// |||###||||
        /// ||||||||||
        /// ||||||||||
        /// 
        /// After 10 minutes:
        /// .||##.....
        /// ||###.....
        /// ||##......
        /// |##.....##
        /// |##.....##
        /// |##....##|
        /// ||##.####|
        /// ||#####|||
        /// ||||#|||||
        /// ||||||||||
        /// After 10 minutes, there are 37 wooded acres and 31 lumberyards. Multiplying the number of wooded acres by the number of lumberyards
        /// gives the total resource value after ten minutes: 37 * 31 = 1147.
        /// 
        /// What will the total resource value of the lumber collection area be after 10 minutes?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> data)
        {
            return 0;
        }

        /// <summary>
        /// This important natural resource will need to last for at least thousands of years. Are the Elves collecting this lumber sustainably?
        /// 
        /// What will the total resource value of the lumber collection area be after 1000000000 minutes?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> data)
        {
            return 0;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _18_SettlersOfTheNorthPole(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_18_SettlersOfTheNorthPole));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}