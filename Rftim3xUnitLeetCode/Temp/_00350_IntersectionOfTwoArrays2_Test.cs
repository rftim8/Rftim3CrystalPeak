using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00350_IntersectionOfTwoArrays2_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 2, 1];
        private static readonly int[] a1 = [2, 2];
        private static readonly int[] ar = [2, 2];

        private static readonly int[] b0 = [4, 9, 5];
        private static readonly int[] b1 = [9, 4, 9, 8, 4];
        private static readonly int[] br = [4, 9];

        public static TheoryData<int[], int[], int[]> _00350_IntersectionOfTwoArrays2_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00350_IntersectionOfTwoArrays2_Data))]
        public void Intersect0(int[] nums1, int[] nums2, int[] expected)
        {
            // Act
            int[] actual = _00350_IntersectionOfTwoArrays2.Intersect0(nums1, nums2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
