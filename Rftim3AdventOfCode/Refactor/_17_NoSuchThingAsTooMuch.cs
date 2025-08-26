using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _17_NoSuchThingAsTooMuch : I_17_NoSuchThingAsTooMuch
    {
        #region Static
        private readonly List<string>? data;

        public _17_NoSuchThingAsTooMuch()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_17_NoSuchThingAsTooMuch));
        }

        /// <summary>
        /// The elves bought too much eggnog again - 150 liters this time. To fit it all into your refrigerator, you'll need to move it into smaller containers. 
        /// You take an inventory of the capacities of the available containers.
        /// 
        /// For example, suppose you have containers of size 20, 15, 10, 5, and 5 liters.If you need to store 25 liters, there are four ways to do it:
        /// 
        /// 15 and 10
        /// 20 and 5 (the first 5)
        /// 20 and 5 (the second 5)
        /// 15, 5, and 5
        /// 
        /// Filling all containers entirely, how many different combinations of containers can exactly fit all 150 liters of eggnog?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<int> data = input.Select(int.Parse).ToList();
            double count = Math.Pow(2, data.Count);
            List<string> r = [];

            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(data.Count, '0');
                string x = string.Empty;
                int q = 0;

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        x += $"{data[j]} ";
                        q += data[j];
                    }
                }

                if (q == 150)
                {
                    r.Add(x.Trim());
                    Console.WriteLine(x.Trim());
                }
            }

            return r.Count;
        }

        /// <summary>
        /// While playing with all the containers in the kitchen, another load of eggnog arrives! 
        /// The shipping and receiving department is requesting as many containers as you can spare.
        /// 
        /// Find the minimum number of containers that can exactly fit all 150 liters of eggnog.
        /// How many different ways can you fill that number of containers and still hold exactly 150 litres?
        /// 
        /// In the example above, the minimum number of containers was two.There were three ways to use that many containers, and so the answer there would be 3.
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<int> data = input.Select(int.Parse).ToList();
            double count = Math.Pow(2, data.Count);
            List<string> r = [];

            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(data.Count, '0');
                string x = string.Empty;
                int q = 0;

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        x += $"{data[j]} ";
                        q += data[j];
                    }
                }

                if (q == 150)
                {
                    r.Add(x.Trim());
                    Console.WriteLine(x.Trim());
                }
            }

            int l = r.Select(o => o.Split(' ').Length).Min();

            Console.WriteLine($"150 liters with minimum containers: {r.Where(o => o.Split(' ').Length == l).Count()}");

            return r.Where(o => o.Split(' ').Length == l).Count();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _17_NoSuchThingAsTooMuch(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_17_NoSuchThingAsTooMuch));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}