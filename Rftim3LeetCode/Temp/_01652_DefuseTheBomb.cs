using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01652_DefuseTheBomb
    {
        /// <summary>
        /// You have a bomb to defuse, and your time is running out! Your informer will provide you with a circular array code of length of n and a key k.
        /// To decrypt the code, you must replace every number.All the numbers are replaced simultaneously.
        /// If k > 0, replace the ith number with the sum of the next k numbers.
        /// If k < 0, replace the ith number with the sum of the previous k numbers.
        /// If k == 0, replace the ith number with 0.
        /// As code is circular, the next element of code[n - 1] is code[0], and the previous element of code[0] is code[n - 1].
        /// Given the circular array code and an integer key k, return the decrypted code to defuse the bomb!
        /// </summary>
        public _01652_DefuseTheBomb()
        {
            int[] x = Decrypt([5, 7, 1, 4], 3);
            int[] x0 = Decrypt([1, 2, 3, 4], 0);
            int[] x1 = Decrypt([2, 4, 9, 3], -2);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] Decrypt(int[] code, int k)
        {
            int n = code.Length;
            int[] r = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (k > -1)
                {
                    for (int j = 0; j < Math.Abs(k); j++)
                    {
                        r[i] += code[Math.Abs((i + j + 1) % n)];
                    }
                }
                else
                {
                    for (int j = 0; j < Math.Abs(k); j++)
                    {
                        if (i - j - 1 > -1) r[i] += code[i - j - 1];
                        else r[i] += code[^(Math.Abs(i - j - 1) % n)];
                    }
                }
            }

            return r;
        }
    }
}
