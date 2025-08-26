using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _04_CeresSearch : I_04_CeresSearch
    {
        #region Static
        private readonly List<string>? data;

        public _04_CeresSearch()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_04_CeresSearch));
        }

        /// <summary>
        /// "Looks like the Chief's not here. Next!" One of The Historians pulls out a device and pushes the only button on it. 
        /// After a brief flash, you recognize the interior of the Ceres monitoring station!
        /// As the search for the Chief continues, a small Elf who lives on the station tugs on your shirt; she'd like to know if you could help her with her word search (your puzzle input). 
        /// She only has to find one word: XMAS.
        /// This word search allows words to be horizontal, vertical, diagonal, written backwards, or even overlapping other words.
        /// It's a little unusual, though, as you don't merely need to find one instance of XMAS - you need to find all of them.
        /// Here are a few ways XMAS might appear, where irrelevant characters have been replaced with.:
        /// 
        /// ..X...
        /// .SAMX.
        /// .A..A.
        /// XMAS.S
        /// .X....
        /// 
        /// The actual word search will be full of letters instead. For example:
        /// 
        /// MMMSXXMASM
        /// MSAMXMSMSA
        /// AMXSXMAAMM
        /// MSAMASMSMX
        /// XMASAMXAMM
        /// XXAMMXXAMA
        /// SMSMSASXSS
        /// SAXAMASAAA
        /// MAMMMXMMMM
        /// MXMXAXMASX
        /// 
        /// In this word search, XMAS occurs a total of 18 times; here's the same word search again, but where letters not involved in any XMAS have been replaced with .:
        /// 
        /// ....XXMAS.
        /// .SAMXMS...
        /// ...S..A...
        /// ..A.A.MS.X
        /// XMASAMX.MM
        /// X.....XA.A
        /// S.S.S.S.SS
        /// .A.A.A.A.A
        /// ..M.M.M.MM
        /// .X.X.XMASX
        /// 
        /// Take a look at the little Elf's word search. How many times does XMAS appear?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int res = 0;

            int x = input[0].Length;
            int y = input.Count;

            string a = string.Join("", Enumerable.Repeat('.', x + 6));

            for (int i = 0; i < y; i++)
            {
                input[i] = $"...{input[i]}...";
            }

            input.Insert(0, a);
            input.Insert(0, a);
            input.Insert(0, a);
            input.Add(a);
            input.Add(a);
            input.Add(a);

            for (int i = 3; i < y + 3; i++)
            {
                for (int j = 3; j < x + 3; j++)
                {
                    // south
                    if (input[i][j] == 'X' && input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S')
                        res += 1;
                    // north
                    if (input[i][j] == 'X' && input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S')
                        res += 1;
                    // east
                    if (input[i][j] == 'X' && input[i][j + 1] == 'M' && input[i][j + 2] == 'A' && input[i][j + 3] == 'S')
                        res += 1;
                    // west
                    if (input[i][j] == 'X' && input[i][j - 1] == 'M' && input[i][j - 2] == 'A' && input[i][j - 3] == 'S')
                        res += 1;
                    // south east
                    if (input[i][j] == 'X' && input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S')
                        res += 1;
                    // north west
                    if (input[i][j] == 'X' && input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S')
                        res += 1;
                    // north east
                    if (input[i][j] == 'X' && input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S')
                        res += 1;
                    // south west
                    if (input[i][j] == 'X' && input[i + 1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S')
                        res += 1;
                }
            }

            return res;
        }

        /// <summary>
        /// The Elf looks quizzically at you. Did you misunderstand the assignment?
        /// Looking for the instructions, you flip over the word search to find that this isn't actually an XMAS puzzle; 
        /// it's an X-MAS puzzle in which you're supposed to find two MAS in the shape of an X. 
        /// One way to achieve that is like this:
        /// 
        /// M.S
        /// .A.
        /// M.S
        /// 
        /// Irrelevant characters have again been replaced with. in the above diagram.
        /// Within the X, each MAS can be written forwards or backwards.
        /// Here's the same example from before, but this time all of the X-MASes have been kept instead:
        /// 
        /// .M.S......
        /// ..A..MSMS.
        /// .M.S.MAA..
        /// ..A.ASMSM.
        /// .M.S.M....
        /// ..........
        /// S.S.S.S.S.
        /// .A.A.A.A..
        /// M.M.M.M.M.
        /// ..........
        /// 
        /// In this example, an X-MAS appears 9 times.
        /// Flip the word search from the instructions back over to the word search side and try again.
        /// How many times does an X-MAS appear?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int res = 0;

            int x = input[0].Length;
            int y = input.Count;

            string a = string.Join("", Enumerable.Repeat('.', x + 6));

            for (int i = 0; i < y; i++)
            {
                input[i] = $"...{input[i]}...";
            }

            input.Insert(0, a);
            input.Insert(0, a);
            input.Insert(0, a);
            input.Add(a);
            input.Add(a);
            input.Add(a);

            for (int i = 3; i < y + 3; i++)
            {
                for (int j = 3; j < x + 3; j++)
                {
                    // south
                    if (input[i][j] == 'A' && input[i + 1][j + 1] == 'M' && input[i - 1][j - 1] == 'S' && input[i + 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S' ||
                            input[i][j] == 'A' && input[i + 1][j + 1] == 'S' && input[i - 1][j - 1] == 'M' && input[i + 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S' ||
                            input[i][j] == 'A' && input[i + 1][j + 1] == 'S' && input[i - 1][j - 1] == 'M' && input[i + 1][j - 1] == 'S' && input[i - 1][j + 1] == 'M' ||
                            input[i][j] == 'A' && input[i + 1][j + 1] == 'M' && input[i - 1][j - 1] == 'S' && input[i + 1][j - 1] == 'S' && input[i - 1][j + 1] == 'M')
                            res += 1;
                }
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

        public _04_CeresSearch(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_04_CeresSearch));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}