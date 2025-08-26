using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_NoMatterHowYouSliceIt : I_03_NoMatterHowYouSliceIt
    {
        #region Static
        private readonly List<string>? data;

        public _03_NoMatterHowYouSliceIt()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_NoMatterHowYouSliceIt));
        }

        /// <summary>
        /// The Elves managed to locate the chimney-squeeze prototype fabric for Santa's suit (thanks to someone who helpfully wrote its box
        /// IDs on the wall of the warehouse in the middle of the night). 
        /// Unfortunately, anomalies are still affecting them - nobody can even agree on how to cut the fabric.
        /// 
        /// The whole piece of fabric they're working on is a very large square - at least 1000 inches on each side.
        /// 
        /// Each Elf has made a claim about which area of fabric would be ideal for Santa's suit. 
        /// All claims have an ID and consist of a single rectangle with edges parallel to the edges of the fabric. 
        /// Each claim's rectangle is defined as follows:
        /// 
        /// The number of inches between the left edge of the fabric and the left edge of the rectangle.
        /// The number of inches between the top edge of the fabric and the top edge of the rectangle.
        /// The width of the rectangle in inches.
        /// The height of the rectangle in inches.
        /// A claim like #123 @ 3,2: 5x4 means that claim ID 123 specifies a rectangle 3 inches from the left edge, 2 inches from the top edge,
        /// 5 inches wide, and 4 inches tall. Visually, it claims the square inches of fabric represented by # (and ignores the square inches of fabric represented by .) 
        /// in the diagram below:
        /// 
        /// ...........
        /// ...........
        /// ...#####...
        /// ...#####...
        /// ...#####...
        /// ...#####...
        /// ...........
        /// ...........
        /// ...........
        /// The problem is that many of the claims overlap, causing two or more claims to cover part of the same areas.
        /// For example, consider the following claims:
        /// 
        /// #1 @ 1,3: 4x4
        /// #2 @ 3,1: 4x4
        /// #3 @ 5,5: 2x2
        /// Visually, these claim the following areas:
        /// 
        /// ........
        /// ...2222.
        /// ...2222.
        /// .11XX22.
        /// .11XX22.
        /// .111133.
        /// .111133.
        /// ........
        /// The four square inches marked with X are claimed by both 1 and 2. (Claim 3, while adjacent to the others, does not overlap either of them.)
        /// 
        /// If the Elves all proceed with their own plans, none of them will have enough fabric.
        /// How many square inches of fabric are within two or more claims?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;
            int size = 1050;
            string[,] a = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    a[i, j] = " ";
                }
            }

            foreach (string item in input)
            {
                int x = int.Parse(item.Split(' ')[2].Replace(":", "").Split(',')[1]);
                int y = int.Parse(item.Split(' ')[2].Replace(":", "").Split(',')[0]);

                int w = int.Parse(item.Split(' ')[3].Split('x')[0]);
                int h = int.Parse(item.Split(' ')[3].Split('x')[1]);

                for (int i = x; i < x + h; i++)
                {
                    for (int j = y; j < y + w; j++)
                    {
                        if (a[i, j] != " ")
                        {
                            if (a[i, j] != "X") r++;
                            a[i, j] = "X";
                        }
                        else a[i, j] = ".";
                    }
                }
            }

            return r;
        }

        /// <summary>
        /// Amidst the chaos, you notice that exactly one claim doesn't overlap by even a single square inch of fabric with any other claim.
        /// If you can somehow draw attention to it, maybe the Elves will be able to make Santa's suit after all!
        /// 
        /// For example, in the claims above, only claim 3 is intact after all claims are made.
        /// 
        /// What is the ID of the only claim that doesn't overlap?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;
            int size = 1050;
            string[,] a = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    a[i, j] = " ";
                }
            }

            HashSet<int> ids = Enumerable.Range(1, 1317).ToHashSet();
            HashSet<int> ids0 = [];

            foreach (string item in input)
            {
                int id = int.Parse(item.Split(' ')[0].Replace("#", ""));

                int x = int.Parse(item.Split(' ')[2].Replace(":", "").Split(',')[1]);
                int y = int.Parse(item.Split(' ')[2].Replace(":", "").Split(',')[0]);

                int w = int.Parse(item.Split(' ')[3].Split('x')[0]);
                int h = int.Parse(item.Split(' ')[3].Split('x')[1]);

                for (int i = x; i < x + h; i++)
                {
                    for (int j = y; j < y + w; j++)
                    {
                        if (a[i, j] != " ")
                        {
                            if (a[i, j] != "X")
                            {
                                ids0.Add(int.Parse(a[i, j]));
                                r++;
                            }
                            a[i, j] = "X";
                            ids0.Add(id);
                        }
                        else a[i, j] = $"{id}";
                    }
                }
            }

            foreach (int item in ids0)
            {
                ids.Remove(item);
            }

            foreach (int item in ids)
            {
                r = item;
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _03_NoMatterHowYouSliceIt(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_NoMatterHowYouSliceIt));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}