using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using System.Text;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3AdventOfCode
{
    public partial class _07_TheSumOfItsParts : I_07_TheSumOfItsParts
    {
        #region Static
        private readonly List<string>? data;

        public _07_TheSumOfItsParts()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_TheSumOfItsParts));
        }

        /// <summary>
        /// You find yourself standing on a snow-covered coastline; apparently, you landed a little off course. 
        /// The region is too hilly to see the North Pole from here, but you do spot some Elves that seem to be trying to unpack something that washed ashore.
        /// It's quite cold out, so you decide to risk creating a paradox by asking them for directions.
        /// 
        /// "Oh, are you the search party?" Somehow, you can understand whatever Elves from the year 1018 speak; you assume it's Ancient Nordic Elvish. 
        /// Could the device on your wrist also be a translator? "Those clothes don't look very warm; take this." They hand you a heavy coat.
        /// 
        /// "We do need to find our way back to the North Pole, but we have higher priorities at the moment.
        /// You see, believe it or not, this box contains something that will solve all of Santa's transportation problems - at least, 
        /// that's what it looks like from the pictures in the instructions." It doesn't seem like they can read whatever language it's in, 
        /// but you can: "Sleigh kit. Some assembly required."
        /// 
        /// "'Sleigh'? What a wonderful name! You must help us assemble this 'sleigh' at once!" They start excitedly pulling more parts out of the box.
        /// 
        /// The instructions specify a series of steps and requirements about which steps must be finished before others can begin (your puzzle input). 
        /// Each step is designated by a single letter. For example, suppose you have the following instructions:
        /// 
        /// Step C must be finished before step A can begin.
        /// Step C must be finished before step F can begin.
        /// Step A must be finished before step B can begin.
        /// Step A must be finished before step D can begin.
        /// Step B must be finished before step E can begin.
        /// Step D must be finished before step E can begin.
        /// Step F must be finished before step E can begin.
        /// Visually, these requirements look like this:
        /// 
        ///   -->A--->B--
        ///  /    \      \
        /// C      -->D----->E
        ///  \           /
        ///   ---->F-----
        /// Your first goal is to determine the order in which the steps should be completed. 
        /// If more than one step is ready, choose the step which is first alphabetically. In this example, the steps would be completed as follows:
        /// 
        /// Only C is available, and so it is done first.
        /// Next, both A and F are available. A is first alphabetically, so it is done next.
        /// Then, even though F was available earlier, steps B and D are now also available, and B is the first alphabetically of the three.
        /// After that, only D and F are available. E is not available because only some of its prerequisites are complete. Therefore, D is completed next.
        /// F is the only choice, so it is done next.
        /// Finally, E is completed.
        /// So, in this example, the correct order is CABDFE.
        /// 
        /// In what order should the steps in your instructions be completed?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            List<Step> steps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => new Step { Name = c }).ToList();
            Step? next = null;
            char before = '\0', after = '\0';
            foreach (string line in input)
            {
                MatchCollection matches = MyRegex().Matches(line);
                before = char.Parse(matches[0].Value);
                after = char.Parse(matches[1].Value);

                steps.First(s => s.Name == after).Before.Add(before);
            }

            StringBuilder result = new();
            while (steps.Count > 0)
            {
                next = steps.Where(s => s.Before.Count == 0).OrderBy(s => s.Name).First();
                result.Append(next.Name);
                steps.Remove(next);
                steps.ForEach(s => s.Before.Remove(next.Name));
            }

            return result.ToString();
        }

        /// <summary>
        /// As you're about to begin construction, four of the Elves offer to help. "The sun will set soon; it'll go faster if we work together."
        /// Now, you need to account for multiple people working on steps simultaneously. If multiple steps are available, workers should still begin them in alphabetical order.
        /// 
        /// Each step takes 60 seconds plus an amount corresponding to its letter: A=1, B=2, C=3, and so on.
        /// So, step A takes 60+1=61 seconds, while step Z takes 60+26=86 seconds.No time is required between steps.
        /// 
        /// To simplify things for the example, however, suppose you only have help from one Elf (a total of two workers) and 
        /// that each step takes 60 fewer seconds(so that step A takes 1 second and step Z takes 26 seconds). 
        /// Then, using the same instructions as above, this is how each second would be spent:
        /// 
        /// Second Worker 1   Worker 2   Done
        ///    0        C.
        ///    1        C.
        ///    2        C.
        ///    3        A F       C
        ///    4        B F       CA
        ///    5        B F       CA
        ///    6        D F       CAB
        ///    7        D F       CAB
        ///    8        D F       CAB
        ///    9        D.CABF
        ///   10        E.CABFD
        ///   11        E.CABFD
        ///   12        E.CABFD
        ///   13        E.CABFD
        ///   14        E.CABFD
        ///   15        .          .       CABFDE
        /// Each row represents one second of time.The Second column identifies how many seconds have passed as of the beginning of that second.
        /// Each worker column shows the step that worker is currently doing (or. if they are idle). The Done column shows completed steps.
        /// 
        /// Note that the order of the steps has changed; this is because steps now take time to finish and multiple workers can begin multiple steps simultaneously.
        /// 
        /// In this example, it would take 15 seconds for two workers to complete these steps.
        /// 
        /// With 5 workers and the 60+ second step durations described above, how long will it take to complete all of the steps?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<Step> steps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select((c, i) => new Step { Name = c, Time = 61 + i }).ToList();
            List<Step> next;
            char before = '\0', after = '\0';
            int workers = 5;
            int sec = 0;
            foreach (string line in input)
            {
                MatchCollection matches = MyRegex().Matches(line);
                before = char.Parse(matches[0].Value);
                after = char.Parse(matches[1].Value);

                steps.First(s => s.Name == after).Before.Add(before);
            }

            while (steps.Count > 0)
            {
                next = steps.Where(s => s.Before.Count == 0).OrderBy(s => s.Time).Take(workers).ToList();
                next.ForEach(s => s.Time--);
                steps.ForEach(s => s.Before.RemoveAll(n => steps.Where(p => p.Time == 0).Select(p => p.Name).Contains(n)));
                steps.RemoveAll(s => s.Time == 0);
                sec++;
            }

            return sec;
        }

        private class Step
        {
            public char Name { get; set; }

            public int Time { get; set; }
            public List<char> Before { get; set; } = [];
        }

        [GeneratedRegex(@"\b[A-Z]\b")]
        private static partial Regex MyRegex();
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _07_TheSumOfItsParts(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_TheSumOfItsParts));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}