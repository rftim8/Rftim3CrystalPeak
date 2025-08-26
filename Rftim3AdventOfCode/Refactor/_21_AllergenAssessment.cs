using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _21_AllergenAssessment : I_21_AllergenAssessment
    {
        #region Static
        private readonly List<string>? data;

        public _21_AllergenAssessment()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_21_AllergenAssessment));
        }

        /// <summary>
        /// You reach the train's last stop and the closest you can get to your vacation island without getting wet. 
        /// There aren't even any boats here, but nothing can stop you now: you build a raft. You just need a few days' worth of food for your journey.
        /// 
        /// You don't speak the local language, so you can't read any ingredients lists.However, sometimes, allergens are listed in a language you do understand.
        /// You should be able to use this information to determine which ingredient contains which allergen and work out which foods are safe to take with you on your trip.
        /// You start by compiling a list of foods(your puzzle input), one food per line.
        /// Each line includes that food's ingredients list followed by some or all of the allergens the food contains.
        /// 
        /// Each allergen is found in exactly one ingredient.Each ingredient contains zero or one allergen.Allergens aren't always marked;
        /// when they're listed (as in (contains nuts, shellfish) after an ingredients list), the ingredient that contains each listed allergen will be 
        /// somewhere in the corresponding ingredients list.However, even if an allergen isn't listed, 
        /// the ingredient that contains that allergen could still be present: maybe they forgot to label it, or maybe it was labeled in a language you don't know.
        /// 
        /// For example, consider the following list of foods:
        /// 
        /// mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
        /// trh fvjkl sbzzf mxmxvkd (contains dairy)
        /// sqjhc fvjkl (contains soy)
        /// sqjhc mxmxvkd sbzzf (contains fish)
        /// The first food in the list has four ingredients (written in a language you don't understand): mxmxvkd, kfcds, sqjhc, and nhms. 
        /// While the food might contain other allergens, a few allergens the food definitely contains are listed afterward: dairy and fish.
        /// 
        /// The first step is to determine which ingredients can't possibly contain any of the allergens in any food in your list. 
        /// In the above example, none of the ingredients kfcds, nhms, sbzzf, or trh can contain an allergen. 
        /// Counting the number of times any of these ingredients appear in any ingredients list produces 5: they all appear once each except sbzzf, which appears twice.
        /// 
        /// Determine which ingredients cannot possibly contain any of the allergens in your list. How many times do any of those ingredients appear?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Dictionary<string, (string allergen, int number)> ingredients = [];
            Dictionary<string, List<string>> allergens = [];

            foreach (string food in input)
            {
                string foodIngredients = food.Split(" (contains ")[0];
                string foodAllergens = food.Replace(")", " ").Split(" (contains ")[1];
                foreach (string allergen in foodAllergens.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (allergens.TryGetValue(allergen, out List<string>? value)) value.RemoveAll(a => value.Except(foodIngredients.Split(' ')).Contains(a));
                    else allergens.Add(allergen, [.. foodIngredients.Split(' ')]);
                }

                foreach (string ingredient in foodIngredients.Split(' '))
                {
                    if (ingredients.TryGetValue(ingredient, out (string allergen, int number) value)) ingredients[ingredient] = ("", value.number + 1);
                    else ingredients[ingredient] = ("", 1);
                }
            }

            while (allergens.Values.Any(l => l.Count > 1))
            {
                foreach ((List<string> ingredient, string multiple) in from List<string> ingredient in allergens.Values.Where(l => l.Count == 1).ToArray()
                                                                       from string multiple in allergens.Keys.Where(a => allergens[a].Count > 1 && allergens[a].Contains(ingredient[0]))
                                                                       select (ingredient, multiple))
                {
                    allergens[multiple].Remove(ingredient[0]);
                }
            }

            foreach (string allergen in allergens.Keys)
            {
                string ingredient = allergens[allergen][0];
                ingredients[ingredient] = (allergen, ingredients[ingredient].number);
            }

            string canonical = string.Empty;
            foreach (KeyValuePair<string, (string, int)> food in ingredients.Where(i => i.Value.allergen != "").OrderBy(i => i.Value.allergen))
            {
                canonical += food.Key + ',';
            }

            return ingredients.Where(i => i.Value.allergen == "").Sum(i => i.Value.number);
        }

        /// <summary>
        /// Now that you've isolated the inert ingredients, you should have enough information to figure out which ingredient contains which allergen.
        /// 
        /// In the above example:
        /// 
        /// mxmxvkd contains dairy.
        /// sqjhc contains fish.
        /// fvjkl contains soy.
        /// Arrange the ingredients alphabetically by their allergen and separate them by commas to produce your canonical dangerous ingredient list.
        /// (There should not be any spaces in your canonical dangerous ingredient list.) In the above example, this would be mxmxvkd,sqjhc,fvjkl.
        /// 
        /// Time to stock your raft with supplies.What is your canonical dangerous ingredient list?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            Dictionary<string, (string allergen, int number)> ingredients = [];
            Dictionary<string, List<string>> allergens = [];

            foreach (string food in input)
            {
                string foodIngredients = food.Split(" (contains ")[0];
                string foodAllergens = food.Replace(")", " ").Split(" (contains ")[1];
                foreach (string allergen in foodAllergens.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (allergens.TryGetValue(allergen, out List<string>? value)) value.RemoveAll(a => value.Except(foodIngredients.Split(' ')).Contains(a));
                    else allergens.Add(allergen, [.. foodIngredients.Split(' ')]);
                }

                foreach (string ingredient in foodIngredients.Split(' '))
                {
                    if (ingredients.TryGetValue(ingredient, out (string allergen, int number) value)) ingredients[ingredient] = ("", value.number + 1);
                    else ingredients[ingredient] = ("", 1);
                }
            }

            while (allergens.Values.Any(l => l.Count > 1))
            {
                foreach ((List<string> ingredient, string multiple) in from List<string> ingredient in allergens.Values.Where(l => l.Count == 1).ToArray()
                                                                       from string multiple in allergens.Keys.Where(a => allergens[a].Count > 1 && allergens[a].Contains(ingredient[0]))
                                                                       select (ingredient, multiple))
                {
                    allergens[multiple].Remove(ingredient[0]);
                }
            }

            foreach (string allergen in allergens.Keys)
            {
                string ingredient = allergens[allergen][0];
                ingredients[ingredient] = (allergen, ingredients[ingredient].number);
            }

            string canonical = string.Empty;
            foreach (KeyValuePair<string, (string, int)> food in ingredients.Where(i => i.Value.allergen != "").OrderBy(i => i.Value.allergen))
            {
                canonical += food.Key + ',';
            }

            return canonical[0..^1].ToString();
        }

        private static readonly char[] separator = [' ', ',', ')'];
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _21_AllergenAssessment(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_21_AllergenAssessment));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}