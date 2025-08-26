namespace Rftim3LeetCode.Temp
{
    public class _00697_DegreeOfAnArray
    {
        /// <summary>
        /// Given a non-empty array of non-negative integers nums, the degree of this array is defined as the maximum frequency of any one of its elements.
        /// Your task is to find the smallest possible length of a(contiguous) subarray of nums, that has the same degree as nums.
        /// </summary>
        public _00697_DegreeOfAnArray()
        {
            Console.WriteLine(FindShortestSubArray([1, 2, 2, 3, 1]));
            Console.WriteLine(FindShortestSubArray([1, 2, 2, 3, 1, 4, 2]));
        }

        private static int FindShortestSubArray(int[] nums)
        {
            int n = nums.Length;

            Dictionary<int, int> y = [];

            for (int i = 0; i < n; i++)
            {
                if (y.TryGetValue(nums[i], out int value)) y[nums[i]] = ++value;
                else y[nums[i]] = 1;
            }

            int max = y.Max(o => o.Value);
            List<int> z = y.Where(o => o.Value == max).Select(o => o.Key).ToList();

            List<int> x = [];
            foreach (int item in z)
            {
                int l = 0, r = n - 1;

                for (int i = 0; i < n; i++)
                {
                    if (nums[i] == item)
                    {
                        l = i;
                        break;
                    }
                }

                for (int i = n - 1; i > -1; i--)
                {
                    if (nums[i] == item)
                    {
                        r = i;
                        break;
                    }
                }

                x.Add(nums[l..(r + 1)].Length);
            }

            return x.Min();
        }

        private static int FindShortestSubArray0(int[] nums)
        {
            Dictionary<int, List<int>> dictIndex = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (dictIndex.TryGetValue(nums[i], out List<int>? value)) value.Add(i);
                else dictIndex.Add(nums[i], [i]);
            }

            int maxDegree = dictIndex.Max(x => x.Value.Count);
            int minLength = int.MaxValue;
            foreach (KeyValuePair<int, List<int>> item in dictIndex)
            {
                if (item.Value.Count == maxDegree)
                {
                    int size = item.Value[^1] - item.Value[0] + 1;
                    minLength = Math.Min(minLength, size);
                }
            }

            return minLength;
        }
    }
}
