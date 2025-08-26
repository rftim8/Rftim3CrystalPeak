using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00170_TwoSumIII_Datastructuredesign
    {
        /// <summary>
        /// Design a data structure that accepts a stream of integers and checks if it has a pair of integers that sum up to a particular value.
        /// 
        /// Implement the TwoSum class:
        /// 
        /// TwoSum() Initializes the TwoSum object, with an empty array initially.
        /// void add(int number) Adds number to the data structure.
        /// boolean find(int value) Returns true if there exists any pair of numbers whose sum is equal to value, otherwise, it returns false.
        /// </summary>
        public _00170_TwoSumIII_Datastructuredesign()
        {
            List<bool?> a0 = Datastructuredesign0(
                ["TwoSum", "add", "add", "add", "find", "find"],
                [[0], [1], [3], [5], [4], [7]]);
            RftTerminal.RftReadResult(a0);
        }

        public static List<bool?> Datastructuredesign0(List<string> a0, List<int[]> a1) => RftDatastructuredesign0(a0, a1);

        private static List<bool?> RftDatastructuredesign0(List<string> a0, List<int[]> a1)
        {
            List<bool?> res = [];
            TwoSum obj = new();
            int n = a0.Count;
            for (int i = 0; i < n; i++)
            {
                switch (a0[i])
                {
                    case "TwoSum":
                        break;
                    case "add":
                        obj.Add(a1[i][0]);
                        break;
                    case "find":
                        res.Add(obj.Find(a1[i][0]));
                        break;
                    default:
                        break;
                }
            }

            return res;
        }

        private class TwoSum
        {
            private readonly HashSet<int> x;
            private readonly HashSet<int> sums;

            public TwoSum()
            {
                x = [];
                sums = [];
            }

            public void Add(int number)
            {
                foreach (int item in x)
                {
                    sums.Add(item + number);
                }
                x.Add(number);
            }

            public bool Find(int value)
            {
                return sums.Contains(value);
            }
        }

        private class TwoSum1
        {
            private readonly Dictionary<int, int> d;
            private readonly List<int> nums;
            private int total = 0;

            public TwoSum1()
            {
                d = [];
                nums = [];
            }

            public void Add(int number)
            {
                if (d.TryGetValue(number, out int value)) d[number] = ++value;
                else
                {
                    d.Add(number, 1);
                    nums.Add(number);
                }

                total++;
            }

            public bool Find(int value)
            {
                if (total < 2) return false;
                foreach (int n in nums)
                {
                    int target = value - n;
                    if (!d.ContainsKey(target)) continue;

                    if (d[target] > 1) return true;

                    if (target == n) continue;
                    else return true;
                }

                return false;
            }
        }
    }
}
