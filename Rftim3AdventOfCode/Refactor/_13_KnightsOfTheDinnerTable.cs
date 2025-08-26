using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _13_KnightsOfTheDinnerTable : I_13_KnightsOfTheDinnerTable
    {
        #region Static
        private readonly List<string>? data;

        public _13_KnightsOfTheDinnerTable()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_13_KnightsOfTheDinnerTable));
        }

        /// <summary>
        /// In years past, the holiday feast with your family hasn't gone so well. 
        /// Not everyone gets along! This year, you resolve, will be different.
        /// You're going to find the optimal seating arrangement and avoid all those awkward conversations.
        /// You start by writing up a list of everyone invited and the amount their happiness would increase or decrease if they were to find themselves sitting next to each other person.
        /// You have a circular table that will be just big enough to fit everyone comfortably, and so each person will have exactly two neighbors.
        /// 
        /// For example, suppose you have only four attendees planned, and you calculate their potential happiness as follows:
        /// 
        /// Alice would gain 54 happiness units by sitting next to Bob.
        /// Alice would lose 79 happiness units by sitting next to Carol.
        /// Alice would lose 2 happiness units by sitting next to David.
        /// Bob would gain 83 happiness units by sitting next to Alice.
        /// Bob would lose 7 happiness units by sitting next to Carol.
        /// Bob would lose 63 happiness units by sitting next to David.
        /// Carol would lose 62 happiness units by sitting next to Alice.
        /// Carol would gain 60 happiness units by sitting next to Bob.
        /// Carol would gain 55 happiness units by sitting next to David.
        /// David would gain 46 happiness units by sitting next to Alice.
        /// David would lose 7 happiness units by sitting next to Bob.
        /// David would gain 41 happiness units by sitting next to Carol.
        /// 
        /// Then, if you seat Alice next to David, Alice would lose 2 happiness units (because David talks so much), 
        /// but David would gain 46 happiness units(because Alice is such a good listener), for a total change of 44.
        /// 
        /// If you continue around the table, you could then seat Bob next to Alice(Bob gains 83, Alice gains 54). 
        /// Finally, seat Carol, who sits next to Bob(Carol gains 60, Bob loses 7) and David(Carol gains 55, David gains 41). The arrangement looks like this:
        ///      +41 +46
        /// +55   David    -2
        /// Carol Alice
        /// +60    Bob    +54
        ///      -7  +83
        ///      
        /// After trying every other seating arrangement in this hypothetical scenario, you find that this one is the most optimal, with a total change in happiness of 330.
        /// What is the total change in happiness for the optimal seating arrangement of the actual guest list?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<string> names = [];

            foreach (string item in input)
            {
                if (!names.Contains(item.Split(' ')[0])) names.Add(item.Split(' ')[0]);
            }

            foreach (string item in names) Console.WriteLine(item);

            IEnumerable<IEnumerable<string>> result = GetPermutations(names, names.Count);

            int f = 0;

            foreach (IEnumerable<string> item in result)
            {
                int r = 0;
                List<string> x = item.ToList();

                for (int i = 0; i < x.Count - 1; i++)
                {
                    Console.Write($"{x[i]} ");
                    if (i == 0)
                    {
                        foreach (string item2 in input)
                        {
                            string name1 = item2.Split(' ')[0];
                            string name2 = item2.Split(' ')[10][..^1];
                            string op = item2.Split(' ')[2];
                            int hap = int.Parse(item2.Split(' ')[3]);

                            if (x[i] == name1 && x[^1] == name2 || x[i] == name2 && x[^1] == name1)
                            {
                                if (op == "lose") r -= hap;
                                else r += hap;
                            }

                            if (x[i] == name1 && x[i + 1] == name2 || x[i] == name2 && x[i + 1] == name1)
                            {
                                if (op == "lose") r -= hap;
                                else r += hap;
                            }
                        }
                    }
                    else
                    {
                        foreach (string item2 in input)
                        {
                            string name1 = item2.Split(' ')[0];
                            string name2 = item2.Split(' ')[10][..^1];
                            string op = item2.Split(' ')[2];
                            int hap = int.Parse(item2.Split(' ')[3]);

                            if (x[i] == name1 && x[i + 1] == name2 || x[i] == name2 && x[i + 1] == name1)
                            {
                                if (op == "lose") r -= hap;
                                else r += hap;
                            }
                        }
                    }
                }

                if (r > f) f = r;
                Console.Write(r);
                Console.WriteLine();
            }

            return f;
        }

        /// <summary>
        /// In all the commotion, you realize that you forgot to seat yourself. At this point, you're pretty apathetic toward the whole thing, 
        /// and your happiness wouldn't really go up or down regardless of who you sit next to. 
        /// You assume everyone else would be just as ambivalent about sitting next to you, too.
        /// 
        /// So, add yourself to the list, and give all happiness relationships that involve you a score of 0.
        /// 
        /// What is the total change in happiness for the optimal seating arrangement that actually includes yourself?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            input.Add("Me would gain 0 happiness units by sitting next to Alice.");
            input.Add("Me would lose 0 happiness units by sitting next to Bob.");
            input.Add("Me would lose 0 happiness units by sitting next to Carol.");
            input.Add("Me would lose 0 happiness units by sitting next to David.");
            input.Add("Me would gain 0 happiness units by sitting next to Eric.");
            input.Add("Me would lose 0 happiness units by sitting next to Frank.");
            input.Add("Me would lose 0 happiness units by sitting next to George.");
            input.Add("Me would lose 0 happiness units by sitting next to Mallory.");

            List<string> names = [];

            foreach (string item in input)
            {
                if (!names.Contains(item.Split(' ')[0])) names.Add(item.Split(' ')[0]);
            }

            foreach (string item in names) Console.WriteLine(item);

            IEnumerable<IEnumerable<string>> result = GetPermutations(names, names.Count);

            int f = 0;

            foreach (IEnumerable<string> item in result)
            {
                int r = 0;
                List<string> x = item.ToList();

                for (int i = 0; i < x.Count - 1; i++)
                {
                    Console.Write($"{x[i]} ");
                    if (i == 0)
                    {
                        foreach (string item2 in input)
                        {
                            string name1 = item2.Split(' ')[0];
                            string name2 = item2.Split(' ')[10][..^1];
                            string op = item2.Split(' ')[2];
                            int hap = int.Parse(item2.Split(' ')[3]);

                            if (x[i] == name1 && x[^1] == name2 || x[i] == name2 && x[^1] == name1)
                            {
                                if (op == "lose") r -= hap;
                                else r += hap;
                            }

                            if (x[i] == name1 && x[i + 1] == name2 || x[i] == name2 && x[i + 1] == name1)
                            {
                                if (op == "lose") r -= hap;
                                else r += hap;
                            }
                        }
                    }
                    else
                    {
                        foreach (string item2 in input)
                        {
                            string name1 = item2.Split(' ')[0];
                            string name2 = item2.Split(' ')[10][..^1];
                            string op = item2.Split(' ')[2];
                            int hap = int.Parse(item2.Split(' ')[3]);

                            if (x[i] == name1 && x[i + 1] == name2 || x[i] == name2 && x[i + 1] == name1)
                            {
                                if (op == "lose") r -= hap;
                                else r += hap;
                            }
                        }
                    }
                }

                if (r > f) f = r;
                Console.Write(r);
                Console.WriteLine();
            }

            return f;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat([t2]));
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _13_KnightsOfTheDinnerTable(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_13_KnightsOfTheDinnerTable));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}