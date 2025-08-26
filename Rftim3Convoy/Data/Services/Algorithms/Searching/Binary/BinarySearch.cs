using BenchmarkDotNet.Attributes;
using Rftim3Convoy.Data.Services.Lifetime;

namespace Rftim3Convoy.Data.Services.Algorithms.Searching.Binary
{
    public class BinarySearch : IBinarySearch
    {
        Guid IServiceReportLifetime.Id { get; } = Guid.NewGuid();

        private readonly int[] nums = [-1, 0, 3, 5, 9, 12];
        private readonly int target = 9;

        public BinarySearch()
        {

        }

        public Task BinarySearchTask0()
        {
            Console.WriteLine(BinarySearch0(nums, target));

            return Task.CompletedTask;
        }

        public static int BinarySearch0Test(int[] nums, int target) => BinarySearch0(nums, target);

        [Benchmark]
        public int BinarySearch0Benchmark() => BinarySearch0(nums, target);

        private static int BinarySearch0(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return -1;

            int l = 0, r = nums.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target) { return mid; }
                else if (nums[mid] < target) { l = mid + 1; }
                else { r = mid - 1; }
            }

            return -1;
        }
    }
}
