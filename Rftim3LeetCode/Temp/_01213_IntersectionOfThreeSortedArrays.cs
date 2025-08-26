using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01213_IntersectionOfThreeSortedArrays
    {
        /// <summary>
        /// Given three integer arrays arr1, arr2 and arr3 sorted in strictly increasing order, 
        /// return a sorted array of only the integers that appeared in all three arrays.
        /// </summary>
        public _01213_IntersectionOfThreeSortedArrays()
        {
            IList<int> a0 = IntersectionOfThreeSortedArrays0([1, 2, 3, 4, 5], [1, 2, 5, 7, 9], [1, 3, 4, 5, 8]);
            RftTerminal.RftReadResult(a0); // [1,5]

            IList<int> a1 = IntersectionOfThreeSortedArrays0([197, 418, 523, 876, 1356], [501, 880, 1593, 1710, 1870], [521, 682, 1337, 1395, 1764]);
            RftTerminal.RftReadResult(a1); // []
        }

        public static IList<int> IntersectionOfThreeSortedArrays0(int[] a0, int[] a1, int[] a2) => RftIntersectionOfThreeSortedArrays0(a0, a1, a2);

        public static IList<int> IntersectionOfThreeSortedArrays1(int[] a0, int[] a1, int[] a2) => RftIntersectionOfThreeSortedArrays1(a0, a1, a2);

        private static List<int> RftIntersectionOfThreeSortedArrays0(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> res = [];

            Dictionary<int, int> kvp = [];
            for (int i = 0; i < arr1.Length; i++)
            {
                if (kvp.TryGetValue(arr1[i], out int value1)) kvp[arr1[i]] = ++value1;
                else kvp[arr1[i]] = 1;
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                if (kvp.TryGetValue(arr2[i], out int value2)) kvp[arr2[i]] = ++value2;
                else kvp[arr2[i]] = 1;
            }
            for (int i = 0; i < arr3.Length; i++)
            {
                if (kvp.TryGetValue(arr3[i], out int value3)) kvp[arr3[i]] = ++value3;
                else kvp[arr3[i]] = 1;
            }

            res = kvp.Where(o => o.Value == 3).Select(o => o.Key).ToList();
            res.Sort();

            return res;
        }

        private static List<int> RftIntersectionOfThreeSortedArrays1(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> res = [];
            int i = 0, j = 0, k = 0;

            while (i < arr1.Length && j < arr2.Length && k < arr3.Length)
            {
                if (arr1[i] == arr2[j] && arr2[j] == arr3[k])
                {
                    res.Add(arr1[i]);
                    i++;
                    j++;
                    k++;
                }
                else
                {
                    int min = Math.Min(arr1[i], Math.Min(arr2[j], arr3[k]));
                    if (min == arr1[i]) i++;
                    if (min == arr2[j]) j++;
                    if (min == arr3[k]) k++;
                }
            }

            return res;
        }
    }
}
