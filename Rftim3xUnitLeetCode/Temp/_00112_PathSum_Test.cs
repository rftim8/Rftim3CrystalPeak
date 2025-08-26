using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00112_PathSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 4, 8, 11, 0, 13, 4, 7, 2, 0, 0, 0, 1];
        private static readonly int a1 = 22;
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2, 3];
        private static readonly int b1 = 5;
        private static readonly bool br = false;

        private static readonly int[] c0 = [];
        private static readonly int c1 = 0;
        private static readonly bool cr = false;

        public static TheoryData<int[], int, bool> _00112_PathSum_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00112_PathSum_Data))]
        public void HasPathSum(int[] list0, int target, bool expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            bool actual = _00112_PathSum.HasPathSum0(l0, target);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
