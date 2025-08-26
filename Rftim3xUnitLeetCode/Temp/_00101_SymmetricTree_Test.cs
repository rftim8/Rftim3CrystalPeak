using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00101_SymmetricTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 2, 3, 4, 4, 3];
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2, 2, 0, 3, 0, 3];
        private static readonly bool br = false;

        public static TheoryData<int[], bool> _00101_SymmetricTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00101_SymmetricTree_Data))]
        public void IsSymmetric0(int[] a0, bool expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            // Act
            bool ln = _00101_SymmetricTree.IsSymmetric0(l0);

            // Assert
            //Assert.Equal(expected, ln);
        }
    }
}
