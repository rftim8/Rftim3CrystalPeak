using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00412_FizzBuzz
    {
        /// <summary>
        /// Given an integer n, return a string array answer (1-indexed) where:
        /// answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
        /// answer[i] == "Fizz" if i is divisible by 3.
        /// answer[i] == "Buzz" if i is divisible by 5.
        /// answer[i] == i(as a string) if none of the above conditions are true.
        /// </summary>
        public _00412_FizzBuzz()
        {
            IList<string> x = FizzBuzz0(3);
            RftTerminal.RftReadResult(x);

            IList<string> x0 = FizzBuzz0(5);
            RftTerminal.RftReadResult(x0);

            IList<string> x1 = FizzBuzz0(15);
            RftTerminal.RftReadResult(x1);
        }

        public static IList<string> FizzBuzz0(int a0) => RftFizzBuzz0(a0);

        public static IList<string> FizzBuzz1(int a0) => RftFizzBuzz1(a0);

        private static List<string> RftFizzBuzz0(int n)
        {
            List<string> x = [];

            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0) x.Add("FizzBuzz");
                else if (i % 3 == 0) x.Add("Fizz");
                else if (i % 5 == 0) x.Add("Buzz");
                else x.Add(i.ToString());
            }

            return x;
        }

        public static List<string> RftFizzBuzz1(int n)
        {
            List<string> result = new(n);

            for (int i = 1; i <= n; i++)
            {
                bool div3 = i % 3 == 0;
                bool div5 = i % 5 == 0;

                if (div3 && div5)
                {
                    result.Add("FizzBuzz");
                    continue;
                }

                if (div3)
                {
                    result.Add("Fizz");
                    continue;
                }

                if (div5)
                {
                    result.Add("Buzz");
                    continue;
                }

                result.Add(i.ToString());
            }

            return result;
        }
    }
}
