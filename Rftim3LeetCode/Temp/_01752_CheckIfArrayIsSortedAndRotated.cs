namespace Rftim3LeetCode.Temp
{
    public class _01752_CheckIfArrayIsSortedAndRotated
    {
        /// <summary>
        /// Given an array nums, return true if the array was originally sorted in non-decreasing order, 
        /// then rotated some number of positions (including zero). 
        /// Otherwise, return false.
        /// There may be duplicates in the original array.
        /// Note: An array A rotated by x positions results in an array B of the same length such that 
        /// A[i] == B[(i + x) % A.length], where % is the modulo operation.
        /// </summary>
        public _01752_CheckIfArrayIsSortedAndRotated()
        {
            Console.WriteLine(CheckIfArrayIsSortedAndRotated0([3, 4, 5, 1, 2]));
            Console.WriteLine(CheckIfArrayIsSortedAndRotated0([2, 1, 3, 4]));
            Console.WriteLine(CheckIfArrayIsSortedAndRotated0([1, 2, 3]));
        }

        public static bool CheckIfArrayIsSortedAndRotated0(int[] a0) => RftCheckIfArrayIsSortedAndRotated0(a0);

        public static bool CheckIfArrayIsSortedAndRotated1(int[] a0) => RftCheckIfArrayIsSortedAndRotated1(a0);

        private static bool RftCheckIfArrayIsSortedAndRotated0(int[] nums)
        {
            int n = nums.Length;
            List<int> l = [.. nums];
            List<int> r = [.. nums];
            r.Sort();

            for (int i = 0; i < n; i++)
            {
                int t = r[0];
                r.RemoveAt(0);
                r.Add(t);
                if (l.SequenceEqual(r)) return true;
            }

            return false;
        }

        private static bool RftCheckIfArrayIsSortedAndRotated1(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; ++i)
            {
                bool isValid = true;
                for (int j = 0; j < n - 1; ++j)
                {
                    int pos = (i + j) % n;
                    int nPos = (pos + 1) % n;

                    if (nums[pos] > nums[nPos]) isValid = false;
                }
                if (isValid) return true;
            }

            return false;
        }
    }
}