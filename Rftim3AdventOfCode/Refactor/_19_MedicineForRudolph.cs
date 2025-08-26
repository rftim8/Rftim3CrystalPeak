using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _19_MedicineForRudolph : I_19_MedicineForRudolph
    {
        #region Static
        private readonly List<string>? data;

        public _19_MedicineForRudolph()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_19_MedicineForRudolph));
        }

        /// <summary>
        /// Rudolph the Red-Nosed Reindeer is sick! His nose isn't shining very brightly, and he needs medicine.
        /// Red-Nosed Reindeer biology isn't similar to regular reindeer biology; 
        /// Rudolph is going to need custom-made medicine.Unfortunately, Red-Nosed Reindeer chemistry isn't similar to regular reindeer chemistry, either.
        /// The North Pole is equipped with a Red-Nosed Reindeer nuclear fusion/fission plant, capable of constructing any Red-Nosed Reindeer molecule you need.
        /// It works by starting with some input molecule and then doing a series of replacements, one per step, until it has the right molecule.
        /// However, the machine has to be calibrated before it can be used.
        /// Calibration involves determining the number of molecules that can be generated in one step from a given starting point.
        /// 
        /// For example, imagine a simpler machine that supports only the following replacements:
        /// 
        /// H => HO
        /// H => OH
        /// O => HH
        /// 
        /// Given the replacements above and starting with HOH, the following molecules could be generated:
        /// 
        /// HOOH (via H => HO on the first H).
        /// HOHO(via H => HO on the second H).
        /// OHOH(via H => OH on the first H).
        /// HOOH(via H => OH on the second H).
        /// HHHH(via O => HH).
        ///         
        /// So, in the example above, there are 4 distinct molecules(not five, because HOOH appears twice) after one replacement from HOH.Santa's favorite molecule, HOHOHO, can become 7 distinct molecules (over nine replacements: six from H, and three from O).
        /// 
        /// The machine replaces without regard for the surrounding characters.For example, given the string H2O, the transition H => OO would result in OO2O.
        /// 
        /// Your puzzle input describes all of the possible replacements and, at the bottom, the medicine molecule for which you need to calibrate the machine.How many distinct molecules can be created after all the different ways you can do one replacement on the medicine molecule?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string mol = input[^1];
            List<string> r = [];

            foreach (string item in input.SkipLast(2))
            {
                string rep = item.Split(' ')[0];
                string root = item.Split(' ')[2];

                Console.WriteLine(item);
                for (int i = 0; i < mol.Length; i++)
                {
                    if (i + rep.Length <= mol.Length)
                    {
                        if (mol[i..(i + rep.Length)] == rep)
                        {
                            string z = $"{mol[..i]}{root}{mol[(i + rep.Length)..]}";
                            r.Add(z);
                            Console.WriteLine(z);
                        }
                    }
                }
                Console.WriteLine();

            }

            return r.Distinct().Count();
        }

        /// <summary>
        /// Now that the machine is calibrated, you're ready to begin molecule fabrication.
        /// Molecule fabrication always begins with just a single electron, e, and applying replacements one at a time, just like the ones during calibration.
        /// 
        /// For example, suppose you have the following replacements:
        /// 
        /// e => H
        /// e => O
        /// H => HO
        /// H => OH
        /// O => HH
        /// If you'd like to make HOH, you start with e, and then make the following replacements:
        /// 
        /// e => O to get O
        /// O => HH to get HH
        /// H => OH (on the second H) to get HOH
        /// So, you could make HOH after 3 steps.Santa's favorite molecule, HOHOHO, can be made in 6 steps.
        /// 
        /// How long will it take to make the medicine? Given the available replacements and the medicine molecule in your puzzle input, what is the fewest number of steps to go from e to the medicine molecule?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            Random rng = new();
            string molecule = input[^1];
            List<(string, string)> r = [];

            foreach (string item in input.SkipLast(2))
            {
                r.Add((item.Split(' ')[0], item.Split(' ')[2]));
            }

            int count = 0, shuffles = 0;
            string mol = molecule;

            while (mol.Length > 1)
            {
                string start = mol;
                for (int i = 0; i < r.Count; i++)
                {
                    while (mol.Contains(r[i].Item2))
                    {
                        count += mol.Split(r[i].Item2).Length - 1;
                        mol = mol.Replace(r[i].Item2, r[i].Item1);
                    }
                }

                if (start == mol)
                {
                    r = [.. r.OrderBy(a => rng.Next())];
                    mol = molecule;
                    count = 0;
                    shuffles += 1;
                }
            }

            Console.WriteLine($"Transforms: {count} after {shuffles} shuffles");

            return count;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _19_MedicineForRudolph(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_19_MedicineForRudolph));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}