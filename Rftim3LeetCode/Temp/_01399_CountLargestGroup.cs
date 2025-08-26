namespace Rftim3LeetCode.Temp
{
    public class _01399_CountLargestGroup
    {
        /// <summary>
        /// You are given an integer n.
        /// Each number from 1 to n is grouped according to the sum of its digits.
        /// Return the number of groups that have the largest size.
        /// </summary>
        public _01399_CountLargestGroup()
        {
            Console.WriteLine(CountLargestGroup(13));
            Console.WriteLine(CountLargestGroup(2));
        }

        private static int CountLargestGroup(int n)
        {
            Dictionary<int, int> groups = [];
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int num = i;
                while (num != 0)
                {
                    sum += num % 10;
                    num /= 10;
                }

                if (!groups.ContainsKey(sum)) groups[sum] = 0;

                groups[sum]++;
            }

            int maxSize = groups.Max(p => p.Value);
            int res = 0;
            foreach (KeyValuePair<int, int> item in groups)
            {
                if (item.Value == maxSize) res++;
            }

            return res;
        }
    }
}
