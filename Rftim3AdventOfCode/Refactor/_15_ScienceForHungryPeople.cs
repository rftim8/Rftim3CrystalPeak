using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _15_ScienceForHungryPeople : I_15_ScienceForHungryPeople
    {
        #region Static
        private readonly List<string>? data;

        public _15_ScienceForHungryPeople()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_15_ScienceForHungryPeople));
        }

        /// <summary>
        /// Today, you set out on the task of perfecting your milk-dunking cookie recipe. All you have to do is find the right balance of ingredients.
        /// Your recipe leaves room for exactly 100 teaspoons of ingredients.
        /// You make a list of the remaining ingredients you could use to finish the recipe(your puzzle input) and their properties per teaspoon:
        /// 
        /// capacity(how well it helps the cookie absorb milk)
        /// durability(how well it keeps the cookie intact when full of milk)
        /// flavor(how tasty it makes the cookie)
        /// texture(how it improves the feel of the cookie)
        /// calories(how many calories it adds to the cookie)
        /// 
        /// You can only measure ingredients in whole-teaspoon amounts accurately, and you have to be accurate so you can reproduce your results in the future.
        /// The total score of a cookie can be found by adding up each of the properties (negative totals become 0) and then multiplying together everything except calories.
        /// 
        /// For instance, suppose you have these two ingredients:
        /// 
        /// Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
        /// Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
        /// 
        /// Then, choosing to use 44 teaspoons of butterscotch and 56 teaspoons of cinnamon(because the amounts of each ingredient must add up to 100) would result in a cookie 
        /// with the following properties:
        /// 
        /// A capacity of 44*-1 + 56*2 = 68
        /// A durability of 44*-2 + 56*3 = 80
        /// A flavor of 44*6 + 56*-2 = 152
        /// A texture of 44*3 + 56*-1 = 76
        /// 
        /// Multiplying these together(68 * 80 * 152 * 76, ignoring calories for now) results in a total score of 62842880,
        /// which happens to be the best score possible given these ingredients.
        /// If any properties had produced a negative total, it would have instead become zero, causing the whole score to multiply to zero.
        /// 
        /// Given the ingredients in your kitchen and their properties, what is the total score of the highest-scoring cookie you can make?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<string> names = [];
            List<int> capacity = [];
            List<int> durability = [];
            List<int> flavor = [];
            List<int> texture = [];
            List<int> calories = [];

            foreach (string item in input)
            {
                names.Add(item.Split(' ')[0]);
                capacity.Add(int.Parse(item.Replace(",", "").Split(' ')[2]));
                durability.Add(int.Parse(item.Replace(",", "").Split(' ')[4]));
                flavor.Add(int.Parse(item.Replace(",", "").Split(' ')[6]));
                texture.Add(int.Parse(item.Replace(",", "").Split(' ')[8]));
                calories.Add(int.Parse(item.Replace(",", "").Split(' ')[10]));
            }

            List<int> recepies = [];

            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = 1; k <= 100; k++)
                    {
                        for (int l = 1; l <= 100; l++)
                        {
                            if (i + j + k + l == 100)
                            {
                                List<int> x = [i, j, k, l];

                                int cap = 0;
                                int dur = 0;
                                int fla = 0;
                                int text = 0;

                                for (int m = 0; m < 4; m++)
                                {
                                    cap += capacity[m] * x[m];
                                    dur += durability[m] * x[m];
                                    fla += flavor[m] * x[m];
                                    text += texture[m] * x[m];
                                }

                                Console.WriteLine($"{cap} {dur} {fla} {text}");

                                int total = 0;
                                if (cap > 0 && dur > 0 && fla > 0 && text > 0) total = cap * dur * fla * text;

                                recepies.Add(total);
                            }
                        }
                    }
                }
            }

            return recepies.Max();
        }

        /// <summary>
        /// Your cookie recipe becomes wildly popular! Someone asks if you can make another recipe that has exactly 500 calories per cookie 
        /// (so they can use it as a meal replacement). Keep the rest of your award-winning process the same(100 teaspoons, same ingredients, same scoring system).
        /// 
        /// For example, given the ingredients above, if you had instead selected 40 teaspoons of butterscotch and 60 teaspoons of cinnamon(which still adds to 100), 
        /// the total calorie count would be 40*8 + 60*3 = 500. The total score would go down, though: only 57600000, the best you can do in such trying circumstances.
        /// 
        /// Given the ingredients in your kitchen and their properties, what is the total score of the highest-scoring cookie you can make with a calorie total of 500?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<string> names = [];
            List<int> capacity = [];
            List<int> durability = [];
            List<int> flavor = [];
            List<int> texture = [];
            List<int> calories = [];

            foreach (string item in input)
            {
                names.Add(item.Split(' ')[0]);
                capacity.Add(int.Parse(item.Replace(",", "").Split(' ')[2]));
                durability.Add(int.Parse(item.Replace(",", "").Split(' ')[4]));
                flavor.Add(int.Parse(item.Replace(",", "").Split(' ')[6]));
                texture.Add(int.Parse(item.Replace(",", "").Split(' ')[8]));
                calories.Add(int.Parse(item.Replace(",", "").Split(' ')[10]));
            }

            List<int> recepies = [];

            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    for (int k = 1; k <= 100; k++)
                    {
                        for (int l = 1; l <= 100; l++)
                        {
                            if (i + j + k + l == 100)
                            {
                                List<int> x = [i, j, k, l];

                                int cap = 0;
                                int dur = 0;
                                int fla = 0;
                                int text = 0;

                                for (int m = 0; m < 4; m++)
                                {
                                    cap += capacity[m] * x[m];
                                    dur += durability[m] * x[m];
                                    fla += flavor[m] * x[m];
                                    text += texture[m] * x[m];
                                }

                                Console.WriteLine($"{cap} {dur} {fla} {text}");

                                int total = 0;
                                if (cap > 0 && dur > 0 && fla > 0 && text > 0) total = cap * dur * fla * text;

                                int cal = 0;

                                for (int n = 0; n < 4; n++)
                                {
                                    cal += calories[n] * x[n];
                                }

                                if (cal == 500) recepies.Add(total);
                            }
                        }
                    }
                }
            }

            return recepies.Max();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _15_ScienceForHungryPeople(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_15_ScienceForHungryPeople));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}