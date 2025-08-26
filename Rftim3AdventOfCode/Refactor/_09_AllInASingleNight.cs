using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _09_AllInASingleNight : I_09_AllInASingleNight
    {
        #region Static
        private readonly List<string>? data;

        public _09_AllInASingleNight()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_09_AllInASingleNight));
        }

        /// <summary>
        /// Every year, Santa manages to deliver all of his presents in a single night.
        /// This year, however, he has some new locations to visit; his elves have provided him the distances between every pair of locations.
        /// He can start and end at any two (different) locations he wants, but he must visit each location exactly once. 
        /// What is the shortest distance he can travel to achieve this?
        ///
        /// For example, given the following distances:
        /// 
        /// London to Dublin = 464
        /// London to Belfast = 518
        /// Dublin to Belfast = 141
        ///
        /// The possible routes are therefore:
        /// 
        /// Dublin -> London -> Belfast = 982
        /// London->Dublin->Belfast = 605
        /// London->Belfast->Dublin = 659
        /// Dublin->Belfast->London = 659
        /// Belfast->Dublin->London = 605
        /// Belfast->London->Dublin = 982
        ///
        /// The shortest of these is London -> Dublin -> Belfast = 605, and so the answer is 605 in this example.
        ///
        /// What is the distance of the shortest route?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<string> list = [];

            foreach (string item in input)
            {
                if (!list.Contains(item.Split(' ')[0])) list.Add(item.Split(' ')[0]);
                if (!list.Contains(item.Split(' ')[2])) list.Add(item.Split(' ')[2]);
            }

            IEnumerable<IEnumerable<string>> result = GetPermutations(list, list.Count);
            List<string> results = [];

            foreach (IEnumerable<string> item in result)
            {
                int r = 0;
                StringBuilder s = new();
                List<string> list2 = item.ToList();

                for (int i = 0; i < list2.Count - 1; i++)
                {
                    foreach (string item1 in input)
                    {
                        if (item1.Split(' ')[0] == list2[i] && item1.Split(' ')[2] == list2[i + 1] || item1.Split(' ')[0] == list2[i + 1] && item1.Split(' ')[2] == list2[i])
                        {
                            r += int.Parse(item1.Split(' ')[4]);
                        }
                    }
                    s.Append($"{list2[i]} ");

                    if (i == list2.Count - 2) s.Append($"{list2[i + 1]} ");
                }

                s.Append(r);

                results.Add(s.ToString());
            }
            List<int> x = [];

            foreach (string item in results)
            {
                x.Add(int.Parse(item.Split(' ').Last()));
                Console.WriteLine(item);
            }

            return x.Min();
        }

        /// <summary>
        /// The next year, just to show off, Santa decides to take the route with the longest distance instead.
        /// He can still start and end at any two (different) locations he wants, and he still must visit each location exactly once.
        /// For example, given the distances above, the longest route would be 982 via (for example) Dublin -> London -> Belfast.
        /// 
        /// What is the distance of the longest route?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<string> list = [];

            foreach (string item in input)
            {
                if (!list.Contains(item.Split(' ')[0])) list.Add(item.Split(' ')[0]);
                if (!list.Contains(item.Split(' ')[2])) list.Add(item.Split(' ')[2]);
            }

            IEnumerable<IEnumerable<string>> result = GetPermutations(list, list.Count);
            List<string> results = [];

            foreach (IEnumerable<string> item in result)
            {
                int r = 0;
                StringBuilder s = new();
                List<string> list2 = item.ToList();

                for (int i = 0; i < list2.Count - 1; i++)
                {
                    foreach (string item1 in input)
                    {
                        if (item1.Split(' ')[0] == list2[i] && item1.Split(' ')[2] == list2[i + 1] || item1.Split(' ')[0] == list2[i + 1] && item1.Split(' ')[2] == list2[i])
                        {
                            r += int.Parse(item1.Split(' ')[4]);
                        }
                    }
                    s.Append($"{list2[i]} ");

                    if (i == list2.Count - 2) s.Append($"{list2[i + 1]} ");
                }

                s.Append(r);

                results.Add(s.ToString());
            }
            List<int> x = [];

            foreach (string item in results)
            {
                x.Add(int.Parse(item.Split(' ').Last()));
                Console.WriteLine(item);
            }

            return x.Max();
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat([t2]));
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _09_AllInASingleNight(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_09_AllInASingleNight));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}