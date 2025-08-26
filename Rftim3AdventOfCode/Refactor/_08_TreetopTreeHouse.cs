using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _08_TreetopTreeHouse : I_08_TreetopTreeHouse
    {
        #region Static
        private readonly List<string>? data;

        public _08_TreetopTreeHouse()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_08_TreetopTreeHouse));
        }

        /// <summary>
        /// The expedition comes across a peculiar patch of tall trees all planted carefully in a grid.The Elves explain that a previous expedition planted these trees as a reforestation effort.Now, they're curious if this would be a good location for a tree house.
        /// 
        /// First, determine whether there is enough tree cover here to keep a tree house hidden. To do this, you need to count the number of trees that are visible from outside the grid when looking directly along a row or column.
        /// 
        /// The Elves have already launched a quadcopter to generate a map with the height of each tree (your puzzle input). For example:
        /// 
        /// 30373
        /// 25512
        /// 65332
        /// 33549
        /// 35390
        /// Each tree is represented as a single digit whose value is its height, where 0 is the shortest and 9 is the tallest.
        /// 
        /// A tree is visible if all of the other trees between it and an edge of the grid are shorter than it.Only consider trees in the same row or column; that is, only look up, down, left, or right from any given tree.
        /// 
        /// All of the trees around the edge of the grid are visible - since they are already on the edge, there are no trees to block the view. In this example, that only leaves the interior nine trees to consider:
        /// 
        /// The top-left 5 is visible from the left and top. (It isn't visible from the right or bottom since other trees of height 5 are in the way.)
        /// The top-middle 5 is visible from the top and right.
        /// The top-right 1 is not visible from any direction; for it to be visible, there would need to only be trees of height 0 between it and an edge.
        /// The left-middle 5 is visible, but only from the right.
        /// The center 3 is not visible from any direction; for it to be visible, there would need to be only trees of at most height 2 between it and an edge.
        /// The right-middle 3 is visible from the right.
        /// In the bottom row, the middle 5 is visible, but the 3 and 4 are not.
        /// With 16 trees visible on the edge and another 5 visible in the interior, a total of 21 trees are visible in this arrangement.
        /// 
        /// Consider your map; how many trees are visible from outside the grid?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int ext = input[0].Length * 2 + input.Count * 2 - 4;
            int interior = 0;

            for (int i = 1; i < input.Count - 1; i++)
            {
                for (int j = 1; j < input[0].Length - 1; j++)
                {
                    bool top = true;
                    bool bottom = true;
                    bool left = true;
                    bool right = true;
                    string crt = input[i][j].ToString();

                    for (int k = 0; k < input.Count; k++)
                    {
                        for (int m = 0; m < input[0].Length; m++)
                        {
                            string crt1 = input[k][m].ToString();

                            if (!(i == k && j == m) && (i == k || j == m))
                            {
                                int c = int.Parse(crt);
                                int c1 = int.Parse(crt1);

                                if (i == k && j < m && c1 >= c) right = false;
                                if (i == k && j > m && c1 >= c) left = false;
                                if (j == m && i < k && c1 >= c) bottom = false;
                                if (j == m && i > k && c1 >= c) top = false;
                            }
                        }
                    }

                    if (top || bottom || left || right) interior++;
                }
            }

            Console.WriteLine($"Visible from outside: {ext}");
            Console.WriteLine($"Visible from inside: {interior}");

            return interior + ext;
        }

        /// <summary>
        /// Content with the amount of tree cover available, the Elves just need to know the best spot to build their tree house: they would like to be able to see a lot of trees.
        /// 
        /// To measure the viewing distance from a given tree, look up, down, left, and right from that tree; stop if you reach an edge or at the first tree that is the same height or taller than the tree under consideration. (If a tree is right on the edge, at least one of its viewing distances will be zero.)
        /// 
        /// The Elves don't care about distant trees taller than those found by the rules above; the proposed tree house has large eaves to keep it dry, so they wouldn't be able to see higher than the tree house anyway.
        /// 
        /// In the example above, consider the middle 5 in the second row:
        /// 
        /// 30373
        /// 25512
        /// 65332
        /// 33549
        /// 35390
        /// Looking up, its view is not blocked; it can see 1 tree(of height 3).
        /// Looking left, its view is blocked immediately; it can see only 1 tree(of height 5, right next to it).
        /// Looking right, its view is not blocked; it can see 2 trees.
        /// Looking down, its view is blocked eventually; it can see 2 trees(one of height 3, then the tree of height 5 that blocks its view).
        /// A tree's scenic score is found by multiplying together its viewing distance in each of the four directions. For this tree, this is 4 (found by multiplying 1 * 1 * 2 * 2).
        /// 
        /// However, you can do even better: consider the tree of height 5 in the middle of the fourth row:
        /// 
        /// 30373
        /// 25512
        /// 65332
        /// 33549
        /// 35390
        /// Looking up, its view is blocked at 2 trees(by another tree with a height of 5).
        /// Looking left, its view is not blocked; it can see 2 trees.
        /// Looking down, its view is also not blocked; it can see 1 tree.
        /// Looking right, its view is blocked at 2 trees(by a massive tree of height 9).
        /// This tree's scenic score is 8 (2 * 2 * 1 * 2); this is the ideal spot for the tree house.
        /// 
        /// Consider each tree on your map.What is the highest scenic score possible for any tree?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int ext = input[0].Length * 2 + input.Count * 2 - 4;
            int interior = 0;
            List<Tree> trees = [];

            for (int i = 1; i < input.Count - 1; i++)
            {
                for (int j = 1; j < input[0].Length - 1; j++)
                {
                    int t = 0;
                    int b = 0;
                    int l = 0;
                    int r = 0;
                    bool top = true;
                    bool bottom = true;
                    bool left = true;
                    bool right = true;
                    string crt = input[i][j].ToString();

                    // top
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (int.Parse(input[k][j].ToString()) >= int.Parse(crt))
                        {
                            top = false;
                            t++;
                            break;
                        }
                        else t++;
                    }

                    // bottom
                    for (int k = i + 1; k < input.Count; k++)
                    {
                        if (int.Parse(input[k][j].ToString()) >= int.Parse(crt))
                        {
                            bottom = false;
                            b++;
                            break;
                        }
                        else b++;
                    }

                    // right
                    for (int k = j + 1; k < input[0].Length; k++)
                    {
                        if (int.Parse(input[i][k].ToString()) >= int.Parse(crt))
                        {
                            right = false;
                            t++;
                            break;
                        }
                        else r++;
                    }

                    // left
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (int.Parse(input[i][k].ToString()) >= int.Parse(crt))
                        {
                            left = false;
                            l++;
                            break;
                        }
                        else l++;
                    }

                    if (top || bottom || left || right) interior++;

                    trees.Add(new Tree($"{i} {j}", t * b * l * r));
                }
            }

            trees.Sort((a, b) => a.scenic.CompareTo(b.scenic));

            foreach (Tree item in trees)
            {
                Console.WriteLine($"{item.name}: {item.scenic}");
            }

            Console.WriteLine(ext);
            Console.WriteLine(interior);
            Console.WriteLine(interior + ext);

            return trees.Last().scenic;
        }

        private class Tree(string name, int scenic)
        {
            public string name = name;
            public int scenic = scenic;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _08_TreetopTreeHouse(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_08_TreetopTreeHouse));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}