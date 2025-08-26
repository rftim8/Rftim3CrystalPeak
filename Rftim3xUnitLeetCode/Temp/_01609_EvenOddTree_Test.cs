using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01609_EvenOddTree_Test
    {
        // Arrange
        private static readonly int?[] a0 = [1, 10, 4, 3, null, 7, 9, 12, 8, 6, null, null, 2];
        private static readonly bool ar = true;

        private static readonly int?[] b0 = [5, 4, 2, 3, 3, 7];
        private static readonly bool br = false;

        private static readonly int?[] c0 = [5, 9, 1, 3, 5, 7];
        private static readonly bool cr = false;

        public static TheoryData<int?[], bool> _01609_EvenOddTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_01609_EvenOddTree_Data))]
        public void EvenOddTree0(int?[] a0, bool expected)
        {
            // Arrange
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            // Act
            bool actual = _01609_EvenOddTree.EvenOddTree0(a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01609_EvenOddTree_Data))]
        public void EvenOddTree1(int?[] a0, bool expected)
        {
            // Arrange
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            // Act
            bool actual = _01609_EvenOddTree.EvenOddTree1(a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}