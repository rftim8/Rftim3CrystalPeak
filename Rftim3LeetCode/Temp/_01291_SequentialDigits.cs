using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01291_SequentialDigits
    {
        /// <summary>
        /// An integer has sequential digits if and only if each digit in the number is one more than the previous digit.
        /// 
        /// Return a sorted list of all the integers in the range[low, high] inclusive that have sequential digits.
        /// </summary>
        public _01291_SequentialDigits()
        {
            IList<int> a0 = SequentialDigits0(100, 300);
            RftTerminal.RftReadResult(a0);

            IList<int> a1 = SequentialDigits0(1000, 13000);
            RftTerminal.RftReadResult(a1);

            IList<int> a2 = SequentialDigits0(10, 1000000000);
            RftTerminal.RftReadResult(a2);

            IList<int> a3 = SequentialDigits0(58, 155);
            RftTerminal.RftReadResult(a3);
        }

        public static IList<int> SequentialDigits0(int a0, int a1) => RftSequentialDigits0(a0, a1);

        public static IList<int> SequentialDigits1(int a0, int a1) => RftSequentialDigits1(a0, a1);

        private static List<int> RftSequentialDigits0(int low, int high)
        {
            List<int> res = [];

            int n = low.ToString().Length, m = high.ToString().Length;
            string s = "123456789";
            int s0 = s.Length;
            for (int i = n; i <= m; i++)
            {
                for (int j = 0; j <= s0 - i; j++)
                {
                    int t = int.Parse(s[j..(j + i)]);

                    if (t >= low && t <= high) res.Add(t);
                    else if (t > high) break;
                }
            }

            return res;
        }

        private static List<int> RftSequentialDigits1(int low, int high)
        {
            List<int> result = [];
            int maxNumLength = 10;
            int sequence = 123456789;
            int lowNumLength = (int)Math.Log10(low) + 1;

            for (int i = lowNumLength; i < maxNumLength; i++)
            {
                for (int j = i; j < maxNumLength; j++)
                {
                    int pow = maxNumLength - j + i - 1;
                    int currentSequence = sequence % (int)Math.Pow(10, pow);
                    int num = currentSequence / (int)Math.Pow(10, maxNumLength - j - 1);

                    if (num > high)
                    {
                        i = maxNumLength;
                        break;
                    }

                    if (num >= low && num <= high) result.Add(num);
                }
            }

            return result;
        }
    }
}
