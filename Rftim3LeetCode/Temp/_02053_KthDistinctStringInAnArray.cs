namespace Rftim3LeetCode.Temp
{
    public class _02053_KthDistinctStringInAnArray
    {
        /// <summary>
        /// A distinct string is a string that is present only once in an array.
        /// Given an array of strings arr, and an integer k, return the kth distinct string present in arr.
        /// If there are fewer than k distinct strings, return an empty string "".
        /// Note that the strings are considered in the order in which they appear in the array.
        /// </summary>
        public _02053_KthDistinctStringInAnArray()
        {
            Console.WriteLine(KthDistinct(["d", "b", "c", "b", "c", "a"], 2));
            Console.WriteLine(KthDistinct(["aaa", "aa", "a"], 1));
            Console.WriteLine(KthDistinct(["a", "b", "a"], 3));
        }

        private static string KthDistinct(string[] arr, int k)
        {
            Dictionary<string, int> r = [];

            foreach (string item in arr)
            {
                if (r.TryGetValue(item, out int value)) r[item] = ++value;
                else r[item] = 1;
            }

            List<string> x = r.Where(o => o.Value == 1).Select(o => o.Key).ToList();

            return k > x.Count ? "" : x[k - 1];
        }
    }
}
