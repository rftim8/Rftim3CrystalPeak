namespace Rftim3LeetCode.Temp
{
    public class _02644_FindTheMaximumDivisibilityScore
    {
        /// <summary>
        /// You are given two 0-indexed integer arrays nums and divisors.
        /// The divisibility score of divisors[i] is the number of indices j such that nums[j] is divisible by divisors[i].
        /// Return the integer divisors[i] with the maximum divisibility score.
        /// If there is more than one integer with the maximum score, return the minimum of them.
        /// </summary>
        public _02644_FindTheMaximumDivisibilityScore()
        {
            Console.WriteLine(MaxDivScore([4, 7, 9, 3, 9], [5, 2, 3]));
            Console.WriteLine(MaxDivScore([20, 14, 21, 10], [5, 7, 5]));
            Console.WriteLine(MaxDivScore([12], [10, 16]));
        }

        private static int MaxDivScore(int[] nums, int[] divisors)
        {
            int n = divisors.Length;
            int m = nums.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (nums[j] % divisors[i] == 0) c++;
                }
                if (r.TryGetValue(divisors[i], out int value)) r[divisors[i]] = Math.Max(c, value);
                else r[divisors[i]] = c;
            }

            List<KeyValuePair<int, int>> x = r.Where(o => o.Value == r.MaxBy(o => o.Value).Value).ToList();

            return x.MinBy(o => o.Key).Key;
        }

        private static int MaxDivScore0(int[] nums, int[] divisors)
        {
            Array.Sort(nums, (a, b) => b - a);
            (int res, int max) = (0, -1);

            foreach (int div in divisors)
            {
                int score = 0;

                foreach (int num in nums)
                {
                    if (num % div == 0) score++;
                    else if (div != num && div > num / 2) break;
                }

                if (score > max || score == max && div < res) (res, max) = (div, score);
            }

            return res;
        }
    }
}
