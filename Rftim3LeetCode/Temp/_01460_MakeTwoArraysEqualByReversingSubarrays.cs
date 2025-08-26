namespace Rftim3LeetCode.Temp
{
    public class _01460_MakeTwoArraysEqualByReversingSubarrays
    {
        /// <summary>
        /// You are given two integer arrays of equal length target and arr. 
        /// In one step, you can select any non-empty subarray of arr and reverse it. 
        /// You are allowed to make any number of steps.
        /// Return true if you can make arr equal to target or false otherwise.
        /// </summary>
        public _01460_MakeTwoArraysEqualByReversingSubarrays()
        {
            Console.WriteLine(CanBeEqual(
                [1, 2, 3, 4],
                [2, 4, 1, 3]
            ));
            Console.WriteLine(CanBeEqual(
                [7],
                [7]
            ));
            Console.WriteLine(CanBeEqual(
                [3, 7, 9],
                [3, 7, 11]
            ));
        }

        private static bool CanBeEqual(int[] target, int[] arr)
        {
            Array.Sort(target);
            Array.Sort(arr);

            return target.SequenceEqual(arr);
        }
    }
}
