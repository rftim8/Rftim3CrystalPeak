using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00349_IntersectionOfTwoArrays_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 2, 1];
        private static readonly int[] a1 = [2, 2];
        private static readonly int[] ar = [2];

        private static readonly int[] b0 = [4, 9, 5];
        private static readonly int[] b1 = [9, 4, 9, 8, 4];
        private static readonly int[] br = [9, 4];

        public static TheoryData<int[], int[], int[]> _00349_IntersectionOfTwoArrays_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00349_IntersectionOfTwoArrays_Data))]
        public void Intersection0(int[] nums1, int[] nums2, int[] expected)
        {
            // Act
            int[] actual = _00349_IntersectionOfTwoArrays.Intersection0(nums1, nums2);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00349_IntersectionOfTwoArrays_Data))]
        public void Intersection1(int[] nums1, int[] nums2, int[] expected)
        {
            // Act
            int[] actual = _00349_IntersectionOfTwoArrays.Intersection1(nums1, nums2);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
