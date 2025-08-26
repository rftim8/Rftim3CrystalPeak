using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00728_SelfDividingNumbers
    {
        /// <summary>
        /// A self-dividing number is a number that is divisible by every digit it contains.
        /// For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0.
        /// A self-dividing number is not allowed to contain the digit zero.
        /// Given two integers left and right, return a list of all the self-dividing numbers in the range[left, right].
        /// </summary>
        public _00728_SelfDividingNumbers()
        {
            IList<int> x = SelfDividingNumbers(1, 22);
            IList<int> x0 = SelfDividingNumbers(47, 85);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static List<int> SelfDividingNumbers(int left, int right)
        {
            List<int> r = [];

            for (int i = left; i <= right; i++)
            {
                if (!i.ToString().Contains('0'))
                {
                    bool d = true;
                    int t = i;

                    while (t > 0)
                    {
                        int q = t < 10 ? t : t % 10;
                        t /= 10;

                        if (i % q != 0) d = false;
                    }

                    if (d) r.Add(i);
                }
            }

            return r;
        }
    }
}
