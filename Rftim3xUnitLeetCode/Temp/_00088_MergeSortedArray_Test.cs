using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00088_MergeSortedArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 0, 0, 0];
        private static readonly int a1 = 3;
        private static readonly int[] a2 = [2, 5, 6];
        private static readonly int a3 = 3;
        private static readonly int[] ar = [1, 2, 2, 3, 5, 6];

        private static readonly int[] b0 = [1];
        private static readonly int b1 = 1;
        private static readonly int[] b2 = [];
        private static readonly int b3 = 0;
        private static readonly int[] br = [1];

        private static readonly int[] c0 = [0];
        private static readonly int c1 = 0;
        private static readonly int[] c2 = [1];
        private static readonly int c3 = 1;
        private static readonly int[] cr = [1];

        public static TheoryData<int[], int, int[], int, int[]> _00088_MergeSortedArray_Data =>
            new()
            {
                { a0, a1, a2, a3, ar },
                { b0, b1, b2, b3, br },
                { c0, c1, c2, c3, cr }
            };

        [Theory]
        [MemberData(nameof(_00088_MergeSortedArray_Data))]
        public void Merge0(int[] nums1, int m, int[] nums2, int n, int[] expected)
        {
            // Act
            int[] actual = _00088_MergeSortedArray.Merge0(nums1, m, nums2, n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
