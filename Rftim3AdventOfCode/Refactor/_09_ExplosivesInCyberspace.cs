using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _09_ExplosivesInCyberspace : I_09_ExplosivesInCyberspace
    {
        #region Static
        private readonly List<string>? data;

        public _09_ExplosivesInCyberspace()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_09_ExplosivesInCyberspace));
        }

        /// <summary>
        /// Wandering around a secure area, you come across a datalink port to a new part of the network. 
        /// After briefly scanning it for interesting files, you find one file in particular that catches your attention. 
        /// It's compressed with an experimental format, but fortunately, the documentation for the format is nearby.
        /// 
        /// The format compresses a sequence of characters.Whitespace is ignored.
        /// To indicate that some sequence should be repeated, a marker is added to the file, like (10x2). 
        /// To decompress this marker, take the subsequent 10 characters and repeat them 2 times.
        /// Then, continue reading the file after the repeated data.The marker itself is not included in the decompressed output.
        /// 
        /// If parentheses or other characters appear within the data referenced by a marker, that's okay - treat it like normal data, not a marker,
        /// and then resume looking for markers after the decompressed section.
        /// 
        /// For example:
        /// 
        /// ADVENT contains no markers and decompresses to itself with no changes, resulting in a decompressed length of 6.
        /// A(1x5)BC repeats only the B a total of 5 times, becoming ABBBBBC for a decompressed length of 7.
        /// (3x3)XYZ becomes XYZXYZXYZ for a decompressed length of 9.
        /// A(2x2)BCD(2x2)EFG doubles the BC and EF, becoming ABCBCDEFEFG for a decompressed length of 11.
        /// (6x1)(1x3)A simply becomes(1x3)A - the(1x3) looks like a marker, but because it's within a data section of another marker, 
        /// it is not treated any differently from the A that comes after it. It has a decompressed length of 6.
        /// X(8x2)(3x3)ABCY becomes X(3x3)ABC(3x3)ABCY(for a decompressed length of 18), because the decompressed data from the(8x2) marker(the (3x3)ABC) 
        /// is skipped and not processed further.
        /// What is the decompressed length of the file(your puzzle input)? Don't count whitespace.
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string s = input[0];
            int i = 0;
            while (i < s.Length)
            {
                if (s[i] != '(')
                {
                    i++;
                    continue;
                }

                int length = Convert.ToInt32(s.Substring(i + 1, s.IndexOf('x', i) - i - 1));
                int count = Convert.ToInt32(s.Substring(s.IndexOf('x', i) + 1, s.IndexOf(')', i) - s.IndexOf('x', i) - 1));
                int clength = 3 + count.ToString().Length + length.ToString().Length;
                string part = s.Substring(i + clength, length);

                StringBuilder str = new(s);
                str.Remove(i, clength);
                str.Insert(i, part, count - 1);
                s = str.ToString();
                i += length * count;
            }

            return s.Length;
        }

        /// <summary>
        /// Apparently, the file actually uses version two of the format.
        /// 
        /// In version two, the only difference is that markers within decompressed data are decompressed.
        /// This, the documentation explains, provides much more substantial compression capabilities, allowing many-gigabyte files to be stored in only a few kilobytes.
        /// 
        /// For example:
        /// 
        /// (3x3)XYZ still becomes XYZXYZXYZ, as the decompressed section contains no markers.
        /// X(8x2)(3x3)ABCY becomes XABCABCABCABCABCABCY, because the decompressed data from the(8x2) marker is then further decompressed, 
        /// thus triggering the(3x3) marker twice for a total of six ABC sequences.
        /// (27x12)(20x12)(13x14)(7x10)(1x12)A decompresses into a string of A repeated 241920 times.
        /// (25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN becomes 445 characters long.
        /// Unfortunately, the computer you brought probably doesn't have enough memory to actually decompress the file; 
        /// you'll have to come up with another way to get its decompressed length.
        /// 
        /// What is the decompressed length of the file using this improved format?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            string s = input[0];

            return GetLength(s);
        }

        private static long GetLength(string input)
        {
            if (!input.Contains('(')) return input.Length;

            long fullcount = 0;
            int i = 0;

            while (i < input.Length)
            {
                if (input[i] != '(')
                {
                    i++; fullcount++;
                    continue;
                }

                int length = Convert.ToInt32(input.Substring(i + 1, input.IndexOf('x', i) - i - 1));
                int count = Convert.ToInt32(input.Substring(input.IndexOf('x', i) + 1, input.IndexOf(')', i) - input.IndexOf('x', i) - 1));
                int clength = 3 + count.ToString().Length + length.ToString().Length;
                string part = input.Substring(i + clength, length);
                fullcount += GetLength(part) * count;
                i += clength + length;
            }

            return fullcount;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _09_ExplosivesInCyberspace(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_09_ExplosivesInCyberspace));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}