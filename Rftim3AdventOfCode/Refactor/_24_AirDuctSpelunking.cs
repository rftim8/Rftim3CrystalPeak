using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _24_AirDuctSpelunking : I_24_AirDuctSpelunking
    {
        #region Static
        private readonly List<string>? data;

        public _24_AirDuctSpelunking()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_24_AirDuctSpelunking));
        }

        /// <summary>
        /// You've finally met your match; the doors that provide access to the roof are locked tight, and all of the controls and related electronics are inaccessible.
        /// You simply can't reach them.
        /// 
        /// The robot that cleans the air ducts, however, can.
        /// 
        /// It's not a very fast little robot, but you reconfigure it to be able to interface with some of the exposed wires that have been routed through the HVAC system. 
        /// If you can direct it to each of those locations, you should be able to bypass the security controls.
        /// 
        /// You extract the duct layout for this area from some blueprints you acquired and create a map with the relevant locations marked(your puzzle input).
        /// 0 is your current location, from which the cleaning robot embarks; 
        /// the other numbers are(in no particular order) the locations the robot needs to visit at least once each.
        /// Walls are marked as #, and open passages are marked as .. Numbers behave like open passages.
        /// 
        /// For example, suppose you have a map like the following:
        /// 
        /// ###########
        /// #0.1.....2#
        /// #.#######.#
        /// #4.......3#
        /// ###########
        /// To reach all of the points of interest as quickly as possible, you would have the robot take the following path:
        /// 
        /// 0 to 4 (2 steps)
        /// 4 to 1 (4 steps; it can't move diagonally)
        /// 1 to 2 (6 steps)
        /// 2 to 3 (2 steps)
        /// Since the robot isn't very fast, you need to find it the shortest route. 
        /// This path is the fewest steps (in the above example, a total of 14) required to start at 0 and then visit every other location at least once.
        /// 
        /// Given your actual map, and starting from location 0, what is the fewest number of steps required to visit every non-0 number marked on the map at least once?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> data)
        {
            return 0;
        }

        /// <summary>
        /// Of course, if you leave the cleaning robot somewhere weird, someone is bound to notice.
        /// What is the fewest number of steps required to start at 0, visit every non-0 number marked on the map at least once, and then return to 0?
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

        public _24_AirDuctSpelunking(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_24_AirDuctSpelunking));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}