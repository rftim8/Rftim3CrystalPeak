using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _20_FirewallRules : I_20_FirewallRules
    {
        #region Static
        private readonly List<string>? data;

        public _20_FirewallRules()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_20_FirewallRules));
        }

        /// <summary>
        /// You'd like to set up a small hidden computer here so you can use it to get back into the network later. 
        /// However, the corporate firewall only allows communication with certain external IP addresses.
        /// 
        /// You've retrieved the list of blocked IPs from the firewall, but the list seems to be messy and poorly maintained, and it's not clear which IPs are allowed.
        /// Also, rather than being written in dot-decimal notation, they are written as plain 32-bit integers, which can have any value from 0 through 4294967295, inclusive.
        /// For example, suppose only the values 0 through 9 were valid, and that you retrieved the following blacklist:
        /// 
        /// 5-8
        /// 0-2
        /// 4-7
        /// The blacklist specifies ranges of IPs(inclusive of both the start and end value) that are not allowed.
        /// Then, the only IPs that this firewall allows are 3 and 9, since those are the only numbers not in any range.
        /// 
        /// Given the list of blocked IPs you retrieved from the firewall (your puzzle input), what is the lowest-valued IP that is not blocked?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            List<List<long>> blockedRanges = [];
            foreach (string line in input)
            {
                blockedRanges.Add([]);
                foreach (string part in line.Trim().Split('-'))
                {
                    blockedRanges[^1].Add(long.Parse(part));
                }
            }

            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int index = 0; index < blockedRanges.Count - 1; index++)
                {
                    if (blockedRanges[index][0] > blockedRanges[index + 1][0])
                    {
                        List<long> holder = blockedRanges[index];
                        blockedRanges.RemoveAt(index);
                        blockedRanges.Insert(index + 1, holder);
                        sorted = false;
                    }
                }
            }

            long validCount = 0;
            int startIndex = 0;
            long lowestIP = -1;
            for (long testIP = 0; testIP < 4294967295; testIP++)
            {
                bool inRange = false;
                for (int rangeIndex = startIndex; rangeIndex < blockedRanges.Count && !inRange; rangeIndex++)
                {
                    if (testIP >= blockedRanges[rangeIndex][0] && testIP <= blockedRanges[rangeIndex][1])
                    {
                        inRange = true;
                        startIndex = rangeIndex;
                        testIP = blockedRanges[rangeIndex][1];
                    }
                }
                if (!inRange)
                {
                    if (validCount == 0) lowestIP = testIP;

                    validCount++;
                }
            }

            return lowestIP;
        }

        /// <summary>
        /// How many IPs are allowed by the blacklist?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            List<List<long>> blockedRanges = [];
            foreach (string line in input)
            {
                blockedRanges.Add([]);
                foreach (string part in line.Trim().Split('-'))
                {
                    blockedRanges[^1].Add(long.Parse(part));
                }
            }

            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int index = 0; index < blockedRanges.Count - 1; index++)
                {
                    if (blockedRanges[index][0] > blockedRanges[index + 1][0])
                    {
                        List<long> holder = blockedRanges[index];
                        blockedRanges.RemoveAt(index);
                        blockedRanges.Insert(index + 1, holder);
                        sorted = false;
                    }
                }
            }

            long validCount = 0;
            int startIndex = 0;
            long lowestIP = -1;
            for (long testIP = 0; testIP < 4294967295; testIP++)
            {
                bool inRange = false;
                for (int rangeIndex = startIndex; rangeIndex < blockedRanges.Count && !inRange; rangeIndex++)
                {
                    if (testIP >= blockedRanges[rangeIndex][0] && testIP <= blockedRanges[rangeIndex][1])
                    {
                        inRange = true;
                        startIndex = rangeIndex;
                        testIP = blockedRanges[rangeIndex][1];
                    }
                }
                if (!inRange)
                {
                    if (validCount == 0) lowestIP = testIP;

                    validCount++;
                }
            }

            return validCount;
        }
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _20_FirewallRules(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_20_FirewallRules));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}