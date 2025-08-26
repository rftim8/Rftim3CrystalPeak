using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _12_JSAbacusFrameworkIO : I_12_JSAbacusFrameworkIO
    {
        #region Static
        private readonly List<string>? data;

        public _12_JSAbacusFrameworkIO()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_12_JSAbacusFrameworkIO));
        }

        /// <summary>
        /// Santa's Accounting-Elves need help balancing the books after a recent order. 
        /// Unfortunately, their accounting software uses a peculiar storage format. That's where you come in.
        /// 
        /// They have a JSON document which contains a variety of things: arrays([1,2,3]), objects({ "a":1, "b":2}), numbers, and strings.
        /// Your first job is to simply find all of the numbers throughout the document and add them together.
        /// 
        /// For example:
        ///  - [1,2,3] and { "a":2,"b":4} both have a sum of 6.
        ///  - [[[3]]] and {"a":{"b":4},"c":-1} both have a sum of 3.
        ///  - {"a":[-1,1]} and[-1,{ "a":1}] both have a sum of 0.
        ///  - [] and { } both have a sum of 0.
        /// 
        /// You will not encounter any strings containing numbers.
        /// 
        /// What is the sum of all numbers in the document?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string file = input[0];
            int r = 0;

            int sign = 1;
            string nr = string.Empty;

            foreach (char item in file)
            {
                if (item == '-') sign *= -1;
                else if (char.IsNumber(item)) nr += item;
                else
                {
                    if (nr != string.Empty) r += int.Parse(nr) * sign;
                    sign = 1;
                    nr = string.Empty;
                }
            }

            return r;
        }

        /// <summary>
        /// Uh oh - the Accounting-Elves have realized that they double-counted everything red.
        /// Ignore any object (and all of its children) which has any property with the value "red". Do this only for objects ({...}), not arrays ([...]).
        /// 
        /// [1,2,3] still has a sum of 6.
        /// [1,{"c":"red","b":2},3] now has a sum of 4, because the middle object is ignored.
        /// {"d":"red","e":[1,2,3,4],"f":5} now has a sum of 0, because the entire structure is ignored.
        /// [1,"red",5] has a sum of 6, because "red" in an array has no effect.
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string file = input[0];
            int r;
            while (true)
            {
                file = RftParseObjects(file);
                if (int.TryParse(file, out r)) break;
            }

            return r;
        }

        private static string RftParseObjects(string file)
        {
            StringBuilder sb = new(file);
            int right = file.IndexOf('}');

            int left = right;
            while (left > -1)
            {
                if (sb[left] == '{')
                {
                    if (!sb.ToString()[left..right].Contains(":\"red\""))
                    {
                        string t = sb.ToString()[left..(right + 1)];
                        sb.Remove(left, right - left + 1);
                        sb.Insert(left, $"{PartOne0([t])}");
                    }
                    else sb.Remove(left, right - left + 1);
                    break;
                }
                left--;
            }

            return sb.ToString();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _12_JSAbacusFrameworkIO(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_12_JSAbacusFrameworkIO));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}