using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00110_BalancedBinaryTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 9, 20, 0, 0, 15, 7];
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2, 2, 3, 3, 0, 0, 4, 4];
        private static readonly bool br = false;

        private static readonly int[] c0 = [];
        private static readonly bool cr = true;

        public static TheoryData<int[], bool> _00110_BalancedBinaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00110_BalancedBinaryTree_Data))]
        public void IsBalanced0(int[] list0, bool expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            bool actual = _00110_BalancedBinaryTree.IsBalanced0(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00110_BalancedBinaryTree_Data))]
        public void IsBalanced1(int[] list0, bool expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            bool actual = _00110_BalancedBinaryTree.IsBalanced1(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
