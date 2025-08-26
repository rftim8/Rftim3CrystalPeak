using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _02_IWasToldThereWouldBeNoMath : I_02_IWasToldThereWouldBeNoMath
    {
        #region Static
        private readonly List<string>? data;

        public _02_IWasToldThereWouldBeNoMath()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_02_IWasToldThereWouldBeNoMath));
        }

        /// <summary>
        /// The elves are running low on wrapping paper, and so they need to submit an order for more.
        /// They have a list of the dimensions(length l, width w, and height h) of each present, and only want to order exactly as much as they need.
        /// Fortunately, every present is a box (a perfect right rectangular prism), which makes calculating the required wrapping paper for each gift a little easier: 
        /// find the surface area of the box, which is 2*l* w + 2*w* h + 2*h* l.The elves also need a little extra paper for each present: the area of the smallest side.
        /// 
        /// For example:
        /// 
        /// A present with dimensions 2x3x4 requires 2*6 + 2*12 + 2*8 = 52 square feet of wrapping paper plus 6 square feet of slack, for a total of 58 square feet.
        /// A present with dimensions 1x1x10 requires 2*1 + 2*10 + 2*10 = 42 square feet of wrapping paper plus 1 square foot of slack, for a total of 43 square feet.
        /// All numbers in the elves' list are in feet. 
        /// 
        /// How many total square feet of wrapping paper should they order?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            for (int i = 0; i < input.Count; i++)
            {
                int l = int.Parse(input[i].Split('x')[0]);
                int w = int.Parse(input[i].Split('x')[1]);
                int h = int.Parse(input[i].Split('x')[2]);

                r += 2 * l * w + 2 * w * h + 2 * h * l;

                List<int> y =
                [
                    l,
                    w,
                    h
                ];
                y.Sort();

                r += y[0] * y[1];
            }

            return r;
        }

        /// <summary>
        /// The elves are also running low on ribbon.Ribbon is all the same width, so they only have to worry about the length they need to order, which they would again like to be exact.
        /// The ribbon required to wrap a present is the shortest distance around its sides, or the smallest perimeter of any one face. 
        /// Each present also requires a bow made out of ribbon as well; the feet of ribbon required for the perfect bow is equal to the cubic feet of volume of the present.
        /// Don't ask how they tie the bow, though; they'll never tell.
        /// 
        /// For example:
        /// 
        /// A present with dimensions 2x3x4 requires 2+2+3+3 = 10 feet of ribbon to wrap the present plus 2*3*4 = 24 feet of ribbon for the bow, for a total of 34 feet.
        /// A present with dimensions 1x1x10 requires 1+1+1+1 = 4 feet of ribbon to wrap the present plus 1*1*10 = 10 feet of ribbon for the bow, for a total of 14 feet.
        /// 
        /// How many total feet of ribbon should they order?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;
            int r1 = 0;
            
            for (int i = 0; i < input.Count; i++)
            {
                int l = int.Parse(input[i].Split('x')[0]);
                int w = int.Parse(input[i].Split('x')[1]);
                int h = int.Parse(input[i].Split('x')[2]);

                r += 2 * l * w + 2 * w * h + 2 * h * l;

                List<int> y = [l, w, h];
                y.Sort();

                r += y[0] * y[1];

                r1 += 2 * y[0] + 2 * y[1];
                r1 += l * w * h;
            }

            return r1;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _02_IWasToldThereWouldBeNoMath(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_02_IWasToldThereWouldBeNoMath));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}