using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00060_PermutationSequence
    {
        /// <summary>
        /// The set [1, 2, 3, ..., n] contains a total of n! unique permutations.
        /// By listing and labeling all of the permutations in order, we get the following sequence for n = 3:
        /// "123"
        /// "132"
        /// "213"
        /// "231"
        /// "312"
        /// "321"
        /// Given n and k, return the kth permutation sequence.
        /// </summary>
        public _00060_PermutationSequence()
        {
            Console.WriteLine(PermutationSequence0(3, 3));
            Console.WriteLine(PermutationSequence0(4, 9));
            Console.WriteLine(PermutationSequence0(3, 1));
        }

        public static string PermutationSequence0(int a0, int a1) => RftPermutationSequence0(a0, a1);

        private static string RftPermutationSequence0(int n, int k)
        {
            int[] r = new int[n + 1];
            List<int> t = [];

            r[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                r[i] = r[i - 1] * i;
                t.Add(i);
            }

            k--;
            StringBuilder sb = new();
            for (int i = 1; i <= n; i++)
            {
                int j = k / r[n - i];
                sb.Append(t[j]);
                t.RemoveAt(j);
                k -= j * r[n - i];
            }

            return sb.ToString();
        }
    }
}
