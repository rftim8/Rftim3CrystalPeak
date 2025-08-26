using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00543_DiameterOfBinaryTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4, 5];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [1, 2];
        private static readonly int br = 1;

        public static TheoryData<int[], int> _00543_DiameterOfBinaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00543_DiameterOfBinaryTree_Data))]
        public void DiameterOfBinaryTree0(int[] list0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            //int actual = _00543_DiameterOfBinaryTree.DiameterOfBinaryTree0(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
