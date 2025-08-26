namespace Rftim3LeetCode.Temp
{
    public class _00823_BinaryTreesWithFactors
    {
        /// <summary>
        /// Given an array of unique integers, arr, where each integer arr[i] is strictly greater than 1.
        /// We make a binary tree using these integers, and each number may be used for any number of times.
        /// Each non-leaf node's value should be equal to the product of the values of its children.
        /// Return the number of binary trees we can make.
        /// The answer may be too large so return the answer modulo 109 + 7.
        /// </summary>
        public _00823_BinaryTreesWithFactors()
        {
            Console.WriteLine(NumFactoredBinaryTrees0([2, 4]));
            Console.WriteLine(NumFactoredBinaryTrees0([2, 4, 5, 10]));
        }

        public static int NumFactoredBinaryTrees0(int[] a0) => RftNumFactoredBinaryTrees0(a0);

        private static int RftNumFactoredBinaryTrees0(int[] arr)
        {
            Array.Sort(arr);
            Dictionary<int, long> kvp = [];
            long count = 1;
            int mod = (int)Math.Pow(10, 9) + 7;
            kvp.Add(arr[0], count);

            for (int i = 1; i < arr.Length; i++)
            {
                count = 1;
                foreach (int item in kvp.Keys)
                {
                    if (arr[i] % item == 0 && kvp.ContainsKey(arr[i] / item)) count += kvp[item] * kvp[arr[i] / item];
                }

                kvp.Add(arr[i], count);
            }

            long sum = 0;
            foreach (long item in kvp.Values)
            {
                sum = (sum + item) % mod;
            }

            return (int)sum;
        }
    }
}
