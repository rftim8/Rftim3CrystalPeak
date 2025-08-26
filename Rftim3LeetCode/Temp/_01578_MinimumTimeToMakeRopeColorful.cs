using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01578_MinimumTimeToMakeRopeColorful
    {
        /// <summary>
        /// Alice has n balloons arranged on a rope. You are given a 0-indexed string colors where colors[i] is the color of the ith balloon.
        /// 
        /// Alice wants the rope to be colorful.She does not want two consecutive balloons to be of the same color, so she asks Bob for help.
        /// Bob can remove some balloons from the rope to make it colorful.
        /// You are given a 0-indexed integer array neededTime where neededTime[i] is the time (in seconds) that Bob needs to remove the ith 
        /// balloon from the rope.
        /// Return the minimum time Bob needs to make the rope colorful.
        /// </summary>
        public _01578_MinimumTimeToMakeRopeColorful()
        {
            Console.WriteLine(MinCost0("abaac", [1, 2, 3, 4, 5]));
            Console.WriteLine(MinCost0("abc", [1, 2, 3]));
            Console.WriteLine(MinCost0("aabaa", [1, 2, 3, 4, 1]));
            Console.WriteLine(MinCost0("cddcdcae", [4, 8, 8, 4, 4, 5, 4, 2]));
            Console.WriteLine(MinCost0("bbbaaa", [4, 9, 3, 8, 8, 9]));
        }

        public static int MinCost0(string a0, int[] a1) => RftMinCost0(a0, a1);

        public static int MinCost1(string a0, int[] a1) => RftMinCost1(a0, a1);

        private static int RftMinCost0(string colors, int[] neededTime)
        {
            colors += "_";
            int n = colors.Length;
            int r = 0;

            StringBuilder sb = new(colors);
            int left = 0, right = 0, c = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (sb[i] == sb[i + 1])
                {
                    right = i + 1;
                    c = c == 0 ? c += 2 : c += 1;
                }
                else
                {
                    if (c > 1)
                    {
                        r += neededTime[left..(right + 1)].Sum() - neededTime[left..(right + 1)].Max();
                        c = 0;
                    }
                    left = i + 1;
                }
            }

            return r;
        }

        private static int RftMinCost1(string colors, int[] neededTime)
        {
            int n = colors.Length;
            int totalTime = 0;

            for (int i = 1; i < n; i++)
            {
                if (colors[i] == colors[i - 1])
                {
                    totalTime += Math.Min(neededTime[i], neededTime[i - 1]);
                    neededTime[i] = Math.Max(neededTime[i], neededTime[i - 1]);
                }
            }

            return totalTime;
        }
    }
}
