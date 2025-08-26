using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _01_NotQuiteLisp : I_01_NotQuiteLisp
    {
        #region Static
        private readonly List<string>? data;

        public _01_NotQuiteLisp()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_01_NotQuiteLisp));
        }
        
        /// <summary>
        /// Santa is trying to deliver presents in a large apartment building, but he can't find the right floor - the directions he got are a little confusing. 
        /// He starts on the ground floor(floor 0) and then follows the instructions one character at a time.
        /// An opening parenthesis, (, means he should go up one floor, and a closing parenthesis, ), means he should go down one floor.
        /// The apartment building is very tall, and the basement is very deep; he will never find the top or bottom floors.
        /// 
        /// For example: 
        /// 
        /// (()) and()() both result in floor 0. 
        /// (((and (()(()(both result in floor 3. 
        /// ))(((((also results in floor 3. 
        /// ()) and ))(both result in floor -1 (the first basement level). 
        /// ))) and )())()) both result in floor -3. 
        /// 
        /// To what floor do the instructions take Santa?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string data = input[0];
            int r = 0;

            for (int i = 0; i < data.Length; i++)
            {
                r = data[i] == '(' ? r + 1 : r - 1;
            }

            return r;
        }

        /// <summary>
        /// Now, given the same instructions, find the position of the first character that causes him to enter the basement (floor -1). 
        /// The first character in the instructions has position 1, the second character has position 2, and so on.
        /// 
        /// For example: 
        /// 
        /// ) causes him to enter the basement at character position 1. 
        /// () ()) causes him to enter the basement at character position 5.
        /// 
        /// What is the position of the character that causes Santa to first enter the basement?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string data = input[0];
            int r = 0;
            int firstBasement = 0;
            bool found = false;
            
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '(') r++;
                else
                {
                    r--;

                    if (!found)
                    {
                        if (r < 0)
                        {
                            firstBasement = i;
                            found = true;
                        }
                    }
                }
            }

            return firstBasement + 1;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;
        
        public _01_NotQuiteLisp(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_01_NotQuiteLisp));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}