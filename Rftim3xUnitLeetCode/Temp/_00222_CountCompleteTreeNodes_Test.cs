using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00222_CountCompleteTreeNodes_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4, 5, 6];
        private static readonly int ar = 6;

        private static readonly int[] b0 = [];
        private static readonly int br = 0;

        private static readonly int[] c0 = [1];
        private static readonly int cr = 1;

        public static TheoryData<int[], int> _00222_CountCompleteTreeNodes_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00222_CountCompleteTreeNodes_Data))]
        public void CountNodes0(int[] list0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            //int actual = _00222_CountCompleteTreeNodes.CountNodes0(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
