using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00145_BinaryTreePostorderTraversal_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 0, 2, 3];
        private static readonly int[] ar = [3, 2, 1];

        private static readonly int[] b0 = [];
        private static readonly int[] br = [];

        private static readonly int[] c0 = [1];
        private static readonly int[] cr = [1];

        public static TheoryData<int[], int[]> _00145_BinaryTreePostorderTraversal_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00145_BinaryTreePostorderTraversal_Data))]
        public void PostorderTraversal0(int[] list0, int[] expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            IList<int> actual = _00145_BinaryTreePostorderTraversal.PostorderTraversal0(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
