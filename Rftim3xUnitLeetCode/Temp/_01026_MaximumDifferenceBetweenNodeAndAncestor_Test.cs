using Rftim3LeetCode.Temp;
using static Rftim3LeetCode.Temp._01026_MaximumDifferenceBetweenNodeAndAncestor;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01026_MaximumDifferenceBetweenNodeAndAncestor_Test
    {
        // Arrange
        private static readonly int?[] a0 = [8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13];
        private static readonly int ar = 7;

        private static readonly int?[] b0 = [1, null, 2, null, 0, 3];
        private static readonly int br = 3;

        public static TheoryData<int?[], int> _01026_MaximumDifferenceBetweenNodeAndAncestor_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_01026_MaximumDifferenceBetweenNodeAndAncestor_Data))]
        public void MaxAncestorDiff0(int?[] a0, int expected)
        {
            // Arrange
            TreeNode? l0 = RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _01026_MaximumDifferenceBetweenNodeAndAncestor.MaxAncestorDiff0(l0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_01026_MaximumDifferenceBetweenNodeAndAncestor_Data))]
        public void MaxAncestorDiff1(int?[] a0, int expected)
        {
            // Arrange
            TreeNode? l0 = RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _01026_MaximumDifferenceBetweenNodeAndAncestor.MaxAncestorDiff1(l0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
