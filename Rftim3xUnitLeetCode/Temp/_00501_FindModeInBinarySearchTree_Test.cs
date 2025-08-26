using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00501_FindModeInBinarySearchTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 0, 2, 2];
        private static readonly int[] ar = [2];

        private static readonly int[] b0 = [0];
        private static readonly int[] br = [0];

        public static TheoryData<int[], int[]> _00501_FindModeInBinarySearchTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00501_FindModeInBinarySearchTree_Data))]
        public void FindMode0(int[] list0, int[] expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            int[] actual = _00501_FindModeInBinarySearchTree.FindMode0(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
