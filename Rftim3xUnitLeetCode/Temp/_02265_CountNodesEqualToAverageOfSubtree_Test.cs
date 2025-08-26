using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02265_CountNodesEqualToAverageOfSubtree_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 8, 5, 0, 1, 0, 6];
        private static readonly int ar = 5;

        private static readonly int[] b0 = [1];
        private static readonly int br = 1;

        public static TheoryData<int[], int> _02265_CountNodesEqualToAverageOfSubtree_Data =>
            new()
            {
                //new object[] { a0, 5 },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02265_CountNodesEqualToAverageOfSubtree_Data))]
        public void CountNodesEqualToAverageOfSubtree0(int[] list0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            int actual = _02265_CountNodesEqualToAverageOfSubtree.CountNodesEqualToAverageOfSubtree0(l0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
