using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _02_Dive : I_02_Dive
    {
        #region Static
        private readonly List<string>? data;

        public _02_Dive()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_02_Dive));
        }

        /// <summary>
        /// Now, you need to figure out how to pilot this thing.
        /// 
        /// It seems like the submarine can take a series of commands like forward 1, down 2, or up 3:
        /// 
        /// forward X increases the horizontal position by X units.
        /// down X increases the depth by X units.
        /// up X decreases the depth by X units.
        /// Note that since you're on a submarine, down and up affect your depth, and so they have the opposite result of what you might expect.
        /// 
        /// The submarine seems to already have a planned course (your puzzle input). 
        /// You should probably figure out where it's going. For example:
        /// 
        /// forward 5
        /// down 5
        /// forward 8
        /// up 3
        /// down 8
        /// forward 2
        /// Your horizontal position and depth both start at 0. The steps above would then modify them as follows:
        /// 
        /// forward 5 adds 5 to your horizontal position, a total of 5.
        /// down 5 adds 5 to your depth, resulting in a value of 5.
        /// forward 8 adds 8 to your horizontal position, a total of 13.
        /// up 3 decreases your depth by 3, resulting in a value of 2.
        /// down 8 adds 8 to your depth, resulting in a value of 10.
        /// forward 2 adds 2 to your horizontal position, a total of 15.
        /// After following these instructions, you would have a horizontal position of 15 and a depth of 10. (Multiplying these together produces 150.)
        /// 
        /// Calculate the horizontal position and depth you would have after following the planned course.
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int horizontal = 0;
            int vertical = 0;

            foreach (string item in input)
            {
                if (item.Split(' ')[0] == "up") vertical -= int.Parse(item.Split(' ')[1]);
                else if (item.Split(' ')[0] == "down") vertical += int.Parse(item.Split(' ')[1]);
                else if (item.Split(' ')[0] == "forward") horizontal += int.Parse(item.Split(' ')[1]);
            }

            return horizontal * vertical;
        }

        /// <summary>
        /// Based on your calculations, the planned course doesn't seem to make any sense.
        /// You find the submarine manual and discover that the process is actually slightly more complicated.
        /// 
        /// In addition to horizontal position and depth, you'll also need to track a third value, aim, which also starts at 0. 
        /// The commands also mean something entirely different than you first thought:
        /// 
        /// down X increases your aim by X units.
        /// up X decreases your aim by X units.
        /// forward X does two things:
        /// It increases your horizontal position by X units.
        /// It increases your depth by your aim multiplied by X.
        /// Again note that since you're on a submarine, down and up do the opposite of what you might expect: "down" means aiming in the positive direction.
        /// 
        /// Now, the above example does something different:
        /// 
        /// forward 5 adds 5 to your horizontal position, a total of 5. Because your aim is 0, your depth does not change.
        /// down 5 adds 5 to your aim, resulting in a value of 5.
        /// forward 8 adds 8 to your horizontal position, a total of 13. Because your aim is 5, your depth increases by 8*5=40.
        /// up 3 decreases your aim by 3, resulting in a value of 2.
        /// down 8 adds 8 to your aim, resulting in a value of 10.
        /// forward 2 adds 2 to your horizontal position, a total of 15. Because your aim is 10, your depth increases by 2*10=20 to a total of 60.
        /// After following these new instructions, you would have a horizontal position of 15 and a depth of 60. (Multiplying these produces 900.)
        /// 
        /// Using this new interpretation of the commands, calculate the horizontal position and depth you would have after following the planned course.
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            long horizontal = 0;
            long aim = 0;
            long depth = 0;

            foreach (string item in input)
            {
                if (item.Split(' ')[0] == "up") aim -= int.Parse(item.Split(' ')[1]);
                else if (item.Split(' ')[0] == "down") aim += int.Parse(item.Split(' ')[1]);
                else if (item.Split(' ')[0] == "forward")
                {
                    horizontal += int.Parse(item.Split(' ')[1]);
                    depth += aim * int.Parse(item.Split(' ')[1]);
                }
            }

            return horizontal * depth;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _02_Dive(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_02_Dive));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}