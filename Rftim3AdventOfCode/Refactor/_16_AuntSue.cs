using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _16_AuntSue : I_16_AuntSue
    {
        #region Static
        private readonly List<string>? data;

        public _16_AuntSue()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_16_AuntSue));
        }

        /// <summary>
        /// Your Aunt Sue has given you a wonderful gift, and you'd like to send her a thank you card. 
        /// However, there's a small problem: she signed it "From, Aunt Sue".
        /// You have 500 Aunts named "Sue".
        /// So, to avoid sending the card to the wrong person, you need to figure out which Aunt Sue(which you conveniently number 1 to 500, for sanity) gave you the gift.
        /// You open the present and, as luck would have it, good ol' Aunt Sue got you a My First Crime Scene Analysis Machine! 
        /// Just what you wanted. Or needed, as the case may be.
        /// 
        /// The My First Crime Scene Analysis Machine (MFCSAM for short) can detect a few specific compounds in a given sample, 
        /// as well as how many distinct kinds of those compounds there are.According to the instructions, these are what the MFCSAM can detect:
        /// 
        /// children, by human DNA age analysis.
        /// cats.It doesn't differentiate individual breeds.
        /// 
        /// Several seemingly random breeds of dog: samoyeds, pomeranians, akitas, and vizslas.
        /// 
        /// goldfish.No other kinds of fish.
        /// trees, all in one group.
        /// cars, presumably by exhaust or gasoline or something.
        /// perfumes, which is handy, since many of your Aunts Sue wear a few kinds.
        /// 
        /// In fact, many of your Aunts Sue have many of these.You put the wrapping from the gift into the MFCSAM. 
        /// It beeps inquisitively at you a few times and then prints out a message on ticker tape:
        /// 
        /// children: 3
        /// cats: 7
        /// samoyeds: 2
        /// pomeranians: 3
        /// akitas: 0
        /// vizslas: 0
        /// goldfish: 5
        /// trees: 3
        /// cars: 2
        /// perfumes: 1
        /// 
        /// You make a list of the things you can remember about each Aunt Sue. Things missing from your list aren't zero - you simply don't remember the value.
        /// What is the number of the Sue that got you the gift?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = 0;

            List<string> aunts =
            [
                "children: 3",
                "cats: 7",
                "samoyeds: 2",
                "pomeranians: 3",
                "akitas: 0",
                "vizslas: 0",
                "goldfish: 5",
                "trees: 3",
                "cars: 2",
                "perfumes: 1"
            ];

            foreach (string item in input)
            {
                int nr = int.Parse(item.Split(' ')[1][..^1]);
                string obj1 = item.Split(' ')[2][..^1];
                int obj1i = int.Parse(item.Split(' ')[3][..^1]);
                string obj2 = item.Split(' ')[4][..^1];
                int obj2i = int.Parse(item.Split(' ')[5][..^1]);
                string obj3 = item.Split(' ')[6][..^1];
                int obj3i = int.Parse(item.Split(' ')[7]);

                int c = 0;

                foreach (string item1 in aunts)
                {
                    if ((obj1 == "cats" || obj1 == "trees") && item1.Split(' ')[0][..^1] == obj1 && int.Parse(item1.Split(' ')[1]) < obj1i ||
                        (obj1 == "pomeranians" || obj1 == "goldfish") && item1.Split(' ')[0][..^1] == obj1 && int.Parse(item1.Split(' ')[1]) > obj1i ||
                        obj1 != "cats" && obj1 != "trees" && obj1 != "pomeranians" && obj1 != "goldfish" && item1.Split(' ')[0][..^1] == obj1 && int.Parse(item1.Split(' ')[1]) == obj1i)
                    {
                        c++;
                    }
                }
                foreach (string item1 in aunts)
                {
                    if ((obj2 == "cats" || obj2 == "trees") && item1.Split(' ')[0][..^1] == obj2 && int.Parse(item1.Split(' ')[1]) < obj2i ||
                        (obj2 == "pomeranians" || obj2 == "goldfish") && item1.Split(' ')[0][..^1] == obj2 && int.Parse(item1.Split(' ')[1]) > obj2i ||
                        obj2 != "cats" && obj2 != "trees" && obj1 != "pomeranians" && obj1 != "goldfish" && item1.Split(' ')[0][..^1] == obj2 && int.Parse(item1.Split(' ')[1]) == obj2i)
                    {
                        c++;
                    }
                }
                foreach (string item1 in aunts)
                {
                    if ((obj3 == "cats" || obj3 == "trees") && item1.Split(' ')[0][..^1] == obj3 && int.Parse(item1.Split(' ')[1]) < obj3i ||
                        (obj3 == "pomeranians" || obj3 == "goldfish") && item1.Split(' ')[0][..^1] == obj3 && int.Parse(item1.Split(' ')[1]) > obj3i ||
                        obj3 != "cats" && obj3 != "trees" && obj1 != "pomeranians" && obj1 != "goldfish" && item1.Split(' ')[0][..^1] == obj3 && int.Parse(item1.Split(' ')[1]) == obj3i)
                    {
                        c++;
                    }
                }

                if (c == 3) Console.WriteLine($"{nr}: {obj1} {obj1i} {obj2} {obj2i} {obj3} {obj3i}");
            }

            return r;
        }

        /// <summary>
        /// As you're about to send the thank you note, something in the MFCSAM's instructions catches your eye. 
        /// Apparently, it has an outdated retroencabulator, and so the output from the machine isn't exact values - some of them indicate ranges.
        /// In particular, the cats and trees readings indicates that there are greater than that many 
        /// (due to the unpredictable nuclear decay of cat dander and tree pollen), while the pomeranians and goldfish readings indicate 
        /// that there are fewer than that many(due to the modial interaction of magnetoreluctance).
        /// 
        /// What is the number of the real Aunt Sue?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = 0;

            List<string> aunts =
            [
                "children: 3",
                "cats: 7",
                "samoyeds: 2",
                "pomeranians: 3",
                "akitas: 0",
                "vizslas: 0",
                "goldfish: 5",
                "trees: 3",
                "cars: 2",
                "perfumes: 1"
            ];

            foreach (string item in input)
            {
                int nr = int.Parse(item.Split(' ')[1][..^1]);
                string obj1 = item.Split(' ')[2][..^1];
                int obj1i = int.Parse(item.Split(' ')[3][..^1]);
                string obj2 = item.Split(' ')[4][..^1];
                int obj2i = int.Parse(item.Split(' ')[5][..^1]);
                string obj3 = item.Split(' ')[6][..^1];
                int obj3i = int.Parse(item.Split(' ')[7]);

                int c = 0;

                foreach (string item1 in aunts)
                {
                    if ((obj1 == "cats" || obj1 == "trees") && item1.Split(' ')[0][..^1] == obj1 && int.Parse(item1.Split(' ')[1]) < obj1i ||
                        (obj1 == "pomeranians" || obj1 == "goldfish") && item1.Split(' ')[0][..^1] == obj1 && int.Parse(item1.Split(' ')[1]) > obj1i ||
                        obj1 != "cats" && obj1 != "trees" && obj1 != "pomeranians" && obj1 != "goldfish" && item1.Split(' ')[0][..^1] == obj1 && int.Parse(item1.Split(' ')[1]) == obj1i)
                    {
                        c++;
                    }
                }
                foreach (string item1 in aunts)
                {
                    if ((obj2 == "cats" || obj2 == "trees") && item1.Split(' ')[0][..^1] == obj2 && int.Parse(item1.Split(' ')[1]) < obj2i ||
                        (obj2 == "pomeranians" || obj2 == "goldfish") && item1.Split(' ')[0][..^1] == obj2 && int.Parse(item1.Split(' ')[1]) > obj2i ||
                        obj2 != "cats" && obj2 != "trees" && obj1 != "pomeranians" && obj1 != "goldfish" && item1.Split(' ')[0][..^1] == obj2 && int.Parse(item1.Split(' ')[1]) == obj2i)
                    {
                        c++;
                    }
                }
                foreach (string item1 in aunts)
                {
                    if ((obj3 == "cats" || obj3 == "trees") && item1.Split(' ')[0][..^1] == obj3 && int.Parse(item1.Split(' ')[1]) < obj3i ||
                        (obj3 == "pomeranians" || obj3 == "goldfish") && item1.Split(' ')[0][..^1] == obj3 && int.Parse(item1.Split(' ')[1]) > obj3i ||
                        obj3 != "cats" && obj3 != "trees" && obj1 != "pomeranians" && obj1 != "goldfish" && item1.Split(' ')[0][..^1] == obj3 && int.Parse(item1.Split(' ')[1]) == obj3i)
                    {
                        c++;
                    }
                }

                if (c == 3) Console.WriteLine($"{nr}: {obj1} {obj1i} {obj2} {obj2i} {obj3} {obj3i}");
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

        public _16_AuntSue(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_16_AuntSue));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}