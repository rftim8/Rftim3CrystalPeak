using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _12_DigitalPlumber : I_12_DigitalPlumber
    {
        #region Static
        private readonly List<string>? data;

        public _12_DigitalPlumber()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_12_DigitalPlumber));
        }

        /// <summary>
        /// Walking along the memory banks of the stream, you find a small village that is experiencing a little confusion: some programs can't communicate with each other.
        /// 
        /// Programs in this village communicate using a fixed system of pipes.
        /// Messages are passed between programs using these pipes, but most programs aren't connected to each other directly. 
        /// Instead, programs pass messages between each other until the message reaches the intended recipient.
        /// 
        /// For some reason, though, some of these messages aren't ever reaching their intended recipient, and the programs suspect that some pipes are missing.
        /// They would like you to investigate.
        /// 
        /// You walk through the village and record the ID of each program and the IDs with which it can communicate directly(your puzzle input). 
        /// Each program has one or more programs with which it can communicate, and these pipes are bidirectional;
        /// if 8 says it can communicate with 11, then 11 will say it can communicate with 8.
        /// 
        /// You need to figure out how many programs are in the group that contains program ID 0.
        /// 
        /// For example, suppose you go door-to-door like a travelling salesman and record the following list:
        /// 
        /// 0 <-> 2
        /// 1 <-> 1
        /// 2 <-> 0, 3, 4
        /// 3 <-> 2, 4
        /// 4 <-> 2, 3, 6
        /// 5 <-> 6
        /// 6 <-> 4, 5
        /// 
        /// In this example, the following programs are in the group that contains program ID 0:
        /// 
        /// Program 0 by definition.
        /// Program 2, directly connected to program 0.
        /// Program 3 via program 2.
        /// Program 4 via program 2.
        /// Program 5 via programs 6, then 4, then 2.
        /// Program 6 via programs 4, then 2.
        /// Therefore, a total of 6 programs are in this group; all but program 1, which has a pipe that connects it to itself.
        /// 
        /// How many programs are in the group that contains program ID 0?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<PipeProgram> programs = input.Select(x => new PipeProgram(x.Replace(",", ""))).ToList();
            programs.ForEach(x => x.AddConnections(programs));

            return programs.First(x => x.Id == 0).GetGroup().Count;
        }

        /// <summary>
        /// There are more programs than just the ones in the group containing program ID 0.
        /// The rest of them have no way of reaching that group, and still might have no way of reaching each other.
        /// 
        /// A group is a collection of programs that can all communicate via pipes either directly or indirectly.
        /// The programs you identified just a moment ago are all part of the same group. 
        /// Now, they would like you to determine the total number of groups.
        /// In the example above, there were 2 groups: one consisting of programs 0,2,3,4,5,6, and the other consisting solely of program 1.
        /// 
        /// How many groups are there in total?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<PipeProgram> programs = input.Select(x => new PipeProgram(x.Replace(",", ""))).ToList();
            programs.ForEach(x => x.AddConnections(programs));

            int groupCount = 0;

            while (programs.Count != 0)
            {
                List<PipeProgram> group = programs.First().GetGroup();
                programs.RemoveAll(group.Contains);
                groupCount++;
            }

            return groupCount;
        }

        private class PipeProgram
        {
            public int Id { get; set; }
            public string Input { get; set; }
            public List<PipeProgram> Connections { get; set; }

            public PipeProgram(string input)
            {
                List<string> words = [.. input.Split(' ')];
                Connections = [];

                Id = int.Parse(words[0]);
                Input = input;
            }

            public void AddConnections(List<PipeProgram> pipeList)
            {
                List<string> words = [.. Input.Split(' ')];

                for (var i = 2; i < words.Count; i++)
                {
                    int connectionId = int.Parse(words[i]);
                    PipeProgram connectedProgram = pipeList.First(x => x.Id == connectionId);

                    AddConnection(connectedProgram);
                    connectedProgram.AddConnection(this);
                }
            }

            private void AddConnection(PipeProgram connectedProgram)
            {
                if (!Connections.Contains(connectedProgram)) Connections.Add(connectedProgram);
            }

            private void GetGroup(List<PipeProgram> groupPrograms)
            {
                groupPrograms.Add(this);

                foreach (PipeProgram c in Connections)
                {
                    if (!groupPrograms.Contains(c)) c.GetGroup(groupPrograms);
                }
            }

            public List<PipeProgram> GetGroup()
            {
                List<PipeProgram> groupPrograms = new List<PipeProgram>();
                GetGroup(groupPrograms);

                return groupPrograms;
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _12_DigitalPlumber(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_12_DigitalPlumber));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}