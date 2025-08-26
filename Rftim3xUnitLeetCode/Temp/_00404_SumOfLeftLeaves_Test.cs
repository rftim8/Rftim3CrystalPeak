using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00404_SumOfLeftLeaves_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 9, 20, 0, 0, 15, 7];
        private static readonly int ar = 24;

        private static readonly int[] b0 = [1];
        private static readonly int br = 0;

        public static TheoryData<int[], int> _00404_SumOfLeftLeaves_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00404_SumOfLeftLeaves_Data))]
        public void SumOfLeftLeaves0(int[] list0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            int actual = _00404_SumOfLeftLeaves.SumOfLeftLeaves0(l0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00404_SumOfLeftLeaves_Data))]
        public void SumOfLeftLeaves1(int[] list0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            int actual = _00404_SumOfLeftLeaves.SumOfLeftLeaves1(l0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
