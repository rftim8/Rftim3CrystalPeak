using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00100_SameTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3];
        private static readonly int[] a1 = [1, 2, 3];
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2];
        private static readonly int[] b1 = [1, 0, 2];
        private static readonly bool br = false;

        private static readonly int[] c0 = [1, 2, 1];
        private static readonly int[] c1 = [1, 1, 2];
        private static readonly bool cr = false;

        public static TheoryData<int[], int[], bool> _00100_SameTree_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00100_SameTree_Data))]
        public void IsSameTree0(int[] a0, int[] a1, bool expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);
            TreeNode0? l1 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a1);

            // Act
            bool ln = _00100_SameTree.IsSameTree0(l0, l1);

            // Assert
            //Assert.Equal(expected, ln);
        }
    }
}
