using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00094_BinaryTreeInorderTraversal_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 0, 2, 3];
        private static readonly int[] ar = [1, 3, 2];

        private static readonly int[] b0 = [];
        private static readonly int[] br = [];

        private static readonly int[] c0 = [1];
        private static readonly int[] cr = [1];

        public static TheoryData<int[], int[]> _00094_BinaryTreeInorderTraversal_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00094_BinaryTreeInorderTraversal_Data))]
        public void InorderTraversal0(int[] list1, int[] expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list1);

            // Act
            IList<int> ln = _00094_BinaryTreeInorderTraversal.InorderTraversal0(l0);

            // Assert
            //Assert.Equal(expected, ln);
        }
    }
}
