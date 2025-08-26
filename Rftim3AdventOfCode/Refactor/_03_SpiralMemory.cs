using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_SpiralMemory : I_03_SpiralMemory
    {
        #region Static
        private readonly List<string>? data;

        public _03_SpiralMemory()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_SpiralMemory));
        }

        /// <summary>
        /// You come across an experimental new kind of memory stored on an infinite two-dimensional grid.
        /// 
        /// Each square on the grid is allocated in a spiral pattern starting at a location marked 1 and then counting up while spiraling outward.
        /// For example, the first few squares are allocated like this:
        /// 
        /// 17  16  15  14  13
        /// 18   5   4   3  12
        /// 19   6   1   2  11
        /// 20   7   8   9  10
        /// 21  22  23---> ...
        /// 
        /// While this is very space-efficient (no squares are skipped), requested data must be carried back to square 1 
        /// (the location of the only access port for this memory system) by programs that can only move up, down, left, or right.
        /// They always take the shortest path: the Manhattan Distance between the location of the data and square 1.
        /// 
        /// For example:
        /// 
        /// Data from square 1 is carried 0 steps, since it's at the access port.
        /// Data from square 12 is carried 3 steps, such as: down, left, left.
        ///         Data from square 23 is carried only 2 steps: up twice.
        /// Data from square 1024 must be carried 31 steps.
        /// How many steps are required to carry the data from the square identified in your puzzle input all the way to the access port?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int n = int.Parse(input[0]);

            int x = 0;
            int y = 0;

            int stepCount = 1;
            bool stepCountChange = true;
            int direction = 0;

            for (int i = 1; ;)
            {
                for (int j = 0; j < stepCount; j += 1)
                {
                    switch (direction)
                    {
                        case 0:
                            x += 1;
                            break;
                        case 1:
                            y += 1;
                            break;
                        case 2:
                            x -= 1;
                            break;
                        case 3:
                            y -= 1;
                            break;
                        default:
                            break;
                    }

                    i += 1;

                    if (i == n) goto EndOfLoop;
                }

                direction = (direction + 1) % 4;
                stepCountChange = !stepCountChange;
                if (stepCountChange) stepCount += 1;
            }
        EndOfLoop:
            int l1distance = Math.Abs(x) + Math.Abs(y);

            //Console.WriteLine($"f({n}) = ({x},{y}), |f({n})| = {l1distance}");

            return l1distance;
        }

        /// <summary>
        /// As a stress test on the system, the programs here clear the grid and then store the value 1 in square 1. 
        /// Then, in the same allocation order as shown above, they store the sum of the values in all adjacent squares, including diagonals.
        /// 
        /// So, the first few squares' values are chosen as follows:
        /// 
        /// Square 1 starts with the value 1.
        /// Square 2 has only one adjacent filled square(with value 1), so it also stores 1.
        /// Square 3 has both of the above squares as neighbors and stores the sum of their values, 2.
        /// Square 4 has all three of the aforementioned squares as neighbors and stores the sum of their values, 4.
        /// Square 5 only has the first and fourth squares as neighbors, so it gets the value 5.
        /// Once a square is written, its value does not change.
        /// Therefore, the first few squares would receive the following values:
        /// 
        /// 147  142  133  122   59
        /// 304    5    4    2   57
        /// 330   10    1    1   54
        /// 351   11   23   25   26
        /// 362  747  806--->   ...
        /// 
        /// What is the first value written that is larger than your puzzle input?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int n = int.Parse(input[0]);

            int x = 0;
            int y = 0;

            int stepCount = 1;
            bool stepCountChange = true;
            int direction = 0;
            Dictionary<string, int> values = new()
            {
                ["0,0"] = 1
            };

            for (; ; )
            {
                for (int j = 0; j < stepCount; j += 1)
                {
                    switch (direction)
                    {
                        case 0:
                            x += 1;
                            break;
                        case 1:
                            y += 1;
                            break;
                        case 2:
                            x -= 1;
                            break;
                        case 3:
                            y -= 1;
                            break;
                        default:
                            break;
                    }

                    int sum = 0;

                    if (values.TryGetValue(string.Format("{0},{1}", x + 1, y), out int val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x + 1, y + 1), out val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x, y + 1), out val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x - 1, y + 1), out val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x - 1, y), out val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x - 1, y - 1), out val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x, y - 1), out val)) sum += val;
                    if (values.TryGetValue(string.Format("{0},{1}", x + 1, y - 1), out val)) sum += val;

                    if (sum > n) return sum;
                    values[string.Format("{0},{1}", x, y)] = sum;
                }

                direction = (direction + 1) % 4;
                stepCountChange = !stepCountChange;
                if (stepCountChange) stepCount += 1;
            }
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _03_SpiralMemory(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_SpiralMemory));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}