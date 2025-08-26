using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _11_ChronalCharge : I_11_ChronalCharge
    {
        #region Static
        private readonly List<string>? data;

        public _11_ChronalCharge()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_11_ChronalCharge));
        }

        /// <summary>
        /// You watch the Elves and their sleigh fade into the distance as they head toward the North Pole.
        /// 
        /// Actually, you're the one fading. The falling sensation returns.
        /// 
        /// The low fuel warning light is illuminated on your wrist-mounted device.Tapping it once causes it to project a hologram of the situation:
        /// a 300x300 grid of fuel cells and their current power levels, some negative. You're not sure what negative power means in the context of time travel, but it can't be good.
        /// 
        /// Each fuel cell has a coordinate ranging from 1 to 300 in both the X (horizontal) and Y (vertical) direction.
        /// In X, Y notation, the top-left cell is 1,1, and the top-right cell is 300,1.
        /// 
        /// The interface lets you select any 3x3 square of fuel cells.To increase your chances of getting to your destination, 
        /// you decide to choose the 3x3 square with the largest total power.
        /// 
        /// The power level in a given fuel cell can be found through the following process:
        /// 
        /// Find the fuel cell's rack ID, which is its X coordinate plus 10.
        /// Begin with a power level of the rack ID times the Y coordinate.
        /// Increase the power level by the value of the grid serial number(your puzzle input).
        /// Set the power level to itself multiplied by the rack ID.
        /// Keep only the hundreds digit of the power level(so 12345 becomes 3; numbers with no hundreds digit become 0).
        /// Subtract 5 from the power level.
        /// For example, to find the power level of the fuel cell at 3,5 in a grid with serial number 8:
        /// 
        /// The rack ID is 3 + 10 = 13.
        /// The power level starts at 13 * 5 = 65.
        /// Adding the serial number produces 65 + 8 = 73.
        /// Multiplying by the rack ID produces 73 * 13 = 949.
        /// The hundreds digit of 949 is 9.
        /// Subtracting 5 produces 9 - 5 = 4.
        /// So, the power level of this fuel cell is 4.
        /// 
        /// Here are some more example power levels:
        /// 
        /// Fuel cell at  122,79, grid serial number 57: power level -5.
        /// Fuel cell at 217,196, grid serial number 39: power level  0.
        /// Fuel cell at 101,153, grid serial number 71: power level  4.
        /// Your goal is to find the 3x3 square which has the largest total power. The square must be entirely within the 300x300 grid.
        /// Identify this square using the X,Y coordinate of its top-left fuel cell.For example:
        /// 
        /// For grid serial number 18, the largest total 3x3 square has a top-left corner of 33,45 (with a total power of 29); 
        /// these fuel cells appear in the middle of this 5x5 region:
        /// 
        /// -2  -4   4   4   4
        /// -4   4   4   4  -5
        ///  4   3   3   4  -4
        ///  1   1   2   4  -3
        /// -1   0   2  -5  -2
        /// For grid serial number 42, the largest 3x3 square's top-left is 21,61 (with a total power of 30); they are in the middle of this region:
        /// 
        /// -3   4   2   2   2
        /// -4   4   3   3   4
        /// -5   3   3   4  -4
        ///  4   3   3   4  -3
        ///  3   3   3  -5  -1
        /// What is the X, Y coordinate of the top-left fuel cell of the 3x3 square with the largest total power?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            int gridID = int.Parse(input[0]);
            (int x, int y, int size, int power) maxSquare = (0, 0, 0, 0);
            (int[] squares, int[] rows, int[] cols)[,] grid = new (int[], int[], int[])[300, 300];
            for (int x = 300; x > 0; x--)
            {
                for (int y = 300; y > 0; y--)
                {
                    int score = ((x + 10) * y + gridID) * (x + 10) / 100 % 10 - 5;
                    int[] squares = new int[300], rows = new int[300], cols = new int[300];
                    for (int size = 0; size < (1 == 1 ? 3 : 300); size++)
                    {
                        if (x - 1 + size < 300) rows[size] = size == 0 ? score : grid[x, y - 1].rows[size - 1] + score;
                        if (y - 1 + size < 300) cols[size] = size == 0 ? score : grid[x - 1, y].cols[size - 1] + score;
                        if (x - 1 + size < 300 && y - 1 + size < 300) squares[size] = size == 0 ? score : grid[x, y].squares[size - 1] + rows[size] + cols[size] - score;

                        grid[x - 1, y - 1] = (squares, rows, cols);

                        if (squares[size] > maxSquare.power) maxSquare = (x, y, size + 1, squares[size]);
                    }
                }
            }

            //Console.WriteLine(("{0},{1}" + (1 == 2 ? ",{2}" : ""), maxSquare.x, maxSquare.y, maxSquare.size));
            return $"{maxSquare.x},{maxSquare.y}";
        }

        /// <summary>
        /// You discover a dial on the side of the device; it seems to let you select a square of any size, not just 3x3. Sizes from 1x1 to 300x300 are supported.
        /// 
        /// Realizing this, you now must find the square of any size with the largest total power. 
        /// Identify this square by including its size as a third parameter after the top-left coordinate: a 9x9 square with a top-left corner of 3,5 is identified as 3,5,9.
        /// 
        /// For example:
        /// 
        /// For grid serial number 18, the largest total square (with a total power of 113) is 16x16 and has a top-left corner of 90,269, so its identifier is 90,269,16.
        /// For grid serial number 42, the largest total square (with a total power of 119) is 12x12 and has a top-left corner of 232,251, so its identifier is 232,251,12.
        /// What is the X, Y, size identifier of the square with the largest total power?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            int gridID = int.Parse(input[0]);
            (int x, int y, int size, int power) maxSquare = (0, 0, 0, 0);
            (int[] squares, int[] rows, int[] cols)[,] grid = new (int[], int[], int[])[300, 300];
            for (int x = 300; x > 0; x--)
            {
                for (int y = 300; y > 0; y--)
                {
                    int score = ((x + 10) * y + gridID) * (x + 10) / 100 % 10 - 5;
                    int[] squares = new int[300], rows = new int[300], cols = new int[300];
                    for (int size = 0; size < (2 == 1 ? 3 : 300); size++)
                    {
                        if (x - 1 + size < 300) rows[size] = size == 0 ? score : grid[x, y - 1].rows[size - 1] + score;
                        if (y - 1 + size < 300) cols[size] = size == 0 ? score : grid[x - 1, y].cols[size - 1] + score;
                        if (x - 1 + size < 300 && y - 1 + size < 300) squares[size] = size == 0 ? score : grid[x, y].squares[size - 1] + rows[size] + cols[size] - score;

                        grid[x - 1, y - 1] = (squares, rows, cols);

                        if (squares[size] > maxSquare.power) maxSquare = (x, y, size + 1, squares[size]);
                    }
                }
            }

            return string.Format("{0},{1}" + (2 == 2 ? ",{2}" : ""), maxSquare.x, maxSquare.y, maxSquare.size);
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _11_ChronalCharge(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_11_ChronalCharge));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}