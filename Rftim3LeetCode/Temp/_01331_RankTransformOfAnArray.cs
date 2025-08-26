using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01331_RankTransformOfAnArray
    {
        /// <summary>
        /// Given an array of integers arr, replace each element with its rank.
        /// The rank represents how large the element is. The rank has the following rules:
        /// Rank is an integer starting from 1.
        /// The larger the element, the larger the rank.If two elements are equal, their rank must be the same.
        /// Rank should be as small as possible.
        /// </summary>
        public _01331_RankTransformOfAnArray()
        {
            int[] x = ArrayRankTransform([40, 10, 20, 30]);
            int[] x0 = ArrayRankTransform([100, 100, 100]);
            int[] x1 = ArrayRankTransform([37, 12, 28, 9, 100, 56, 80, 5, 12]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] ArrayRankTransform(int[] arr)
        {
            int n = arr.Length;
            List<int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (!r.Contains(arr[i])) r.Add(arr[i]);
            }

            r.Sort();

            for (int i = 0; i < n; i++)
            {
                arr[i] = r.IndexOf(arr[i]) + 1;
            }

            return arr;
        }

        private static int[] ArrayRankTransform0(int[] arr)
        {
            int[] newArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = arr[i];
            }

            Array.Sort(arr);
            Dictionary<int, int> dict = [];
            int counter = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.TryAdd(arr[i], counter))
                {
                    counter++;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = dict[newArray[i]];
            }

            return newArray;
        }
    }
}
