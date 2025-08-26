using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00599_MinimumIndexSumOfTwoLists
    {
        /// <summary>
        /// Given two arrays of strings list1 and list2, find the common strings with the least index sum.
        /// A common string is a string that appeared in both list1 and list2.
        /// A common string with the least index sum is a common string such that if it appeared at list1[i] and list2[j] 
        /// then i + j should be the minimum value among all the other common strings.
        /// Return all the common strings with the least index sum. Return the answer in any order.
        /// </summary>
        public _00599_MinimumIndexSumOfTwoLists()
        {
            string[] x = FindRestaurant(
                ["Shogun", "Tapioca Express", "Burger King", "KFC"],
                ["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"]
            );

            string[] x0 = FindRestaurant(
                ["Shogun", "Tapioca Express", "Burger King", "KFC"],
                ["KFC", "Shogun", "Burger King"]
            );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static string[] FindRestaurant(string[] list1, string[] list2)
        {
            Dictionary<string, int> r = [];

            int n = list1.Length;
            int m = list2.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (list1[i] == list2[j]) r[list1[i]] = i + j;
                }
            }

            int max = r.Min(o => o.Value);

            return r.Where(o => o.Value == max).Select(o => o.Key).ToArray();
        }
    }
}
