using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _02_RedNosedReports : I_02_RedNosedReports
    {
        #region Static
        private readonly List<string>? data;

        public _02_RedNosedReports()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_02_RedNosedReports));
        }

        /// <summary>
        /// Fortunately, the first location The Historians want to search isn't a long walk from the Chief Historian's office.
        /// While the Red-Nosed Reindeer nuclear fusion/fission plant appears to contain no sign of the Chief Historian, the engineers there run up to you as soon as they see you.
        /// Apparently, they still talk about the time Rudolph was saved through molecular synthesis from a single electron.
        /// They're quick to add that - since you're already here - they'd really appreciate your help analyzing some unusual data from the Red-Nosed reactor. 
        /// You turn to check if The Historians are waiting for you, but they seem to have already divided into groups that are currently searching every corner of the facility. 
        /// You offer to help with the unusual data.
        /// The unusual data (your puzzle input) consists of many reports, one report per line.Each report is a list of numbers called levels that are separated by spaces.For example:
        /// 
        /// 7 6 4 2 1
        /// 1 2 7 8 9
        /// 9 7 6 2 1
        /// 1 3 2 4 5
        /// 8 6 4 4 1
        /// 1 3 6 7 9
        /// 
        /// This example data contains six reports each containing five levels.
        /// The engineers are trying to figure out which reports are safe. 
        /// The Red-Nosed reactor safety systems can only tolerate levels that are either gradually increasing or gradually decreasing. 
        /// So, a report only counts as safe if both of the following are true:
        /// The levels are either all increasing or all decreasing.
        /// Any two adjacent levels differ by at least one and at most three.
        /// In the example above, the reports can be found safe or unsafe by checking those rules:
        /// 
        /// 7 6 4 2 1: Safe because the levels are all decreasing by 1 or 2.
        /// 1 2 7 8 9: Unsafe because 2 7 is an increase of 5.
        /// 9 7 6 2 1: Unsafe because 6 2 is a decrease of 4.
        /// 1 3 2 4 5: Unsafe because 1 3 is increasing but 3 2 is decreasing.
        /// 8 6 4 4 1: Unsafe because 4 4 is neither an increase or a decrease.
        /// 1 3 6 7 9: Safe because the levels are all increasing by 1, 2, or 3.
        /// So, in this example, 2 reports are safe.
        /// 
        /// Analyze the unusual data from the engineers.How many reports are safe?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int res = 0;

            foreach (string item in input)
            {
                List<int> a = [.. item.Split(" ").Select(int.Parse)];
                List<int> b = [];

                for (int i = 0; i < a.Count - 1; i++)
                {
                    if (a[i] > a[i + 1])
                        b.Add(1);
                    else if (a[i] < a[i + 1])
                        b.Add(0);
                    else
                        b.Add(2);
                }

                if (b.Where(o => o == 0).Count() == a.Count - 1 ||
                    b.Where(o => o == 1).Count() == a.Count - 1)
                {
                    int c = 0;
                    for (int j = 0; j < a.Count - 1; j++)
                    {
                        if (Math.Abs(a[j] - a[j + 1]) > 0 &&
                            Math.Abs(a[j] - a[j + 1]) < 4)
                            c++;
                    }

                    if (c == a.Count - 1)
                        res++;
                }
            }

            return res;
        }

        /// <summary>
        /// The engineers are surprised by the low number of safe reports until they realize they forgot to tell you about the Problem Dampener.
        /// The Problem Dampener is a reactor-mounted module that lets the reactor safety systems tolerate a single bad level in what would otherwise be a safe report.
        /// It's like the bad level never happened!
        /// Now, the same rules apply as before, except if removing a single level from an unsafe report would make it safe, the report instead counts as safe.
        /// 
        /// More of the above example's reports are now safe:
        /// 
        /// 7 6 4 2 1: Safe without removing any level.
        /// 1 2 7 8 9: Unsafe regardless of which level is removed.
        /// 9 7 6 2 1: Unsafe regardless of which level is removed.
        /// 1 3 2 4 5: Safe by removing the second level, 3.
        /// 8 6 4 4 1: Safe by removing the third level, 4.
        /// 1 3 6 7 9: Safe without removing any level.
        /// Thanks to the Problem Dampener, 4 reports are actually safe!
        /// 
        /// Update your analysis by handling situations where the Problem Dampener can remove a single level from unsafe reports.How many reports are now safe?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int res = 0;

            foreach (string item in input)
            {
                List<int> a = [.. item.Split(" ").Select(int.Parse)];
                bool b = false;

                for (int j = 0; j < a.Count; j++)
                {
                    List<int> l0 = [];
                    l0.AddRange(a[..j]);
                    l0.AddRange(a[(j + 1)..]);

                    List<int> c = [.. l0];
                    c.Sort();
                    bool dir0 = l0.SequenceEqual(c);
                    c.Reverse();
                    bool dir1 = l0.SequenceEqual(c);
                    bool dir2 = dir0 || dir1;
                    bool d = true;

                    for (int i = 0; i < l0.Count - 1; i++)
                    {
                        int diff = Math.Abs(l0[i] - l0[i + 1]);

                        if (diff < 1 || diff > 3)
                        {
                            d = false;
                            continue;
                        }
                    }

                    if (dir2 && d)
                        b = true;
                }

                if (b)
                    res++;
            }

            return res;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _02_RedNosedReports(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_02_RedNosedReports));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}