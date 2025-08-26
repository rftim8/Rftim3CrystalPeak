using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02385_AmountOfTimeForBinaryTreeToBeInfected_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 5, 3, 0, 4, 10, 6, 9, 2];
        private static readonly int a1 = 3;
        private static readonly int ar = 4;

        private static readonly int[] b0 = [1];
        private static readonly int b1 = 1;
        private static readonly int br = 0;

        public static TheoryData<int[], int, int> _02385_AmountOfTimeForBinaryTreeToBeInfected_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_02385_AmountOfTimeForBinaryTreeToBeInfected_Data))]
        public void AmountOfTime0(int[] a0, int a1, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _02385_AmountOfTimeForBinaryTreeToBeInfected.AmountOfTime0(l0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_02385_AmountOfTimeForBinaryTreeToBeInfected_Data))]
        public void AmountOfTime1(int[] a0, int a1, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            int actual = _02385_AmountOfTimeForBinaryTreeToBeInfected.AmountOfTime1(l0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
