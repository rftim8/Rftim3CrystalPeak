namespace Rftim3LeetCode.Temp
{
    public class _02391_MinimumAmountOfTimeToCollectGarbage
    {
        /// <summary>
        /// You are given a 0-indexed array of strings garbage where garbage[i] represents the assortment of garbage at the ith house.
        /// garbage[i] consists only of the characters 'M', 'P' and 'G' representing one unit of metal, paper and glass garbage respectively. 
        /// Picking up one unit of any type of garbage takes 1 minute.
        /// 
        /// You are also given a 0-indexed integer array travel where travel[i] is the number of minutes needed to go from house i to house i + 1.
        /// 
        /// There are three garbage trucks in the city, each responsible for picking up one type of garbage.
        /// Each garbage truck starts at house 0 and must visit each house in order; however, they do not need to visit every house.
        /// Only one garbage truck may be used at any given moment. While one truck is driving or picking up garbage, the other two trucks cannot do anything.
        /// 
        /// Return the minimum number of minutes needed to pick up all the garbage.
        /// </summary>
        public _02391_MinimumAmountOfTimeToCollectGarbage()
        {
            Console.WriteLine(GarbageCollection0(["G", "P", "GP", "GG"], [2, 4, 3]));
            Console.WriteLine(GarbageCollection0(["MMM", "PGM", "GP"], [3, 10]));
        }

        public static int GarbageCollection0(string[] a0, int[] a1) => RftGarbageCollection0(a0, a1);

        public static int GarbageCollection1(string[] a0, int[] a1) => RftGarbageCollection1(a0, a1);

        private static int RftGarbageCollection0(string[] garbage, int[] travel)
        {
            int len = garbage.Length;
            int res = 0;
            HashSet<char> s = [];
            for (int i = len - 1; i >= 0; i--)
            {
                foreach (char ch in garbage[i].ToCharArray())
                {
                    s.Add(ch);
                }

                res += garbage[i].Length;
                res += i > 0 ? s.Count * travel[i - 1] : 0;
            }

            return res;
        }

        private static int RftGarbageCollection1(string[] garbage, int[] travel)
        {
            int sum = travel.Sum();
            int min = 0;
            HashSet<char> set = [];
            for (int i = garbage.Length - 1; i >= 1; i--)
            {
                min += garbage[i].Length;
                int count = set.Count;
                if (count != 3)
                {
                    foreach (char c in garbage[i])
                    {
                        set.Add(c);
                    }

                    min += (set.Count - count) * sum;
                }
                sum -= travel[i - 1];
            }

            return min + garbage[0].Length;
        }
    }
}
