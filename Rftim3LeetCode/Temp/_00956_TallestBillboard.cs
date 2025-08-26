namespace Rftim3LeetCode.Temp
{
    public class _00956_TallestBillboard
    {
        /// <summary>
        /// You are installing a billboard and want it to have the largest height. 
        /// The billboard will have two steel supports, one on each side. 
        /// Each steel support must be an equal height.
        /// You are given a collection of rods that can be welded together.
        /// For example, if you have rods of lengths 1, 2, and 3, you can weld them together to make a support of length 6.
        /// Return the largest possible height of your billboard installation.
        /// If you cannot support the billboard, return 0.
        /// </summary>
        public _00956_TallestBillboard()
        {
            Console.WriteLine(TallestBillboard([1, 2, 3, 6]));
            Console.WriteLine(TallestBillboard([1, 2, 3, 4, 5, 6]));
            Console.WriteLine(TallestBillboard([1, 2]));
        }

        private static int TallestBillboard(int[] rods)
        {
            int n = rods.Length;
            Dictionary<int, int> firstHalf = Helper(rods, 0, n / 2);
            Dictionary<int, int> secondHalf = Helper(rods, n / 2, n);

            int answer = 0;
            foreach (int diff in firstHalf.Keys)
            {
                if (secondHalf.ContainsKey(-diff)) answer = Math.Max(answer, firstHalf[diff] + secondHalf[-diff]);
            }

            return answer;
        }

        private static Dictionary<int, int> Helper(int[] rods, int leftIndex, int rightIndex)
        {
            List<(int, int)> states =
            [
                new(0, 0)
            ];

            for (int i = leftIndex; i < rightIndex; ++i)
            {
                int r = rods[i];
                List<(int, int)> newStates = [];
                foreach ((int, int) p in states)
                {
                    newStates.Add((p.Item1 + r, p.Item2));
                    newStates.Add((p.Item1, p.Item2 + r));
                }
                states.AddRange(newStates);
            }

            Dictionary<int, int> dp = [];
            foreach ((int, int) p in states)
            {
                int left = p.Item1, right = p.Item2;

                if (!dp.ContainsKey(left - right)) dp.Add(left - right, Math.Max(0, left));
                else dp[left - right] = Math.Max(dp[left - right], left);
            }

            return dp;
        }

        private static int TallestBillboard0(int[] rods)
        {
            Dictionary<int, int> dp = new()
            {
                { 0, 0 }
            };

            foreach (int r in rods)
            {
                Dictionary<int, int> newDp = new(dp);

                foreach (KeyValuePair<int, int> entry in dp)
                {
                    int diff = entry.Key;
                    int taller = entry.Value;
                    int shorter = taller - diff;

                    int newTaller = !newDp.ContainsKey(diff + r) ? 0 : newDp[diff + r];

                    if (!newDp.ContainsKey(diff + r)) newDp.Add(diff + r, Math.Max(newTaller, taller + r));
                    else newDp[diff + r] = Math.Max(newTaller, taller + r);

                    int newDiff = Math.Abs(shorter + r - taller);
                    int newTaller2 = Math.Max(shorter + r, taller);

                    if (!newDp.ContainsKey(newDiff)) newDp.Add(newDiff, Math.Max(newTaller2, 0));
                    else newDp[newDiff] = Math.Max(newTaller2, newDp[newDiff]);
                }

                dp = newDp;
            }

            return dp.TryGetValue(0, out int value) ? value : 0;
        }
    }
}
