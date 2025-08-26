using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _12_RainRisk : I_12_RainRisk
    {
        #region Static
        private readonly List<string>? data;

        public _12_RainRisk()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_12_RainRisk));
        }

        /// <summary>
        /// Your ferry made decent progress toward the island, but the storm came in faster than anyone expected. The ferry needs to take evasive actions!
        /// 
        /// Unfortunately, the ship's navigation computer seems to be malfunctioning; rather than giving a route directly to safety,
        /// it produced extremely circuitous instructions. When the captain uses the PA system to ask if anyone can help, you quickly volunteer.
        /// 
        /// The navigation instructions(your puzzle input) consists of a sequence of single-character actions paired with integer input values.
        /// After staring at them for a few minutes, you work out what they probably mean:
        /// 
        /// Action N means to move north by the given value.
        /// Action S means to move south by the given value.
        /// Action E means to move east by the given value.
        /// Action W means to move west by the given value.
        /// Action L means to turn left the given number of degrees.
        /// Action R means to turn right the given number of degrees.
        /// Action F means to move forward by the given value in the direction the ship is currently facing.
        /// The ship starts by facing east. Only the L and R actions change the direction the ship is facing.
        /// (That is, if the ship is facing east and the next instruction is N10, the ship would move north 10 units, but would still move east if the following action were F.)
        /// 
        /// For example:
        /// 
        /// F10
        /// N3
        /// F7
        /// R90
        /// F11
        /// These instructions would be handled as follows:
        /// 
        /// F10 would move the ship 10 units east(because the ship starts by facing east) to east 10, north 0.
        /// N3 would move the ship 3 units north to east 10, north 3.
        /// F7 would move the ship another 7 units east(because the ship is still facing east) to east 17, north 3.
        /// R90 would cause the ship to turn right by 90 degrees and face south; it remains at east 17, north 3.
        /// F11 would move the ship 11 units south to east 17, south 8.
        /// At the end of these instructions, the ship's Manhattan distance (sum of the absolute values of its east/west position and its north/south position) 
        /// from its starting position is 17 + 8 = 25.
        /// 
        /// Figure out where the navigation instructions lead.What is the Manhattan distance between that location and the ship's starting position?
        /// </summary>
        [Benchmark]
        public double PartOne() => PartOne0(data!);

        private static double PartOne0(List<string> input)
        {
            double x = 0;
            double y = 0;
            int a = 0;
            foreach ((char c, int val) in from string l in input
                                          let c = l[0]
                                          let val = int.Parse(l[1..])
                                          select (c, val))
            {
                //Console.WriteLine($"X: {x}, Y: {y}, Manhattan {Math.Round(Math.Abs(x) + Math.Abs(y))}");
                switch (c)
                {
                    case 'N': y += val; break;
                    case 'S': y -= val; break;
                    case 'E': x += val; break;
                    case 'W': x -= val; break;
                    case 'R': a -= val; break;
                    case 'L': a += val; break;
                    case 'F':
                        x += Math.Cos(a * Math.PI / 180) * val;
                        y += Math.Sin(a * Math.PI / 180) * val;
                        break;
                    default:
                        throw new Exception();
                }
            }

            //Console.WriteLine($"X: {x}, Y: {y}, Manhattan {Math.Round(Math.Abs(x) + Math.Abs(y))}");

            return Math.Round(Math.Abs(x) + Math.Abs(y));
        }

        /// <summary>
        /// Before you can give the destination to the captain, you realize that the actual action meanings were printed on the back of the instructions the whole time.
        /// 
        /// Almost all of the actions indicate how to move a waypoint which is relative to the ship's position:
        /// 
        /// Action N means to move the waypoint north by the given value.
        /// Action S means to move the waypoint south by the given value.
        /// Action E means to move the waypoint east by the given value.
        /// Action W means to move the waypoint west by the given value.
        /// Action L means to rotate the waypoint around the ship left (counter-clockwise) the given number of degrees.
        /// Action R means to rotate the waypoint around the ship right(clockwise) the given number of degrees.
        /// Action F means to move forward to the waypoint a number of times equal to the given value.
        /// The waypoint starts 10 units east and 1 unit north relative to the ship.
        /// The waypoint is relative to the ship; that is, if the ship moves, the waypoint moves with it.
        /// 
        /// For example, using the same instructions as above:
        /// 
        /// F10 moves the ship to the waypoint 10 times(a total of 100 units east and 10 units north), leaving the ship at east 100, north 10.
        /// The waypoint stays 10 units east and 1 unit north of the ship.
        /// N3 moves the waypoint 3 units north to 10 units east and 4 units north of the ship.The ship remains at east 100, north 10.
        /// F7 moves the ship to the waypoint 7 times(a total of 70 units east and 28 units north), leaving the ship at east 170, north 38. 
        /// The waypoint stays 10 units east and 4 units north of the ship.
        /// R90 rotates the waypoint around the ship clockwise 90 degrees, moving it to 4 units east and 10 units south of the ship.
        /// The ship remains at east 170, north 38.
        /// F11 moves the ship to the waypoint 11 times(a total of 44 units east and 110 units south), leaving the ship at east 214, south 72. 
        /// The waypoint stays 4 units east and 10 units south of the ship.
        /// After these operations, the ship's Manhattan distance from its starting position is 214 + 72 = 286.
        /// 
        /// Figure out where the navigation instructions actually lead.What is the Manhattan distance between that location and the ship's starting position?
        /// </summary>        
        [Benchmark]
        public double PartTwo() => PartTwo0(data!);

        private static double PartTwo0(List<string> input)
        {
            double x = 0;
            double y = 0;
            double wpX = 10;
            double wpY = 1;
            foreach ((char c, int val, double oX, double oY) in from string l in input
                                                                let c = l[0]
                                                                let val = int.Parse(l[1..])
                                                                let oX = wpX
                                                                let oY = wpY
                                                                select (c, val, oX, oY))
            {
                switch (c)
                {
                    case 'N': wpY += val; break;
                    case 'S': wpY -= val; break;
                    case 'E': wpX += val; break;
                    case 'W': wpX -= val; break;
                    case 'R':

                        wpX = oX * Math.Cos(-val * Math.PI / 180) - oY * Math.Sin(-val * Math.PI / 180);
                        wpY = oX * Math.Sin(-val * Math.PI / 180) + oY * Math.Cos(-val * Math.PI / 180);
                        break;
                    case 'L':
                        wpX = oX * Math.Cos(val * Math.PI / 180) - oY * Math.Sin(val * Math.PI / 180);
                        wpY = oX * Math.Sin(val * Math.PI / 180) + oY * Math.Cos(val * Math.PI / 180);
                        break;
                    case 'F':
                        x += wpX * val;
                        y += wpY * val;
                        break;
                    default:
                        throw new Exception();
                }
            }

            //Console.WriteLine($"X: {x}, Y: {y}, Manhattan {Math.Round(Math.Abs(x) + Math.Abs(y))}");

            return Math.Round(Math.Abs(x) + Math.Abs(y));
        }
        #endregion

        #region UnitTest
        public static double PartOne_Test(List<string> data) => PartOne0(data);

        public static double PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _12_RainRisk(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_12_RainRisk));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}