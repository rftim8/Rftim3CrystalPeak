using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01243_ArrayTransformation
    {
        /// <summary>
        /// Given an initial array arr, every day you produce a new array using the array of the previous day.
        /// 
        /// On the i-th day, you do the following operations on the array of day i-1 to produce the array of day i:
        /// 
        /// If an element is smaller than both its left neighbor and its right neighbor, then this element is incremented.
        /// If an element is bigger than both its left neighbor and its right neighbor, then this element is decremented.
        /// The first and last elements never change.
        /// After some days, the array does not change.Return that final array.
        /// </summary>
        public _01243_ArrayTransformation()
        {
            IList<int> a0 = ArrayTransformation0([6, 2, 3, 4]);
            RftTerminal.RftReadResult(a0); // [6,3,3,4]

            IList<int> a1 = ArrayTransformation0([1, 6, 3, 4, 3, 5]);
            RftTerminal.RftReadResult(a1); // [1,4,4,4,4,5]
        }

        public static IList<int> ArrayTransformation0(int[] a0) => RftArrayTransformation0(a0);

        public static IList<int> ArrayTransformation1(int[] a0) => RftArrayTransformation1(a0);

        private static List<int> RftArrayTransformation0(int[] arr)
        {
            int count = 1;

            while (count > 0)
            {
                int[] temp = (int[])arr.Clone();
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    if (arr[i - 1] > arr[i] && arr[i] < arr[i + 1])
                    {
                        temp[i] = arr[i] + 1;
                        count++;
                    }
                    else if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
                    {
                        temp[i] = arr[i] - 1;
                        count++;
                    }

                }

                arr = temp;

                if (count > 1) count = 1;
                else count = 0;

            }

            return [.. arr];
        }

        private static List<int> RftArrayTransformation1(int[] arr)
        {
            for (bool fullyTransformed = false; !fullyTransformed;)
            {
                fullyTransformed = true;
                int right;
                for (int i = 2, left = arr[0], middle = arr[1]; i < arr.Length; (left, middle) = (middle, right), ++i)
                {
                    right = arr[i];
                    if (middle < left && middle < right)
                    {
                        ++arr[i - 1];
                        fullyTransformed = false;
                    }
                    else if (middle > left && middle > right)
                    {
                        --arr[i - 1];
                        fullyTransformed = false;
                    }
                }
            }

            return [.. arr];
        }
    }
}
