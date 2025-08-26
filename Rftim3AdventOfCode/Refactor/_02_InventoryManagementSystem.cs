using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _02_InventoryManagementSystem : I_02_InventoryManagementSystem
    {
        #region Static
        private readonly List<string>? data;

        public _02_InventoryManagementSystem()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_02_InventoryManagementSystem));
        }

        /// <summary>
        /// You stop falling through time, catch your breath, and check the screen on the device. "Destination reached. 
        /// Current Year: 1518. Current Location: North Pole Utility Closet 83N10." You made it! Now, to find those anomalies.
        /// 
        /// Outside the utility closet, you hear footsteps and a voice. "...I'm not sure either. 
        /// But now that so many people have chimneys, maybe he could sneak in that way?" 
        /// Another voice responds, "Actually, we've been working on a new kind of suit that would let him fit through tight spaces like that. 
        /// But, I heard that a few days ago, they lost the prototype fabric, the design plans, everything!
        /// Nobody on the team can even seem to remember important details of the project!"
        /// 
        /// "Wouldn't they have had enough fabric to fill several boxes in the warehouse? They'd be stored together, so the box IDs should be similar.
        /// Too bad it would take forever to search the warehouse for two similar box IDs..." They walk too far away to hear any more.
        /// 
        /// Late at night, you sneak to the warehouse - who knows what kinds of paradoxes you could cause if you were discovered - 
        /// and use your fancy wrist device to quickly scan every box and produce a list of the likely candidates(your puzzle input).
        /// 
        /// To make sure you didn't miss any, you scan the likely candidate boxes again, counting the number that have an ID containing exactly two 
        /// of any letter and then separately counting those with exactly three of any letter. 
        /// You can multiply those two counts together to get a rudimentary checksum and compare it to what your device predicts.
        /// 
        /// For example, if you see the following box IDs:
        /// 
        /// abcdef contains no letters that appear exactly two or three times.
        /// bababc contains two a and three b, so it counts for both.
        /// abbcde contains two b, but no letter appears exactly three times.
        /// abcccd contains three c, but no letter appears exactly two times.
        /// aabcdd contains two a and two d, but it only counts once.
        /// abcdee contains two e.
        /// ababab contains three a and three b, but it only counts once.
        /// 
        /// Of these box IDs, four of them contain a letter which appears exactly twice, and three of them contain a letter which appears exactly three times. 
        /// Multiplying these together produces a checksum of 4 * 3 = 12.
        /// 
        /// What is the checksum for your list of box IDs?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int a = 0;
            int b = 0;

            foreach (string item in input)
            {
                Dictionary<char, int> kvp = [];
                foreach (char item1 in item)
                {
                    if (kvp.TryGetValue(item1, out int value)) kvp[item1] = ++value;
                    else kvp[item1] = 1;
                }

                bool a0 = false, b0 = false;
                foreach (KeyValuePair<char, int> item1 in kvp)
                {
                    if (item1.Value == 2) a0 = true;
                    if (item1.Value == 3) b0 = true;
                }

                if (a0) a++;
                if (b0) b++;
            }

            return a * b;
        }

        /// <summary>
        /// Confident that your list of box IDs is complete, you're ready to find the boxes full of prototype fabric.
        /// 
        /// The boxes will have IDs which differ by exactly one character at the same position in both strings.
        /// For example, given the following box IDs:
        /// 
        /// abcde
        /// fghij
        /// klmno
        /// pqrst
        /// fguij
        /// axcye
        /// wvxyz
        /// 
        /// The IDs abcde and axcye are close, but they differ by two characters (the second and fourth). 
        /// However, the IDs fghij and fguij differ by exactly one character, the third(h and u). 
        /// Those must be the correct boxes.
        /// 
        /// What letters are common between the two correct box IDs? (In the example above, 
        /// this is found by removing the differing character from either ID, producing fgij.)
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            string r = string.Empty;

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    int c = 0;
                    int t = 0;
                    for (int k = 0; k < input[i].Length; k++)
                    {
                        if (input[i][k] != input[j][k])
                        {
                            c++;
                            t = k;
                        }
                    }
                    if (c == 1)
                    {
                        StringBuilder sb = new(input[i]);
                        sb.Remove(t, 1);

                        return sb.ToString();
                    }
                }
            }

            return r;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _02_InventoryManagementSystem(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_02_InventoryManagementSystem));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}