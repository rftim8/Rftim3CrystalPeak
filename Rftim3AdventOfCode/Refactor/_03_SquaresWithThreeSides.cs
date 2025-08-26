using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_SquaresWithThreeSides : I_03_SquaresWithThreeSides
    {
        #region Static
        private readonly List<string>? data;

        public _03_SquaresWithThreeSides()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_SquaresWithThreeSides));
        }

        /// <summary>
        /// Now that you can think clearly, you move deeper into the labyrinth of hallways and office furniture that makes up this part of Easter Bunny HQ. 
        /// This must be a graphic design department; the walls are covered in specifications for triangles.
        /// 
        /// Or are they?
        /// 
        /// The design document gives the side lengths of each triangle it describes, but... 5 10 25? Some of these aren't triangles. 
        /// You can't help but mark the impossible ones.
        /// In a valid triangle, the sum of any two sides must be larger than the remaining side.
        /// For example, the "triangle" given above is impossible, because 5 + 10 is not larger than 25.
        /// 
        /// In your puzzle input, how many of the listed triangles are possible?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            foreach (string item in input)
            {
                List<int> x = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                int a = x[0];
                int b = x[1];
                int c = x[2];

                if (a + b > c && b + c > a && a + c > b) r++;
            }

            return r;
        }

        /// <summary>
        /// Now that you've helpfully marked up their design documents, it occurs to you that triangles are specified in groups of three vertically. 
        /// Each set of three numbers in a column specifies a triangle. Rows are unrelated.
        /// 
        /// For example, given the following specification, numbers with the same hundreds digit would be part of the same triangle:
        /// 
        /// 101 301 501
        /// 102 302 502
        /// 103 303 503
        /// 201 401 601
        /// 202 402 602
        /// 203 403 603
        /// In your puzzle input, and instead reading by columns, how many of the listed triangles are possible?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            List<int> col0 = [];
            List<int> col1 = [];
            List<int> col2 = [];

            foreach (string item in input)
            {
                List<int> x = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                col0.Add(x[0]);
                col1.Add(x[1]);
                col2.Add(x[2]);
            }

            r += RftCount(col0);
            r += RftCount(col1);
            r += RftCount(col2);

            return r;
        }

        private static int RftCount(List<int> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i += 3)
            {
                if (input[i] + input[i + 1] > input[i + 2] && input[i] + input[i + 2] > input[i + 1] && input[i + 1] + input[i + 2] > input[i]) r++;
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _03_SquaresWithThreeSides(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_SquaresWithThreeSides));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}