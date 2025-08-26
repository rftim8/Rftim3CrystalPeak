using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00270_ClosestBinarySearchTreeValue_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 2, 5, 1, 3];
        private static readonly double a1 = 3.714286;
        private static readonly int ar = 4;

        public static TheoryData<int[], double, int> _00270_ClosestBinarySearchTreeValue_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_00270_ClosestBinarySearchTreeValue_Data))]
        public void ClosestBinarySearchTreeValue0(int[] a0, double a1, int expected)
        {
            TreeNode0? t = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _00270_ClosestBinarySearchTreeValue.ClosestBinarySearchTreeValue0(t!, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00270_ClosestBinarySearchTreeValue_Data))]
        public void ClosestBinarySearchTreeValue1(int[] a0, double a1, int expected)
        {
            TreeNode0? t = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _00270_ClosestBinarySearchTreeValue.ClosestBinarySearchTreeValue1(t!, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}