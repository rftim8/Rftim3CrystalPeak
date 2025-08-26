using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00496_NextGreaterElement1_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 1, 2];
        private static readonly int[] a1 = [1, 3, 4, 2];
        private static readonly int[] ar = [-1, 3, -1];

        private static readonly int[] b0 = [2, 4];
        private static readonly int[] b1 = [1, 2, 3, 4];
        private static readonly int[] br = [3, -1];

        public static TheoryData<int[], int[], int[]> _00496_NextGreaterElement1_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00496_NextGreaterElement1_Data))]
        public void NextGreaterElement0(int[] nums1, int[] nums2, int[] expected)
        {
            // Act
            int[] actual = _00496_NextGreaterElement1.NextGreaterElement0(nums1, nums2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
