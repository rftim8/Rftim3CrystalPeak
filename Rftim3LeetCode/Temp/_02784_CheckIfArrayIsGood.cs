namespace Rftim3LeetCode.Temp
{
    public class _02784_CheckIfArrayIsGood
    {
        /// <summary>
        /// You are given an integer array nums. We consider an array good if it is a permutation of an array base[n].
        /// base[n] = [1, 2, ..., n - 1, n, n] (in other words, it is an array of length n + 1 which contains 1 to n - 1 exactly once, plus two occurrences of n). 
        /// For example, base[1] = [1, 1] and base[3] = [1, 2, 3, 3].
        /// Return true if the given array is good, otherwise return false.
        /// Note: A permutation of integers represents an arrangement of these numbers.
        /// </summary>
        public _02784_CheckIfArrayIsGood()
        {
            Console.WriteLine(IsGood([2, 1, 3]));
            Console.WriteLine(IsGood([1, 3, 3, 2]));
            Console.WriteLine(IsGood([1, 1]));
            Console.WriteLine(IsGood([3, 4, 4, 1, 2, 1]));
        }

        private static bool IsGood(int[] nums)
        {
            int m = nums.Max();
            List<int> r = Enumerable.Range(1, m).ToList();
            r.Add(m);

            return nums.ToList().OrderBy(o => o).SequenceEqual(r);
        }
    }
}
