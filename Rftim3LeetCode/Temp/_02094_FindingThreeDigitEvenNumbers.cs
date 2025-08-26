using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02094_FindingThreeDigitEvenNumbers
    {
        /// <summary>
        /// You are given an integer array digits, where each element is a digit. The array may contain duplicates.
        /// You need to find all the unique integers that follow the given requirements:
        /// The integer consists of the concatenation of three elements from digits in any arbitrary order.
        /// The integer does not have leading zeros.
        ///         The integer is even.
        /// For example, if the given digits were[1, 2, 3], integers 132 and 312 follow the requirements.
        /// Return a sorted array of the unique integers.
        /// </summary>
        public _02094_FindingThreeDigitEvenNumbers()
        {
            int[] x = FindEvenNumbers([2, 1, 3, 0]);
            RftTerminal.RftReadResult(x);
            int[] x0 = FindEvenNumbers([2, 2, 8, 8, 2]);
            RftTerminal.RftReadResult(x0);
            int[] x1 = FindEvenNumbers([3, 7, 5]);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] FindEvenNumbers(int[] digits)
        {
            int n = digits.Length;
            HashSet<int> r = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (i != j && j != k && i != k)
                        {
                            if (digits[k] % 2 == 0)
                            {
                                int c = digits[k];
                                c += digits[j] * 10;
                                c += digits[i] * 100;
                                if (c > 99) r.Add(c);
                            }
                        }
                    }
                }
            }

            int[] q = r.ToArray();
            Array.Sort(q);

            return q;
        }

        private static int[] FindEvenNumbers0(int[] digits)
        {
            List<int> result = [];
            int[] counts = new int[10];
            foreach (int d in digits)
            {
                counts[d]++;
            }

            for (int i = 1; i < 10; i++)
            {
                counts[i]--;
                for (int j = 0; j < 10; j++)
                {
                    counts[j]--;
                    for (int k = 0; k < 10; k += 2)
                    {
                        counts[k]--;

                        if (counts[i] >= 0 && counts[j] >= 0 && counts[k] >= 0) result.Add(i * 100 + j * 10 + k);

                        counts[k]++;
                    }
                    counts[j]++;
                }
                counts[i]++;
            }

            return [.. result];
        }
    }
}
