using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00111_MinimumDepthOfBinaryTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 9, 20, 0, 0, 15, 7];
        private static readonly int ar = 2;

        private static readonly int[] b0 = [2, 0, 3, 0, 4, 0, 5, 0, 6];
        private static readonly int br = 5;

        public static TheoryData<int[], int> _00111_MinimumDepthOfBinaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00111_MinimumDepthOfBinaryTree_Data))]
        public void MinimumDepthOfBinaryTree0(int[] a0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _00111_MinimumDepthOfBinaryTree.MinimumDepthOfBinaryTree0(l0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}