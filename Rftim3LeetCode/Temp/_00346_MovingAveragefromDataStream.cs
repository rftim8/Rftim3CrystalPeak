using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00346_MovingAveragefromDataStream
    {
        /// <summary>
        /// Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.
        /// 
        /// Implement the MovingAverage class:
        /// 
        /// MovingAverage(int size) Initializes the object with the size of the window size.
        /// double next(int val) Returns the moving average of the last size values of the stream.
        /// </summary>
        public _00346_MovingAveragefromDataStream()
        {
            List<double?> a0 = MovingAveragefromDataStream0(
                ["MovingAverage", "next", "next", "next", "next"],
                [[3], [1], [10], [3], [5]]);
            RftTerminal.RftReadResult(a0);
        }

        public static List<double?> MovingAveragefromDataStream0(List<string> a0, List<int[]> a1) => RftMovingAveragefromDataStream0(a0, a1);

        private static List<double?> RftMovingAveragefromDataStream0(List<string> a0, List<int[]> a1)
        {
            List<double?> res = [];

            MovingAverage obj = new(a1[0][0]);
            for (int i = 1; i < a0.Count; i++)
            {
                res.Add(obj.Next(a1[i][0]));
            }

            return res;
        }

        private class MovingAverage(int size)
        {
            private readonly List<double> x = [];
            private readonly int c = size;

            public double Next(int val)
            {
                x.Add(val);
                int n = x.Count, d = c;
                double res = 0;
                for (int i = n - 1; i > -1; i--, d--)
                {
                    if (d > 0) res += x[i];
                    else break;
                }

                return d == 0 ? res / c : res / n;
            }
        }

        private class MovingAverage1(int size)
        {
            private readonly int maxSize = size;
            int sum = 0;
            private readonly Queue<int> queue = new();

            public double Next(int val)
            {
                queue.Enqueue(val);
                sum += val;

                if (queue.Count > maxSize) sum -= queue.Dequeue();

                return (double)sum / queue.Count;
            }
        }
    }
}
