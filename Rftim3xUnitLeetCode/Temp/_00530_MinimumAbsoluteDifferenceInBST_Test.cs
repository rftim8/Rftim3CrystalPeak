using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00530_MinimumAbsoluteDifferenceInBST_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 2, 6, 1, 3];
        private static readonly int ar = 1;

        //private static readonly int[] b0 = [1, 0, 48, 0, 0, 12, 49];

        public static TheoryData<int[], int> _00530_MinimumAbsoluteDifferenceInBST_Data =>
            new()
            {
                { a0, ar },
                //new object[] { b0, 1 }
            };

        [Theory]
        [MemberData(nameof(_00530_MinimumAbsoluteDifferenceInBST_Data))]
        public void GetMinimumDifference0(int[] list0, int expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            //int actual = _00530_MinimumAbsoluteDifferenceInBST.GetMinimumDifference0(l0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
