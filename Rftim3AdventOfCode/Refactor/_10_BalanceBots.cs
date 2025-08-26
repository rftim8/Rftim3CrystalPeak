using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _10_BalanceBots : I_10_BalanceBots
    {
        #region Static
        private readonly List<string>? data;

        public _10_BalanceBots()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_10_BalanceBots));
        }

        /// <summary>
        /// You come upon a factory in which many robots are zooming around handing small microchips to each other.
        /// 
        /// Upon closer examination, you notice that each bot only proceeds when it has two microchips, and once it does, 
        /// it gives each one to a different bot or puts it in a marked "output" bin.Sometimes, bots take microchips from "input" bins, too.
        /// 
        /// Inspecting one of the microchips, it seems like they each contain a single number; the bots must use some logic to decide what to do with each chip.
        /// You access the local control computer and download the bots' instructions (your puzzle input).
        /// 
        /// Some of the instructions specify that a specific-valued microchip should be given to a specific bot;
        /// the rest of the instructions indicate what a given bot should do with its lower-value or higher-value chip.
        /// 
        /// For example, consider the following instructions:
        /// 
        /// value 5 goes to bot 2
        /// bot 2 gives low to bot 1 and high to bot 0
        /// value 3 goes to bot 1
        /// bot 1 gives low to output 1 and high to bot 0
        /// bot 0 gives low to output 2 and high to output 0
        /// value 2 goes to bot 2
        /// Initially, bot 1 starts with a value-3 chip, and bot 2 starts with a value-2 chip and a value-5 chip.
        /// Because bot 2 has two microchips, it gives its lower one (2) to bot 1 and its higher one(5) to bot 0.
        /// Then, bot 1 has two microchips; it puts the value-2 chip in output 1 and gives the value-3 chip to bot 0.
        /// Finally, bot 0 has two microchips; it puts the 3 in output 2 and the 5 in output 0.
        /// In the end, output bin 0 contains a value-5 microchip, output bin 1 contains a value-2 microchip, and output bin 2 contains a value-3 microchip.
        /// In this configuration, bot number 2 is responsible for comparing value-5 microchips with value-2 microchips.
        /// Based on your instructions, what is the number of the bot that is responsible for comparing value-61 microchips with value-17 microchips?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;
            Dictionary<int, Action<int>> bots = [];
            int[] outputs = new int[21];

            Regex regex = MyRegex();

            foreach (string? line in input.OrderBy(x => x))
            {
                Match match = regex.Match(line);
                if (match.Groups["value"].Success) bots[int.Parse(match.Groups["bot"].Value)](int.Parse(match.Groups["value"].Value));
                if (match.Groups["source"].Success)
                {
                    List<int> vals = [];
                    int botnum = int.Parse(match.Groups["source"].Value);
                    bots[botnum] = (n) =>
                    {
                        vals.Add(n);
                        if (vals.Count == 2)
                        {
                            if (vals.Min() == 17 && vals.Max() == 61) r = botnum;

                            if (match.Groups["low"].Value == "bot") bots[int.Parse(match.Groups["lowval"].Value)](vals.Min());
                            else outputs[int.Parse(match.Groups["lowval"].Value)] = vals.Min();

                            if (match.Groups["high"].Value == "bot") bots[int.Parse(match.Groups["highval"].Value)](vals.Max());
                            else outputs[int.Parse(match.Groups["highval"].Value)] = vals.Max();
                        }
                    };
                }
            }

            return r;
        }

        /// <summary>
        /// What do you get if you multiply together the values of one chip in each of outputs 0, 1, and 2?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;
            Dictionary<int, Action<int>> bots = [];
            int[] outputs = new int[21];

            Regex regex = MyRegex();

            foreach (string? line in input.OrderBy(x => x))
            {
                Match match = regex.Match(line);
                if (match.Groups["value"].Success) bots[int.Parse(match.Groups["bot"].Value)](int.Parse(match.Groups["value"].Value));
                if (match.Groups["source"].Success)
                {
                    List<int> vals = [];
                    int botnum = int.Parse(match.Groups["source"].Value);
                    bots[botnum] = (n) =>
                    {
                        vals.Add(n);
                        if (vals.Count == 2)
                        {
                            if (vals.Min() == 17 && vals.Max() == 61) r = botnum;

                            if (match.Groups["low"].Value == "bot") bots[int.Parse(match.Groups["lowval"].Value)](vals.Min());
                            else outputs[int.Parse(match.Groups["lowval"].Value)] = vals.Min();

                            if (match.Groups["high"].Value == "bot") bots[int.Parse(match.Groups["highval"].Value)](vals.Max());
                            else outputs[int.Parse(match.Groups["highval"].Value)] = vals.Max();
                        }
                    };
                }
            }

            r = outputs[0] * outputs[1] * outputs[2];

            return r;
        }

        [GeneratedRegex(@"value (?<value>\d+) goes to bot (?<bot>\d+)|bot (?<source>\d+) gives low to (?<low>(bot|output)) (?<lowval>\d+) and high to (?<high>(bot|output)) (?<highval>\d+)")]
        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _10_BalanceBots(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_10_BalanceBots));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}