using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _20_InfiniteElvesAndInfiniteHouses : I_20_InfiniteElvesAndInfiniteHouses
    {
        #region Static
        private readonly List<string>? data;

        public _20_InfiniteElvesAndInfiniteHouses()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_20_InfiniteElvesAndInfiniteHouses));
        }

        /// <summary>
        /// To keep the Elves busy, Santa has them deliver some presents by hand, door-to-door. He sends them down a street with infinite houses numbered sequentially: 1, 2, 3, 4, 5, and so on.
        ///  Each Elf is assigned a number, too, and delivers presents to houses based on that number:
        ///  
        ///  The first Elf(number 1) delivers presents to every house: 1, 2, 3, 4, 5, ....
        ///  The second Elf(number 2) delivers presents to every second house: 2, 4, 6, 8, 10, ....
        ///  Elf number 3 delivers presents to every third house: 3, 6, 9, 12, 15, ....
        ///  There are infinitely many Elves, numbered starting with 1. Each Elf delivers presents equal to ten times his or her number at each house.
        /// 
        ///  So, the first nine houses on the street end up like this:
        ///  
        ///  House 1 got 10 presents.
        ///  House 2 got 30 presents.
        ///  House 3 got 40 presents.
        ///  House 4 got 70 presents.
        ///  House 5 got 60 presents.
        ///  House 6 got 120 presents.
        ///  House 7 got 80 presents.
        ///  House 8 got 150 presents.
        ///  House 9 got 130 presents.
        ///  The first house gets 10 presents: it is visited only by Elf 1, which delivers 1 * 10 = 10 presents.The fourth house gets 70 presents, because it is visited by Elves 1, 2, and 4, for a total of 10 + 20 + 40 = 70 presents.
        /// 
        /// What is the lowest house number of the house to get at least as many presents as the number in your puzzle input?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            long data = long.Parse(input[0]);

            for (int i = 1; ; i++)
            {
                if (Divide(i, 2000) * 10 >= data)
                    return i;
            }
        }

        /// <summary>
        /// The Elves decide they don't want to visit an infinite number of houses. 
        /// Instead, each Elf will stop after delivering presents to 50 houses.
        /// To make up for it, they decide to deliver presents equal to eleven times their number at each house.
        /// 
        /// With these changes, what is the new lowest house number of the house to get at least as many presents as the number in your puzzle input?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            long data = long.Parse(input[0]);

            for (int i = 1; ; i++)
            {
                if (Divide(i, 50) * 11 >= data)
                    return i;
            }
        }

        private static long Divide(long nr, int houses)
        {
            long total = 0;

            for (long i = 1; i <= houses && i <= nr; i++)
            {
                if (nr % i == 0) total += nr / i;
            }

            return total;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _20_InfiniteElvesAndInfiniteHouses(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_20_InfiniteElvesAndInfiniteHouses));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}