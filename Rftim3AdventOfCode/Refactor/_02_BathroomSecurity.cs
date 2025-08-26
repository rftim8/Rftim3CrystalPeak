using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _02_BathroomSecurity : I_02_BathroomSecurity
    {
        #region Static
        private readonly List<string>? data;

        public _02_BathroomSecurity()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_02_BathroomSecurity));
        }

        /// <summary>
        /// You arrive at Easter Bunny Headquarters under cover of darkness. 
        /// However, you left in such a rush that you forgot to use the bathroom! 
        /// Fancy office buildings like this one usually have keypad locks on their bathrooms, so you search the front desk for the code.
        /// 
        /// "In order to improve security," the document you find says, "bathroom codes will no longer be written down. 
        /// Instead, please memorize and follow the procedure below to access the bathrooms."
        /// 
        /// The document goes on to explain that each button to be pressed can be found by starting on the previous button 
        /// and moving to adjacent buttons on the keypad: U moves up, D moves down, L moves left, and R moves right.
        /// Each line of instructions corresponds to one button, starting at the previous button (or, for the first line, the "5" button); 
        /// press whatever button you're on at the end of each line. 
        /// If a move doesn't lead to a button, ignore it.
        /// 
        /// You can't hold it much longer, so you decide to figure out the code as you walk to the bathroom. You picture a keypad like this:
        /// 
        /// 1 2 3
        /// 4 5 6
        /// 7 8 9
        /// Suppose your instructions are:
        /// 
        /// ULL
        /// RRDDD
        /// LURDL
        /// UUUUD
        /// 
        /// You start at "5" and move up (to "2"), left(to "1"), and left(you can't, and stay on "1"), so the first button is 1.
        /// Starting from the previous button ("1"), you move right twice(to "3") and then down three times(stopping at "9" after two moves and ignoring the third), ending up with 9.
        /// Continuing from "9", you move left, up, right, down, and left, ending with 8.
        /// Finally, you move up four times(stopping at "2"), then down once, ending with 5.
        /// So, in this example, the bathroom code is 1985.
        /// 
        /// Your puzzle input is the instructions from the document you found at the front desk. What is the bathroom code?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            int[,] map = new[,]
            {
                { 1,2,3 },
                { 4,5,6 },
                { 7,8,9 }
            };

            List<int> r = [];
            foreach (string item1 in input)
            {
                int x = 1, y = 1;

                foreach (char item in item1)
                {
                    switch (item)
                    {
                        case 'U':
                            if (x - 1 >= 0) x--;
                            break;
                        case 'R':
                            if (y + 1 <= 2) y++;
                            break;
                        case 'D':
                            if (x + 1 <= 2) x++;
                            break;
                        case 'L':
                            if (y - 1 >= 0) y--;
                            break;
                        default:
                            break;
                    }
                }

                r.Add(map[x, y]);
            }

            return string.Concat(r);
        }

        /// <summary>
        /// You finally arrive at the bathroom (it's a several minute walk from the lobby so visitors can behold the many fancy conference rooms 
        /// and water coolers on this floor) and go to punch in the code. 
        /// Much to your bladder's dismay, the keypad is not at all like you imagined it. 
        /// Instead, you are confronted with the result of hundreds of man-hours of bathroom-keypad-design meetings:
        /// 
        ///     1
        ///   2 3 4
        /// 5 6 7 8 9
        ///   A B C
        ///     D
        /// You still start at "5" and stop when you're at an edge, but given the same instructions as above, the outcome is very different:
        /// 
        /// You start at "5" and don't move at all (up and left are both edges), ending at 5.
        /// Continuing from "5", you move right twice and down three times(through "6", "7", "B", "D", "D"), ending at D.
        /// Then, from "D", you move five more times(through "D", "B", "C", "C", "B"), ending at B.
        /// Finally, after five more moves, you end at 3.
        /// So, given the actual keypad layout, the code would be 5DB3.
        /// 
        /// Using the same instructions in your puzzle input, what is the correct bathroom code?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string[,] map = new[,]
            {
                { "", "", "1", "", "" },
                { "", "2", "3", "4", "" },
                { "5", "6", "7", "8", "9" },
                { "", "A", "B", "C", "" },
                { "", "", "D", "", "" }
            };

            List<string> r = [];
            foreach (string item1 in input)
            {
                int x = 1, y = 1;

                foreach (char item in item1)
                {
                    switch (item)
                    {
                        case 'U':
                            if (x - 1 >= 0 && map[x - 1, y] != string.Empty) x--;
                            break;
                        case 'R':
                            if (y + 1 <= 4 && map[x, y + 1] != string.Empty) y++;
                            break;
                        case 'D':
                            if (x + 1 <= 4 && map[x + 1, y] != string.Empty) x++;
                            break;
                        case 'L':
                            if (y - 1 >= 0 && map[x, y - 1] != string.Empty) y--;
                            break;
                        default:
                            break;
                    }
                }

                r.Add(map[x, y]);
            }

            return string.Concat(r);
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _02_BathroomSecurity(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_02_BathroomSecurity));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}