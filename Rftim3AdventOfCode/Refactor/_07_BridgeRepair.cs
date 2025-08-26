using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Diagnostics.CodeAnalysis;

namespace Rftim3AdventOfCode.Refactor
{
    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null || y == null)
                return false;
            return x.SequenceEqual(y);
        }

        public int GetHashCode([DisallowNull] List<int> obj)
        {
            if (obj == null)
                return 0;
            
            int hash = 17;
            
            foreach (int item in obj)
            {
                hash = hash * 31 + item.GetHashCode();
            }

            return hash;
        }
    }

    public class _07_BridgeRepair : I_07_BridgeRepair
    {
        #region Static
        private readonly List<string>? data;
        private static List<List<int>>? perms;
        private static int level;

        public _07_BridgeRepair()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_07_BridgeRepair));
        }

        /// <summary>
        /// The Historians take you to a familiar rope bridge over a river in the middle of a jungle. 
        /// The Chief isn't on this side of the bridge, though; maybe he's on the other side?
        /// When you go to cross the bridge, you notice a group of engineers trying to repair it. (Apparently, it breaks pretty frequently.) 
        /// You won't be able to cross until it's fixed.
        /// You ask how long it'll take; the engineers tell you that it only needs final calibrations, but some young elephants were playing nearby and stole all the operators 
        /// from their calibration equations! 
        /// They could finish the calibrations if only someone could determine which test values could possibly be produced by placing any combination of operators into their calibration equations 
        /// (your puzzle input).
        /// 
        /// For example:
        /// 
        /// 190: 10 19
        /// 3267: 81 40 27
        /// 83: 17 5
        /// 156: 15 6
        /// 7290: 6 8 6 15
        /// 161011: 16 10 13
        /// 192: 17 8 14
        /// 21037: 9 7 18 13
        /// 292: 11 6 16 20
        /// Each line represents a single equation.The test value appears before the colon on each line; it is your job to determine whether the remaining numbers can be combined with operators 
        /// to produce the test value.
        /// Operators are always evaluated left-to-right, not according to precedence rules.Furthermore, numbers in the equations cannot be rearranged.
        /// Glancing into the jungle, you can see elephants holding two different types of operators: add (+) and multiply(*).
        /// 
        /// Only three of the above equations can be made true by inserting operators:
        /// 
        /// 190: 10 19 has only one position that accepts an operator: between 10 and 19. Choosing + would give 29, but choosing * would give the test value (10 * 19 = 190).
        /// 3267: 81 40 27 has two positions for operators.Of the four possible configurations of the operators, two cause the right side to match the test value: 81 + 40 * 27 and 81 * 40 + 27 both 
        /// equal 3267 (when evaluated left-to-right)!
        /// 292: 11 6 16 20 can be solved in exactly one way: 11 + 6 * 16 + 20.
        /// The engineers just need the total calibration result, which is the sum of the test values from just the equations that could possibly be true. 
        /// In the above example, the sum of the test values for the three equations listed above is 3749.
        /// 
        /// Determine which equations could possibly be true. What is their total calibration result?
        /// </summary>
        [Benchmark]
        public long PartOne() => PartOne0(data!);

        private static long PartOne0(List<string> input)
        {
            long res = 0;

            foreach (string item in input)
            {
                Console.WriteLine(item);
                long a = long.Parse(item.Split(":")[0]);
                List<long> b = [.. item.Split(":")[1].Split(" ")[1..].Select(long.Parse)];
                List<List<int>> q = [];
                perms = [];
                level = -1;

                bool f = true;
                for (int i = 0; i <= b.Count; i++)
                {
                    List<int> p = [];
                    p.AddRange(Enumerable.Repeat(0, i));
                    p.AddRange(Enumerable.Repeat(1, b.Count - i));

                    List<List<int>> r = Permute(p, 0, b.Count - 1);
                    q.AddRange(r);
                }

                List<List<int>> w = q.Distinct(new ListComparer()).ToList();

                foreach (List<int> item1 in w)
                {
                    if (f)
                    {
                        long c = 0;
                        for (int k = 0; k < item1.Count; k++)
                        {
                            if (item1[k] == 1)
                            {
                                if (k == 0)
                                    c = 1;
                                c *= b[k];
                            }
                            else
                                c += b[k];

                            if (c == a)
                            {
                                res += a;
                                f = false;
                                break;
                            }
                            //Console.WriteLine($"{a} {c}");
                        }
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// The engineers seem concerned; the total calibration result you gave them is nowhere close to being within safety tolerances. 
        /// Just then, you spot your mistake: some well-hidden elephants are holding a third type of operator.
        /// The concatenation operator (||) combines the digits from its left and right inputs into a single number.
        /// For example, 12 || 345 would become 12345. All operators are still evaluated left-to-right.
        /// Now, apart from the three equations that could be made true using only addition and multiplication, 
        /// the above example has three more equations that can be made true by inserting operators:
        /// 
        /// 156: 15 6 can be made true through a single concatenation: 15 || 6 = 156.
        /// 7290: 6 8 6 15 can be made true using 6 * 8 || 6 * 15.
        /// 192: 17 8 14 can be made true using 17 || 8 + 14.
        /// Adding up all six test values(the three that could be made before using only + and* plus the new three that can now be made by also using ||) 
        /// produces the new total calibration result of 11387.
        /// 
        /// Using your new knowledge of elephant hiding spots, determine which equations could possibly be true. What is their total calibration result?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            return 0;
        }

        private static List<List<int>> Permute(List<int> nums, int l, int r)
        {
            if (l == r)
            {
                perms.Add([]);
                level++;
                foreach (int item in nums)
                {
                    perms[level].Add(item);
                }
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    nums = Swap(nums, l, i);
                    Permute(nums, l + 1, r);
                    nums = Swap(nums, l, i);
                }
            }

            return perms;
        }

        private static List<int> Swap(List<int> nums, int i, int j)
        {
            (nums[j], nums[i]) = (nums[i], nums[j]);

            return nums;
        }
        #endregion

        #region UnitTest
        public static long PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _07_BridgeRepair(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_07_BridgeRepair));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}