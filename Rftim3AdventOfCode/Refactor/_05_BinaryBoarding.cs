using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _05_BinaryBoarding : I_05_BinaryBoarding
    {
        #region Static
        private readonly List<string>? data;

        public _05_BinaryBoarding()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_05_BinaryBoarding));
        }

        /// <summary>
        /// You board your plane only to discover a new problem: you dropped your boarding pass! 
        /// You aren't sure which seat is yours, and all of the flight attendants are busy with the flood of people that suddenly made it through passport control.
        /// 
        /// You write a quick program to use your phone's camera to scan all of the nearby boarding passes (your puzzle input); 
        /// perhaps you can find your seat through process of elimination.
        /// 
        /// Instead of zones or groups, this airline uses binary space partitioning to seat people.
        /// A seat might be specified like FBFBBFFRLR, where F means "front", B means "back", L means "left", and R means "right".
        /// 
        /// The first 7 characters will either be F or B; these specify exactly one of the 128 rows on the plane(numbered 0 through 127).
        /// Each letter tells you which half of a region the given seat is in. Start with the whole list of rows; 
        /// the first letter indicates whether the seat is in the front(0 through 63) or the back(64 through 127). 
        /// The next letter indicates which half of that region the seat is in, and so on until you're left with exactly one row.
        /// 
        /// For example, consider just the first seven characters of FBFBBFFRLR:
        /// 
        /// Start by considering the whole range, rows 0 through 127.
        /// F means to take the lower half, keeping rows 0 through 63.
        /// B means to take the upper half, keeping rows 32 through 63.
        /// F means to take the lower half, keeping rows 32 through 47.
        /// B means to take the upper half, keeping rows 40 through 47.
        /// B keeps rows 44 through 47.
        /// F keeps rows 44 through 45.
        /// The final F keeps the lower of the two, row 44.
        /// The last three characters will be either L or R; these specify exactly one of the 8 columns of seats on the plane(numbered 0 through 7). 
        /// The same process as above proceeds again, this time with only three steps.L means to keep the lower half, while R means to keep the upper half.
        /// 
        /// For example, consider just the last 3 characters of FBFBBFFRLR:
        /// 
        /// Start by considering the whole range, columns 0 through 7.
        /// R means to take the upper half, keeping columns 4 through 7.
        /// L means to take the lower half, keeping columns 4 through 5.
        /// The final R keeps the upper of the two, column 5.
        /// So, decoding FBFBBFFRLR reveals that it is the seat at row 44, column 5.
        /// 
        /// Every seat also has a unique seat ID: multiply the row by 8, then add the column.In this example, the seat has ID 44 * 8 + 5 = 357.
        /// 
        /// Here are some other boarding passes:
        /// 
        /// BFFFBBFRRR: row 70, column 7, seat ID 567.
        /// FFFBBBFRRR: row 14, column 7, seat ID 119.
        /// BBFFBBFRLL: row 102, column 4, seat ID 820.
        /// As a sanity check, look through your list of boarding passes.What is the highest seat ID on a boarding pass?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<int> z = [];
            foreach (string item in input)
            {
                int r = 0, c = 0;

                int x = 0, y = 127;
                int x0 = 0, y0 = 7;

                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == 'F')
                    {
                        y = (int)Math.Floor((y - x) / 2d) + x;
                        r = y;
                    }
                    else if (item[i] == 'B')
                    {
                        x = (int)Math.Ceiling((y - x) / 2d) + x;
                        r = x;
                    }
                    else if (item[i] == 'L')
                    {
                        y0 = (int)Math.Floor((y0 - x0) / 2d) + x0;
                        c = y0;
                    }
                    else if (item[i] == 'R')
                    {
                        x0 = (int)Math.Ceiling((y0 - x0) / 2d) + x0;
                        c = x0;
                    }
                }

                z.Add(r * 8 + c);
            }

            return z.Max();
        }

        /// <summary>
        /// Ding! The "fasten seat belt" signs have turned on. Time to find your seat.
        /// 
        /// It's a completely full flight, so your seat should be the only missing boarding pass in your list.
        /// However, there's a catch: some of the seats at the very front and back of the plane don't exist on this aircraft, so they'll be missing from your list as well.
        /// 
        /// Your seat wasn't at the very front or back, though; the seats with IDs +1 and -1 from yours will be in your list.
        /// 
        /// What is the ID of your seat?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<int> z = [];
            foreach (string item in input)
            {
                int r = 0, c = 0;

                int x = 0, y = 127;
                int x0 = 0, y0 = 7;

                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == 'F')
                    {
                        y = (int)Math.Floor((y - x) / 2d) + x;
                        r = y;
                    }
                    else if (item[i] == 'B')
                    {
                        x = (int)Math.Ceiling((y - x) / 2d) + x;
                        r = x;
                    }
                    else if (item[i] == 'L')
                    {
                        y0 = (int)Math.Floor((y0 - x0) / 2d) + x0;
                        c = y0;
                    }
                    else if (item[i] == 'R')
                    {
                        x0 = (int)Math.Ceiling((y0 - x0) / 2d) + x0;
                        c = x0;
                    }
                }

                z.Add(r * 8 + c);
            }
            z.Sort();

            for (int i = 0; i < z.Count - 1; i++)
            {
                if (Math.Abs(z[i] - z[i + 1]) == 2) return z[i] > z[i + 1] ? z[i] - 1 : z[i + 1] - 1;
            }

            return z.Max();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _05_BinaryBoarding(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_05_BinaryBoarding));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}