using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00989_AddToArrayFormOfInteger
    {
        /// <summary>
        /// The array-form of an integer num is an array representing its digits in left to right order.
        /// For example, for num = 1321, the array form is [1,3,2,1].
        /// Given num, the array-form of an integer, and an integer k, return the array-form of the integer num + k.
        /// </summary>
        public _00989_AddToArrayFormOfInteger()
        {
            IList<int> x = AddToArrayFormOfInteger0([1, 2, 0, 0], 34);
            RftTerminal.RftReadResult(x);

            IList<int> x0 = AddToArrayFormOfInteger0([2, 7, 4], 181);
            RftTerminal.RftReadResult(x0);

            IList<int> x1 = AddToArrayFormOfInteger0([2, 1, 5], 806);
            RftTerminal.RftReadResult(x1);
        }

        public static IList<int> AddToArrayFormOfInteger0(int[] a0, int a1) => RftAddToArrayFormOfInteger0(a0, a1);

        private static List<int> RftAddToArrayFormOfInteger0(int[] num, int k)
        {
            int n = num.Length;
            List<int> r = [];

            int carry = 0;
            for (int i = n - 1; i > -1; i--)
            {
                int x = 0;
                if (k > 0)
                {
                    x = k % 10;
                    k /= 10;
                }

                if (num[i] + x + carry >= 10)
                {
                    r.Add((num[i] + x + carry) % 10);
                    carry = 1;
                }
                else
                {
                    r.Add(num[i] + x + carry);
                    carry = 0;
                }
            }

            while (k > 0)
            {
                int y = k % 10;
                k /= 10;

                if (y + carry >= 10)
                {
                    r.Add((y + carry) % 10);
                    carry = 1;
                }
                else
                {
                    r.Add(y + carry);
                    carry = 0;
                }
            }

            if (carry > 0) r.Add(carry);

            r.Reverse();

            return r;
        }
    }
}