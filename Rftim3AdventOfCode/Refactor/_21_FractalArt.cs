using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _21_FractalArt : I_21_FractalArt
    {
        #region Static
        private readonly List<string>? data;

        public _21_FractalArt()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_21_FractalArt));
        }

        /// <summary>
        /// You find a program trying to generate some art. It uses a strange process that involves repeatedly enhancing the detail of an image through a set of rules.
        /// 
        /// The image consists of a two-dimensional square grid of pixels that are either on(#) or off (.). The program always begins with this pattern:
        /// 
        /// .#.
        /// ..#
        /// ###
        /// Because the pattern is both 3 pixels wide and 3 pixels tall, it is said to have a size of 3.
        /// 
        /// Then, the program repeats the following process:
        /// 
        /// If the size is evenly divisible by 2, break the pixels up into 2x2 squares, and convert each 2x2 square into a 3x3 square by following the corresponding enhancement rule.
        /// Otherwise, the size is evenly divisible by 3; break the pixels up into 3x3 squares, and convert each 3x3 square into a 4x4 square 
        /// by following the corresponding enhancement rule.
        /// Because each square of pixels is replaced by a larger one, the image gains pixels and so its size increases.
        /// 
        /// The artist's book of enhancement rules is nearby (your puzzle input); however, it seems to be missing rules. 
        /// The artist explains that sometimes, one must rotate or flip the input pattern to find a match. (Never rotate or flip the output pattern, though.)
        /// Each pattern is written concisely: rows are listed as single units, ordered top-down, and separated by slashes.
        /// For example, the following rules correspond to the adjacent patterns:
        /// 
        /// ../.#  =  ..
        ///           .#
        /// 
        ///                 .#.
        /// .#./..#/###  =  ..#
        ///                 ###
        /// 
        ///                         #..#
        /// #..#/..../#..#/.##.  =  ....
        ///                         #..#
        ///                         .##.
        /// When searching for a rule to use, rotate and flip the pattern as necessary.For example, all of the following patterns match the same rule:
        /// 
        /// .#.   .#.   #..   ###
        /// ..#   #..   #.#   ..#
        /// ###   ###   ##.   .#.
        /// Suppose the book contained the following two rules:
        /// 
        /// ../.# => ##./#../...
        /// .#./..#/### => #..#/..../..../#..#
        /// As before, the program begins with this pattern:
        /// 
        /// .#.
        /// ..#
        /// ###
        /// The size of the grid (3) is not divisible by 2, but it is divisible by 3. It divides evenly into a single square; the square matches the second rule, which produces:
        /// 
        /// #..#
        /// ....
        /// ....
        /// #..#
        /// The size of this enhanced grid (4) is evenly divisible by 2, so that rule is used. It divides evenly into four squares:
        /// 
        /// #.|.#
        /// ..|..
        /// --+--
        /// ..|..
        /// #.|.#
        /// Each of these squares matches the same rule (../.# => ##./#../...), three of which require some flipping and rotation to line up with the rule. 
        /// The output for the rule is the same in all four cases:
        /// 
        /// ##.|##.
        /// #..|#..
        /// ...|...
        /// ---+---
        /// ##.|##.
        /// #..|#..
        /// ...|...
        /// Finally, the squares are joined into a new grid:
        /// 
        /// ##.##.
        /// #..#..
        /// ......
        /// ##.##.
        /// #..#..
        /// ......
        /// Thus, after 2 iterations, the grid contains 12 pixels that are on.
        /// 
        /// How many pixels stay on after 5 iterations?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            char[] separators = [' ', '=', '>'];

            Dictionary<string, string> rulesMap = [];

            foreach (string rule in input)
            {
                string[] tokens = rule.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string from = tokens[0];
                string to = tokens[1];

                rulesMap.TryAdd(from, to);
                rulesMap.TryAdd(FlipHorizontal(from), to);
                rulesMap.TryAdd(FlipVertical(from), to);

                for (int i = 0; i < 3; i++)
                {
                    string newFrom = Rotate(from);
                    rulesMap.TryAdd(newFrom, to);
                    rulesMap.TryAdd(FlipHorizontal(newFrom), to);
                    rulesMap.TryAdd(FlipVertical(newFrom), to);

                    from = newFrom;
                }
            }

            string[] grid =
            [
                ".#.",
                "..#",
                "###",
            ];

            grid = Enhance(iterations: 5, grid: grid, rules: rulesMap);

            int answer = CountOn(grid);

            return answer;
        }

        /// <summary>
        /// How many pixels stay on after 18 iterations?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            char[] separators = [' ', '=', '>'];

            Dictionary<string, string> rulesMap = [];

            foreach (string rule in input)
            {
                string[] tokens = rule.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string from = tokens[0];
                string to = tokens[1];

                rulesMap.TryAdd(from, to);
                rulesMap.TryAdd(FlipHorizontal(from), to);
                rulesMap.TryAdd(FlipVertical(from), to);

                for (int i = 0; i < 3; i++)
                {
                    string newFrom = Rotate(from);
                    rulesMap.TryAdd(newFrom, to);
                    rulesMap.TryAdd(FlipHorizontal(newFrom), to);
                    rulesMap.TryAdd(FlipVertical(newFrom), to);

                    from = newFrom;
                }
            }

            string[] grid =
            [
                ".#.",
                "..#",
                "###",
            ];

            grid = Enhance(iterations: 18, grid: grid, rules: rulesMap);

            int answer = CountOn(grid);

            return answer;
        }

        private static string FlipHorizontal(string grid)
        {
            string[] rows = grid.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string[] newRows = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                newRows[i] = string.Join("", rows[i].Reverse());
            }

            return string.Join<string>('/', newRows);
        }

        private static string FlipVertical(string grid)
        {
            string[] rows = grid.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string[] newRows = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                newRows[rows.Length - i - 1] = rows[i];
            }

            return string.Join<string>('/', newRows);
        }

        private static string Rotate(string grid)
        {
            string[] rows = grid.Split('/', StringSplitOptions.RemoveEmptyEntries);
            char[,] newRows = new char[rows.Length, rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    newRows[rows.Length - j - 1, i] = rows[i][j];
                }
            }

            string[] sNewRows = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    sNewRows[i] += newRows[i, j];
                }
            }

            string result = string.Join('/', sNewRows);

            return result;
        }

        private static string CopyFrom(string[] grid, int startRow, int startColumn, int num)
        {
            string[] section = new string[num];
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    section[i] += grid[i + startRow][j + startColumn];
                }
            }

            return string.Join('/', section);
        }

        private static void CopyTo(string[] grid, string section, int size, int startRow, int startColumn)
        {
            string[] rows = section.Split('/', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[startRow + i] += rows[i][j];
                }
            }
        }

        private static string[] EnhanceStep(string[] grid, Dictionary<string, string> rules, int size)
        {
            int newSize = size + 1;

            string[] newGrid = new string[grid.Length / size * newSize];

            for (int j = 0; j * size < grid.Length; j++)
            {
                for (int k = 0; k * size < grid.Length; k++)
                {
                    string section = CopyFrom(grid, j * size, k * size, size);
                    CopyTo(newGrid, rules[section], newSize, j * newSize, k * newSize);
                }
            }

            return newGrid;
        }

        private static string[] Enhance(int iterations, string[] grid, Dictionary<string, string> rules)
        {
            for (int i = 0; i < iterations; i++)
            {
                if (grid.Length % 2 == 0) grid = EnhanceStep(grid, rules, size: 2);
                else grid = EnhanceStep(grid, rules, size: 3);
            }

            return grid;
        }

        private static int CountOn(string[] grid)
        {
            int countOn = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j] == '#') countOn++;
                }
            }

            return countOn;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _21_FractalArt(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_21_FractalArt));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}