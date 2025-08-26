using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00739_DailyTemperatures
    {
        /// <summary>
        /// Given an array of integers temperatures represents the daily temperatures, 
        /// return an array answer such that answer[i] is the number of days you have to 
        /// wait after the ith day to get a warmer temperature. 
        /// If there is no future day for which this is possible, 
        /// keep answer[i] == 0 instead.
        /// </summary>
        public _00739_DailyTemperatures()
        {
            int[] a0 = RftDailyTemperatures0([73, 74, 75, 71, 69, 72, 76, 73]);
            RftTerminal.RftReadResult(a0);

            int[] a1 = RftDailyTemperatures0([30, 40, 50, 60]);
            RftTerminal.RftReadResult(a1);

            int[] a2 = RftDailyTemperatures0([30, 60, 90]);
            RftTerminal.RftReadResult(a2);
        }

        public static int[] DailyTemperatures0(int[] a0) => RftDailyTemperatures0(a0);

        public static int[] DailyTemperatures1(int[] a0) => RftDailyTemperatures1(a0);

        private static int[] RftDailyTemperatures0(int[] temperatures)
        {
            int n = temperatures.Length;
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                int t = temperatures[i];
                temperatures[i] = 0;
                for (int j = i + 1; j < n; j++)
                {
                    if (t < temperatures[j])
                    {
                        temperatures[i] = ++c;
                        break;
                    }
                    else c++;
                }
            }

            return temperatures;
        }

        private static int[] RftDailyTemperatures1(int[] temperatures)
        {
            Stack<int> s = new();
            int[] result = new int[temperatures.Length];

            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                while (s.Count != 0 && temperatures[i] >= temperatures[s.Peek()])
                {
                    s.Pop();
                }

                if (s.Count == 0) result[i] = 0;
                else result[i] = s.Peek() - i;

                s.Push(i);
            }

            return result;
        }
    }
}