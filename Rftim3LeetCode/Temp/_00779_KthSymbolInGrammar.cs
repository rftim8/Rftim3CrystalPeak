namespace Rftim3LeetCode.Temp
{
    public class _00779_KthSymbolInGrammar
    {
        /// <summary>
        /// 1: 0
        /// 2: 01
        /// 3: 0110
        /// 4: 01101001
        /// We build a table of n rows (1-indexed). We start by writing 0 in the 1st row. 
        /// Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
        /// For example, for n = 3, the 1st row is 0, the 2nd row is 01, and the 3rd row is 0110.
        /// Given two integer n and k, return the kth(1-indexed) symbol in the nth row of a table of n rows.
        /// </summary>
        public _00779_KthSymbolInGrammar()
        {
            Console.WriteLine(KthSymbolInGrammar0(1, 1));
            Console.WriteLine(KthSymbolInGrammar0(2, 1));
            Console.WriteLine(KthSymbolInGrammar0(2, 2));
            Console.WriteLine(KthSymbolInGrammar0(30, 434991989));
        }

        public static int KthSymbolInGrammar0(int a0, int a1) => RftKthSymbolInGrammar0(a0, a1);

        private static int RftKthSymbolInGrammar0(int n, int k)
        {
            return Helper(n - 1, k - 1);
        }

        private static int Helper(int n, int k)
        {
            if (n == 0) return 0;

            int prevK = k / 2;
            int mod = k % 2;

            int parent = Helper(n - 1, prevK);

            if (parent == 0) return mod;

            return (mod + 1) % 2;
        }
    }
}